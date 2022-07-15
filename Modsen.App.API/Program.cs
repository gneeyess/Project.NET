using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using log4net;
using Microsoft.Extensions.Logging;
using Modsen.App.API.Controllers;
using Serilog;

namespace Modsen.App.API
{
    public class Program
    {
        private static readonly ILog log4netLog = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly ILogger<Program> logger = new Logger<Program>(new LoggerFactory());

        public static void Main(string[] args)
        {
            Log.Information("In Main");
            log4netLog.Info("In Main");

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).ConfigureLogging(builder =>
                {

                    //for log4net
                    builder.SetMinimumLevel(LogLevel.Trace);
                    builder.AddLog4Net("log4net.config");

                    //Log.Information("In ConfigureLogging");
                }); 
    }
}
