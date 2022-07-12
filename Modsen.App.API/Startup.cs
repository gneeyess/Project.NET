using AutoMapper;
using Dal.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Modsen.App.DataAccess.Abstractions;
using Modsen.App.DataAccess.Data;
using Modsen.App.DataAccess.Repositories;
using System.IdentityModel.Tokens.Jwt;
using Dal.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Modsen.App.API.Services;
using Modsen.App.Core.Services;
using Mapping.Mappers;

namespace Modsen.App.API
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
                mc.AddProfile(new TourMapper());
                mc.AddProfile(new TourTypeMapper());
                mc.AddProfile(new TransportMapper());
            });
            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

       //     services.AddValidatorsFromAssemblyContaining<BookingValidator>();
            //repositories
            services.AddScoped<IRepository<Booking>, BookingRepository>();
            services.AddScoped<ITourRepository, TourRepository>();
            services.AddScoped<ITourTypeRepository, TourTypeRepository>();
            services.AddScoped<ITransportRepository, TransportRepository>();


            //services
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDBInitializer, EFDBInitiliazer>();
            services.AddScoped<ITourService, TourService>();
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
