using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebApi.Infraestructure.Extensions;

/**
The Startup class is where you define the request handling pipeline 
and where any services needed by the app are configured.

ConfigureService
defines the services    

Configure
defines the middleware in the request pipeline
 */
namespace WebApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment configuration, ILoggerFactory logFactory)
        {
            /*
            The use of Startu class constructor can accept dependencies that are provided through dependency injection. You can
            IHostingEnvironment to set up configuration sources and ILoggerFactory to set up logging providers.
            */
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            /**
            A service is a component that is intended for common consumption in an application. Services are made available
            through dependency injection (DI). ASP.NET Core includes a simple built-in inversion of control (IoC) container
            that supports constructor injection by default. The built-in container can be easily replaced with your container of
            choice. In addition to its loose coupling benefit, DI makes services available throughout your app. For example,
            logging is available throughout your app. 
            Adding services to the services container makes them available within your application via dependency injection.
            */
            /*
            File formats (INI, JSON, and XML)
            Command-line arguments
            Environment variables
            In-memory .NET objects
            An encrypted user store
            Azure Key Vault
            Custom providers, which you install or create 
            */

            // Add framework services.
            // services.AddDbContext<ApplicationDbContext>(options =>
            //     options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // services.AddIdentity<ApplicationUser, IdentityRole>()
            //     .AddEntityFrameworkStores<ApplicationDbContext>()
            //     .AddDefaultTokenProviders();

            services.AddMvc();

            // // Add application services.
            // services.AddTransient<IEmailSender, AuthMessageSender>();
            // services.AddTransient<ISmsSender, AuthMessageSender>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory,
            IApplicationLifetime applicaionLifetime)
        {
            /**
            In ASP.NET Core you compose your request pipeline using Middleware. ASP.NET Core middleware performs
            asynchronous logic on an HttpContext and then either invokes the next middleware in the sequence or
            terminates the request directly. You generally "Use" middleware by taking a dependency on a NuGet package and
            invoking a corresponding UseXYZ extension method on the IApplicationBuilder in the Configure method. 
            The Configure method is used to specify how the ASP.NET application will respond to HTTP requests. The
            request pipeline is configured by adding middleware components to an IApplicationBuilder instance that is
            provided by dependency injection
            */


            loggerFactory.AddConsole(true);
            loggerFactory.AddDebug();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            //app.UseIdentity();
            app.UseRequestCulture();
            
            //app.UseMapLevelApp("PRUEBA");

            app.Run(async context =>
            {
                //The first app.Run delegate terminates the pipeline.
                await context.Response.WriteAsync($"Hello {CultureInfo.CurrentCulture.DisplayName}");
            });

            /*ASP.NET Core ships with the following middleware components:
            Authentication
            CORS
            ResponseCaching
            responseCompression
            Routing
            Session
            StaticFields
             */            

            // app.UseMvc(routes =>
            // {
            //     routes.MapRoute(
            //     name: "default",
            //     template: "{controller=Home}/{action=Index}/{id?}");
            // });

        }
    }
}
