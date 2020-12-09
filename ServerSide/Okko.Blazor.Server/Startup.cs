using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Okko.Blazor.Server.Areas.Identity;
using Okko.Blazor.Server.Data;
using Okko.Shared.DataAccess;
using Okko.Shared.Data;
using Tewr.Blazor.FileReader;
using Okko.Shared.Helpers;
using Okko.Blazor.Server.Helpers;
using Blazored.Toast;
using Okko.Blazor.Server.Models;
using Okko.Shared.Options;
using System.Net.Http;

namespace Okko.Blazor.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public const string BackendUrl = "https://localhost:5001";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.Configure<AppSettingsOptions>(Configuration.GetSection("AppSettings"));
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
            services.AddSingleton<WeatherForecastService>();

            services.AddSingleton<IOracleDataAccess, OracleDataAccess>();
            //services.AddScoped<IDepositEndpoint,DepositEndpoint>();
            services.AddScoped<IPersonEndpoint, PersonEndpoint>();
            //services.AddScoped<IHttpService, HttpService>();
            services.AddFileReaderService(options => options.InitializeOnFirstCall = true);
            services.AddBlazoredToast();

            //services.AddScoped(serviceProvider =>
            //{
            //    var httpClient = new HttpClient { BaseAddress = new Uri(BackendUrl) };
            //    return new Inventory.InventoryClient(new GrpcWebCallInvoker(httpClient));
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
