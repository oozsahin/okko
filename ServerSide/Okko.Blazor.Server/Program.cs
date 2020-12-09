using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Okko.Blazor.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                //.ConfigureAppConfiguration((hostingContext, builder) =>
                //{
                //    IHostEnvironment env = hostingContext.HostingEnvironment;
                //    builder.Sources.Clear();

                //    builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true); //appsettings.json olmalı değişince tekrar load olacak.
                //    builder.AddJsonFile($"appsettings.{env.ApplicationName}.json", optional: true, reloadOnChange:true);

                //    if(hostingContext.HostingEnvironment.IsDevelopment())
                //    {
                //        builder.AddUserSecrets<Program>();
                //    }

                //    if (hostingContext.HostingEnvironment.IsProduction())
                //    {
                //        var buildconfig = builder.Build();
                //    }

                //    builder.AddEnvironmentVariables();
                //    builder.AddCommandLine(args);

                //})
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
