using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using System;
using System.Reflection;

namespace NASA.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
					.ConfigureWebHostDefaults(webBuilder =>
					{
						webBuilder											
							.UseStartup<Startup>()
							  .UseSerilog(ConfigureSerilog);
					});

		private static void ConfigureSerilog(WebHostBuilderContext hostingContext, LoggerConfiguration loggerConfiguration)
		{
			var LevelSwitch = new LoggingLevelSwitch();
			LevelSwitch.MinimumLevel = LogEventLevel.Verbose;

			AssemblyName AssemblyInfo = typeof(Program).Assembly.GetName();

			loggerConfiguration
				.MinimumLevel.ControlledBy(LevelSwitch)
				.Enrich.FromLogContext()				
				.Enrich.WithProperty("MachineName", Environment.MachineName)
				.Enrich.WithProperty("AssemblyName", AssemblyInfo.Name)
				.WriteTo.Console();					
		}
	}
}
