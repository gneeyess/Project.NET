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

namespace Modsen.App.API
{
    public class Startup
    {
        private readonly IWebHostEnvironment _wevbostEnvironment; //idk what is it

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            Log.Logger = new LoggerConfiguration().ReadFrom
                .Configuration(configuration).CreateLogger();
            //For Serilog
        }

        public Startup(IWebHostEnvironment env)
        {
            //Maybe it can be deleted
            _wevbostEnvironment = env;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration).CreateLogger();

            Log.Information("Starting up");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
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
                //FIX ME mc.AddProfile(new UserMapper());
            });
            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            //services.AddValidatorsFromAssemblyContaining<BookingValidator>();

            //repositories
            services.AddScoped<IRepository<Booking>, BookingRepository>();
            //FIX ME services.AddScoped<IRepository<Tour>, TourRepository>();             FIX
            //FIX ME services.AddScoped<IRepository<TourType>, TourTypeRepository>();     FIX
            //FIX ME services.AddScoped<IRepository<Transport>, TransportRepository>();   FIX


            //services
            //FIX ME services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDBInitializer, EFDBInitiliazer>();

            //usermanager
            services.AddScoped<User>();
        }

        protected virtual void ConfigureAuth(IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDBInitializer dbInitializer)
        {
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

            dbInitializer.Initialize();
        }
    }

    static class CustomExtensionsMethods
    {
        public static void ConfigureAuthService(this IServiceCollection services, IConfiguration configuration)
        {
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
