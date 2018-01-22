using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            /*
            Web root
            The web root of your app is the directory in your project for public, static resources like css, js, and image files. The
            static files middleware will only serve files from the web root directory (and sub-directories) by default. The web
            root path defaults to /wwwroot, but you can specify a different location using the WebHostBuilder 
            
            Content root
            The content root is the base path to any content used by the app, such as its views and web content. By default the
            content root is the same as application base path for the executable hosting the app; an alternative location can be
            specified with WebHostBuilder.
            */
            

            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
        }
    }
}
