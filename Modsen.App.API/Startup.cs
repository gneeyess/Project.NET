using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Modsen.App.Core.Mapping;
using Modsen.App.Core.Models;
using Modsen.App.Core.Validators;
using Modsen.App.DataAccess.Abstractions;
using Modsen.App.DataAccess.Configurations;
using Modsen.App.DataAccess.Data;
using Modsen.App.DataAccess.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Modsen.App.Core.Services;
using Modsen.App.WebHost.Services;


namespace Modsen.App.WebHost
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

            services.AddAuthentication(config =>
            {
                config.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                config.DefaultChallengeScheme = "oidc";
            })
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddOpenIdConnect("oidc", config =>
                {
                    config.Authority = "https://localhost:10001";
                    config.ClientId = "client_id_test";
                    config.ClientSecret = "client_secret_test";
                    config.SaveTokens = true;
                    config.ResponseType = "code";
                });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Modsen.App", Version = "v1" });
            });

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
      
            services.AddValidatorsFromAssemblyContaining<BookingValidator>();
            //repositories
            services.AddScoped<IRepository<Booking>, EFBookingRepository>();
            services.AddScoped<IRepository<Tour>, EFTourRepository>();
            services.AddScoped<IRepository<TourType>, EFTourTypeRepository>();
            services.AddScoped<IRepository<Transport>, EFTransportRepository>();
            services.AddScoped<IRepository<User>, EFUserRepository>();
            services.AddScoped<IRepository<UserRole>, EFUserRoleRepository>();
            //fluent api
            services.AddScoped<IEntityTypeConfiguration<Booking>, BookingConfiguration>();
            services.AddScoped<IEntityTypeConfiguration<Tour>, TourConfiguration>();
            services.AddScoped<IEntityTypeConfiguration<TourType>, TourTypeConfiguration>();
            services.AddScoped<IEntityTypeConfiguration<Transport>, TransportConfiguration>();
            services.AddScoped<IEntityTypeConfiguration<User>, UserConfiguration>();
            services.AddScoped<IEntityTypeConfiguration<UserRole>, UserRoleConfiguration>();
           
            //services
            

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            

            services.AddScoped<IDBInitializer, EFDBInitiliazer>();
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
}
