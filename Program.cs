using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace aspnetrazor
{
	public class Program
	{
		public static void Main(string[] args)
		{
			/*
			var builder = new ConfigurationBuilder()
		        .SetBasePath(Directory.GetCurrentDirectory())
		        .AddJsonFile("appsettings1.json", optional: true, reloadOnChange: true)
		        //.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
		        //.AddEnvironmentVariables()
			;
		        
		   IConfiguration configuration = builder.Build();
			
			Console.WriteLine($"Logging = {configuration["Logging:LogLevel:Default"]}");
			Console.WriteLine($"Logging = {configuration["Connections:0:name"]}");
			 */
			BuildWebHost(args).Run();
		}

		public static IWebHost BuildWebHost(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>()
				.Build();
	}
}
