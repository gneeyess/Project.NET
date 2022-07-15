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
        private static readonly ILog log4netLog = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
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
                    log4netLog.Fatal("TESTING 2, KARL");
                }); //for log4net
    }
}
