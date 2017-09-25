using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Elberos.Orm;

namespace aspnetrazor
{
	public class Startup
	{
		public IConfiguration Configuration { get; }
		
		public Startup(IHostingEnvironment env)
		{			
			var builder = new ConfigurationBuilder()
		        .SetBasePath("/home/alfa/Project/aspnetrazor")
		        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
		        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
		        .AddEnvironmentVariables();
		        
		    Configuration = builder.Build();
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();
			services.AddSingleton<IConnections, Connections>();
			services.AddSingleton<IEntityManager, EntityManager>();
			services.AddSingleton<IConfiguration>(Configuration);
		}
		
		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env){
			/*
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else {
				app.UseExceptionHandler("/Error");
			}
			 */
			
			// Get configuration
			//IConfiguration config = app.ApplicationServices.GetService<IConfiguration>();
			
			// Configure connections
			IConnections connections = app.ApplicationServices.GetService<IConnections>();
			connections.Configure(this.Configuration.GetSection("Connections"));
			
			// Configure entity manager
			IEntityManager em = app.ApplicationServices.GetService<IEntityManager>();
			EntityManager.setInstance(em);
			//em.setConnections(connections);
			
			app.UseStatusCodePagesWithReExecute("/error/{0}");
			app.UseDeveloperExceptionPage();
			app.UseStaticFiles();
			app.UseMvc();
		}
	}
}
