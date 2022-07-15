using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using log4net;

namespace Modsen.App.API
{
    public class Program
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(Program));

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            _log.Error("kaboom!", new ApplicationException("The application exploded"));
            var log = new log4net.LogManager.GetLogger("", "Shiba");
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
