using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Monit.Project.Core.Models;
using Monit.Project.Core.Services;
using Monit.Project.Core.Services.AuthService;
using Monit.Project.Core.Services.DeviceManipulationService;
using Monit.Project.Core.Services.DeviceScreenService;
using Monit.Project.Core.Services.DeviceStateService;
using Monit.Project.Core.Services.DeviceStaticInfoService;
using Monit.Project.Core.Services.DeviceSystemLogsService;
using Monit.Project.DAL;
using Monit.Project.DAL.Entities;
using Monit.Project.DAL.Interfaces;
using Monit.Project.DAL.Repositories;

namespace Monit.Project.Core
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Monitoringproject"});
            });
            services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddDbContext<DataContext>(options =>
            {
                options.UseNpgsql(
                    Configuration.GetConnectionString("RmmConnection"),
                    assembly =>
                    {
                        assembly.MigrationsAssembly("Rmm.Domain.DAL");
                    });
            });

            services.AddControllers().AddNewtonsoftJson();

            services.AddScoped<IDbRepository, DbRepository>();
            services.AddScoped<IDataService<DeviceStaticInfo>, DeviceStaticInfoService>();
            services.AddSingleton<IDeviceSystemLogsService, DeviceSystemLogsService>();
            services.AddSingleton<IDeviceStateService, DeviceStateService>();
            services.AddSingleton<IDeviceScreenService, DeviceScreenService>();
            services.AddSingleton<IDeviceManiupalationService, DeviceManipulationService>();
            services.AddScoped<IAuthService, AuthService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "v3"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseStaticFiles();
            if (!env.IsDevelopment())
                app.UseSpaStaticFiles();

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "../../ProjectClient";

                if (env.IsDevelopment())
                    spa.UseAngularCliServer("start");
            });
        }
    }
}
