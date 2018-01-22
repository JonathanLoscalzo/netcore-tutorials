using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using webapi_stub.Contracts;
using webapi_stub.Services;

namespace webapi_stub
{
    public class Startup
    {
        private readonly AppSettingConfig AppSetting;
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", false, true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
            .AddEnvironmentVariables()
            .Build(); // Ver otra manera en internet

            var config = new AppSettingConfig();
            builder.Bind(config);
            this.AppSetting = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(); // Agrega todos los controllers
            services.AddScoped<IProfilesService, ProfilesService>();
            services.AddSingleton(this.AppSetting);
            services.AddSingleton<DbMemory>();
            /*
            The first is Transient. This lifecycle is used for light-weight services that do not hold any state
            and are fast to instantiate. They are added using the method
            services.AddTransient<IClock,Clock>() and a new instance of the class is created every
            time it is needed.

            The second lifecycle is Scoped. This is typically used for services that contain a state that is
            valid only for the current request, like repositories and data access classes. Services registered
            as scoped will be created at the beginning of the request and the same instance will be reused
            every time the class is needed within the same request. They are added using the method
            services.AddScoped<IRepository, Repository>().

            The last lifecycle is called Singleton, and as the name implies, services registered this way will
            act like singletons. They are created the first time they are needed and reused throughout the
            rest of the application. Such services typically hold an application state like an in-memory cache
            or similar concerns. They are added via the method
            services.AddSingleton<IApplicationCache, ApplicationCache>().
             */
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //app.UseMvc();
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
            }); 

            app.UseStaticFiles(); //localhost:5000/pp.jpg
            app.UseFileServer();//for use SPA and render some html. index.html, (the first server-side prerrender).

            /*
            For now, it is enough to know that out-of-the-box ASP.NET Core logs all the exceptions, so you don't need to create an exception
            middleware component of a specific code to log unhandled exceptions. */
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //Redirect the user to a specific error page passing the status code as part of the URL.
                //a folder called errors in the wwwroot combined with the UseStaticFiles
                app.UseStatusCodePagesWithRedirects("~/errors/{0}.html");

                //Re-execute the request from a new path.
                //UseStatusCodePagesWithReExecute("~/errors/{0}");
            }

            Func<string, LogLevel, bool> filter = (name, level) => level >= LogLevel.Error;

            loggerFactory.AddConsole(filter);


            // app.Run(async context =>
            // {
            //     if (context.Request.Query.ContainsKey("throw"))
            //     {
            //         //throw new Exception("message problem");
            //     }

            //     await context.Response.WriteAsync("Hello world!");
            // });
        }

        // public void ConfigureDevelopment(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        // {
        //     app.UseMvc();
        //     app.UseStaticFiles();
        //     loggerFactory.AddConsole();
        // }

        // public void ConfigureProduction(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        // {
        //     app.UseMvc();
        //     app.UseStaticFiles();
        //     loggerFactory.AddConsole();
        // }
    }
}
