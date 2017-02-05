using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace SE406_Dobachesky
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            // Add entity framework for each DB Context
            services.AddEntityFrameworkSqlServer()
                .AddEntityFrameworkSqlServer()
                .AddDbContext<SE406_Dobachesky.BridgesDBContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("MSSQLDB"));
                })
                .AddDbContext<SE406_Dobachesky.ConstructionDesignsDBContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("MSSQLDB"));
                })
                .AddDbContext<SE406_Dobachesky.CountiesDBContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("MSSQLDB"));
                })
                .AddDbContext<SE406_Dobachesky.FunctionalClassesDBContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("MSSQLDB"));
                })
                .AddDbContext<SE406_Dobachesky.InspectionCodesDBContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("MSSQLDB"));
                })
                .AddDbContext<SE406_Dobachesky.InspectionsDBContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("MSSQLDB"));
                })
                .AddDbContext<SE406_Dobachesky.InspectorsDBContext>(options =>
                 {
                     options.UseSqlServer(Configuration.GetConnectionString("MSSQLDB"));
                 })
                .AddDbContext<SE406_Dobachesky.MaintenanceActionsDBContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("MSSQLDB"));
                })
                .AddDbContext<SE406_Dobachesky.MaintenanceRecordsDBContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("MSSQLDB"));
                })
                .AddDbContext<SE406_Dobachesky.MaterialDesignsDBContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("MSSQLDB"));
                })
                .AddDbContext<SE406_Dobachesky.StatusCodesDBContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("MSSQLDB"));
                });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseApplicationInsightsRequestTelemetry();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
