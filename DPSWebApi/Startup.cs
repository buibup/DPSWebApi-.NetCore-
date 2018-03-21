using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DPSWebApi.AppSetings;
using DPSWebApi.DataAccess;
using DPSWebApi.DataProvider;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DPSWebApi
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
			var config = new ConnectionStrings();
			Configuration.Bind("ConnectionStrings", config);      
			services.AddSingleton(config);

			var settingsDPS = new SettingsDPS();
			Configuration.Bind("SettingsDPS", settingsDPS);
			services.AddSingleton(settingsDPS);

			services.AddTransient<Helper>();
			services.AddTransient<DbConnection>();
			services.AddTransient<IDataConnection, OdbcConnector>();
			services.AddTransient<IDPSDataProvider, DPSDataProvider>();
			services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

			app.UseDefaultFiles();

			app.UseStaticFiles();

			app.UseMvc(routes =>

			{

				routes.MapRoute(

					name: "default",

					template: "{controller=Home}/{action=Index}/{id?}");

			});

        }
    }
}
