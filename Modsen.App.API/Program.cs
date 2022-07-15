using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using log4net;
using log4net;
using Microsoft.Extensions.Logging;
using Modsen.App.API.Controllers;

namespace Modsen.App.API
{
    public class Program
    {
        private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            _log.Fatal("TESTING, KARL");
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).ConfigureLogging(builder =>
                {
                    builder.SetMinimumLevel(LogLevel.Trace);
                    builder.AddLog4Net("log4net.config");
                    _log.Fatal("TESTING 2, KARL");
                }); //for logging
    }
}
