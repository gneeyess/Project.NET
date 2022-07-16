using System;
using AutoMapper;
using Dal.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Modsen.App.Core;
using Modsen.App.DataAccess.Abstractions;
using Modsen.App.DataAccess.Data;
using Modsen.App.DataAccess.Repositories;
using System.IdentityModel.Tokens.Jwt;
using Dal.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Settings;
using Serilog.Configuration;
using Serilog.Sinks.Elasticsearch;
using Mapping;
using Mapping.Mappers;

namespace Modsen.App.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            Log.Logger = new LoggerConfiguration().ReadFrom
                .Configuration(configuration)
                .Enrich.FromLogContext()
                .Enrich.WithMachineName()
                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://localhost:10001"))
                {
                    AutoRegisterTemplate = true,
                    IndexFormat = $"context-logs-{DateTime.UtcNow:yyyy-mm-dd-hh}"
                })
                //.WriteTo.Http("http://localhost:10001", 1024, 2048, 1024, 1024)
                .CreateLogger();
			//Параметры частично в appsettings.json

			Log.Information(">>>>> Logger Configurated (Modsen.App.API)");
            //For Serilog
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Log.Debug("In Startup.ConfigureServices()");

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Modsen.App", Version = "v1" });
            });

            services.ConfigureAuthService(Configuration);

            //services.AddIdentity<User, IdentityRole<int>>()
            //    .AddEntityFrameworkStores<ApplicationContext>();


            services.AddDbContext<ApplicationContext>(optionsAction =>
            {
                optionsAction.UseSqlServer(Configuration.GetConnectionString("ModsenAppDataBase"),
                    c => c.MigrationsAssembly(typeof(Startup).Assembly.FullName));
                optionsAction.UseLazyLoadingProxies();
            });
           
            var mapperConfig = new MapperConfiguration(mc =>
            { 
                mc.AddProfile(new UserMapper());
            });
            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            //services.AddValidatorsFromAssemblyContaining<BookingValidator>();

            //repositories
            services.AddScoped<IRepository<Booking>, BookingRepository>();
            services.AddScoped<IRepository<Tour>, TourRepository>();             
            services.AddScoped<IRepository<TourType>, TourTypeRepository>();     
            services.AddScoped<IRepository<Transport>, TransportRepository>();   


            //services

            //FIX ME 
            //services.AddScoped<IUnitOfWork, UnitOfWork>(); <<<<<<<<<<<<<
            services.AddScoped<IDBInitializer, EFDBInitiliazer>();

            //usermanager
            services.AddScoped<Dal.Entities.Identity.User>(); //CHECK ME
        }

        protected virtual void ConfigureAuth(IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDBInitializer dbInitializer)
        {
            Log.Debug("In Startup.Configure()");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Modsen.App v1");
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                //endpoints.MapControllers();
            });

            app.UseSerilogRequestLogging(); //Just check

            dbInitializer.Initialize();
        }
    }

    static class CustomExtensionsMethods
    {
        public static void ConfigureAuthService(this IServiceCollection services, IConfiguration configuration)
        {
            Log.Debug("In Startup.cs CustomExtensionsMethods.ConfigureAuthService(...)");

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");

            var identityUrl = configuration.GetValue<string>("IdentityUrl");

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "Bearer";
                options.DefaultChallengeScheme = "Bearer";
            }).AddJwtBearer(options =>
            {
                options.Authority = identityUrl;
                options.RequireHttpsMetadata = false;
                options.Audience = "api";
            });
        }
    }
}
