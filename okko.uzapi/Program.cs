using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.WindowsServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace okko.uzapi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();

            #region Service Configuration
            //how service will install
            //sc create WindowsServiceHosted binPath= "C:\WindowsServiceHosted\bin\Debug\netcoreapp2.1\win7-x64\publish\WindowsServiceHosted.exe" --service

            var isService = false;
            if (Debugger.IsAttached == false && args.Contains("--service"))
            {
                isService = true;
            }
            if (isService)
            {
                var pathToContentRoot = Directory.GetCurrentDirectory();
                var webHsotArgs = args.Where(arg => arg != "--service").ToArray();
                string configurationFile = "appsettings.json";
                string portNo = "8008";
                var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
                pathToContentRoot = Path.GetDirectoryName(pathToExe);
                string AppJsonFilePath = Path.Combine(pathToContentRoot, configurationFile);
                if (File.Exists(AppJsonFilePath))
                {
                    using (StreamReader sr = new StreamReader(AppJsonFilePath))
                    {
                        string jsonData = sr.ReadToEnd();
                        JObject jObject = JObject.Parse(jsonData);
                        if (jObject["ServicePort"] != null)
                            portNo = jObject["ServicePort"].ToString();
                    }
                }

                var host = WebHost.CreateDefaultBuilder(webHsotArgs)
                    .UseKestrel()
                    //.UseKestrel(o => o.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(30))
                    .UseContentRoot(pathToContentRoot)
                    .UseStartup<Startup>()
                    .UseUrls("http://localhost:" + portNo)
                    .Build();

                host.RunAsService();
            }
            else
            {
                CreateHostBuilder(args).Build().Run();
            }
            #endregion Service Configuration
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
