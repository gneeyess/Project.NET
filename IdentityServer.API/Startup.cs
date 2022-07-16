using System.Reflection;
using Dal.Entities.Identity;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Modsen.App.DataAccess.Data;
using Serilog;

namespace IdentityServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            Log.Logger = new LoggerConfiguration().ReadFrom
                .Configuration(configuration)
                .Enrich.FromLogContext()
                .CreateLogger();
            //Параметры в appsettings.json

            Log.Information(">>>>> Logger Configurated (IdentityServer.API (!!!))");
            //For Serilog
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            var migrationAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ModsenAppDataBase"),
                    migration => migration.MigrationsAssembly(migrationAssembly)));

            services.AddIdentity<User, IdentityRole<int>>()
                .AddEntityFrameworkStores<ApplicationContext>()
                .AddRoleManager<RoleManager<IdentityRole<int>>>()
                .AddUserManager<UserManager<User>>()
                .AddDefaultTokenProviders();


            services.AddIdentityServer(options =>
                {
                    options.UserInteraction.LoginUrl = null;
                })
                //.AddInMemoryClients(IdentityServerConfiguration.GetClients())
                //.AddInMemoryApiResources(IdentityServerConfiguration.GetApiResources())
                //.AddInMemoryIdentityResources(IdentityServerConfiguration.GetIdentityResources())
                //.AddInMemoryApiScopes(IdentityServerConfiguration.GetApiScopes())
                .AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = context =>
                        context.UseSqlServer(Configuration.GetConnectionString("ModsenIdentityServerDataBase"),
                            migration => migration.MigrationsAssembly(migrationAssembly));
                })
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = context =>
                        context.UseSqlServer(Configuration.GetConnectionString("ModsenIdentityServerDataBase"),
                            migration => migration.MigrationsAssembly(migrationAssembly));
                })
                .AddDeveloperSigningCredential()
                .AddAspNetIdentity<User>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Modsen.App", Version = "v1" });
            });

            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            InitializeDatabase(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Modsen.App v1");
                });
            }

            app.UseSerilogRequestLogging(); //Doing much

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseIdentityServer();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
        private void InitializeDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();

                var context = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
                if (!context.Clients.Any())
                {
                    foreach (var client in IdentityServerConfiguration.GetClients())
                    {
                        context.Clients.Add(client.ToEntity());
                    }
                    context.SaveChanges();
                }

                if (!context.IdentityResources.Any())
                {
                    foreach (var resource in IdentityServerConfiguration.GetIdentityResources())
                    {
                        context.IdentityResources.Add(resource.ToEntity());
                    }
                    context.SaveChanges();
                }

                if (!context.ApiScopes.Any())
                {
                    foreach (var resource in IdentityServerConfiguration.GetApiScopes())
                    {
                        context.ApiScopes.Add(resource.ToEntity());
                    }
                    context.SaveChanges();
                }
                if (!context.ApiResources.Any())
                {
                    foreach (var resource in IdentityServerConfiguration.GetApiResources())
                    {
                        context.ApiResources.Add(resource.ToEntity());
                    }
                    context.SaveChanges();
                }
            }
        }
    }
}
