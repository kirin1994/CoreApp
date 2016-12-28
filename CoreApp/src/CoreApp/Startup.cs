using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Routing;
using CoreApp.Services;

namespace CoreApp
{
    public class Startup
    {
        public Startup(IHostingEnvironment env) {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)//If we dont need to hardcode we can Pass IHostingEnvironment so it will set our root Path on local and server also
                .AddJsonFile("appsettings.json")//add configuration parameter
                .AddEnvironmentVariables(); //when we want to ask configuration parameter later.
            //we can add more confiugration sources

           Configuration = builder.Build(); // build configuration and set acces to this configuration
        }
        public IConfiguration Configuration { get; set; }//Configuration property for acces

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc();
            services.AddSingleton<IGreeter, Greeter>();  //if you see something that requires iGreeter, use class Greeter
            services.AddSingleton(Configuration);//type of IConfiguration, so ASP.NET knows, when to use Configuration parameter
            services.AddScoped<IRestaurantData, InMemoryRestaurantData>(); // Scoped <- Every Http request will create new Instace of RestaurantData
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IGreeter greeter)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            else {
                app.UseExceptionHandler("/welcome");
                
            }

            app.UseStaticFiles();
            //app.UseMvcWithDefaultRoute();//1 add mvc dependency in Config file 2 Add default Route 3 Add service Then we can display something from controller
            app.UseMvc(configureRoutes);
            app.Run(ctx => ctx.Response.WriteAsync("Not Found"));
        }

        private void configureRoutes(IRouteBuilder routeBuilder) {
            //friendly name/path of url
            routeBuilder.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");//?--optional
        }
    }
}
