using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace WebApi.Infraestructure.Middlewares
{
    public class MapLevelAppMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IApplicationBuilder app;

        public string prueba { get; private set; }

        public MapLevelAppMiddleware(RequestDelegate next, IApplicationBuilder app, string prueba)
        {
            _next = next;
            this.app = app;
            this.prueba = prueba;
        }
        private static void HandleMapTest1(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Map Test 1");
            });
        }
        private static void HandleMapTest2(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Map Test 2");
            });
        }

        private static void HandleBranch(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                var branchVer = context.Request.Query["branch"];
                await context.Response.WriteAsync($"Branch used = {branchVer}");
            });
        }

        private static void UsingMapRunUseExamples(IApplicationBuilder app)
        {
            /*You configure the HTTP pipeline using Run , Map , and Use . 
            The Run method short-circuits the pipeline (that is, it does not call a next request delegate). 
            Run is a convention, and some middleware components may expose Run[Middleware] methods that run at the end of the pipeline.
            Map* extensions are used as a convention for branching the pipeline. Map branches the request pipeline 
            based on matches of the given request path. If the request path starts with the given path, the branch is 
            executed */
            /*
            Each Use extension method adds a middleware component to the request pipeline. For instance, the UseMvc
            extension method adds the routing middleware to the request pipeline and configures MVC as the default
            handler. 
            */

            /*
            Middleware is software that is assembled into an application pipeline to handle requests and responses. Each
            component chooses whether to pass the request on to the next component in the pipeline, and can perform
            certain actions before and after the next component is invoked in the pipeline. Request delegates are used to
            build the request pipeline. The request delegates handle each HTTP request.
             */

            app.Use(async (context, next) =>
            {
                //Y ou can chain multiple request delegates together with app.Use. The next parameter represents the next
                // delegate in the pipeline.
                // Do work that doesn't write to the Response.
                await context.Response.WriteAsync("Always executed this pipe!");
                await next.Invoke();
                // Do logging or other work that doesn't write to the Response.
            });


            app.Map("/map1", MapTest1 =>
            {
                MapTest1.Map("/map2", map1map2 =>
                {
                    map1map2.Run(async e => await e.Response.WriteAsync("Map1Map2 level!"));
                });

                HandleMapTest1(MapTest1);
            });
            app.Map("/map2", HandleMapTest2);


            //When map is used, the matched path segment(s) are removed from HttpRequest.PathBase for each request.
            //?branch=master
            app.MapWhen(context => context.Request.Query.ContainsKey("branch"), HandleBranch);

            //Map supports nesting, for example:
            // IT COULD BE USE FOR DIFFERENTS VERSIONS OF YOUR WEB API
            //  LOCALHOST/API/V1/LOQUESEA
            app.Map("/level1", level1App =>
            {
                level1App.Map("/level2a", level2AApp =>
                {
                    level2AApp.Run(async context =>
                    {
                        //The first app.Run delegate terminates the pipeline.
                        await context.Response.WriteAsync("Level1/Level2App");
                    });
                });
                level1App.Map("/level2b", level2BApp =>
                {
                    level2BApp.Run(async context =>
                    {
                        //The first app.Run delegate terminates the pipeline.
                        await context.Response.WriteAsync("Level1/Level2B");
                    });
                });
                level1App.Run(async context =>
                    {
                        //The first app.Run delegate terminates the pipeline.
                        await context.Response.WriteAsync("Level1 !!!");
                    });
            });

            /**
            Middleware should follow the Explicit Dependencies Principle by exposing its dependencies in its constructor.
            Middleware is constructed once per application lifetime. See Per-request dependencies below if you need to
            share services with middleware within a request.
            Middleware components can resolve their dependencies from dependency injection through constructor
            parameters. UseMiddleware<T> can also accept additional parameters directly.*/
        }

        public Task Invoke(HttpContext context)
        {
            UsingMapRunUseExamples(app);
            
            return this._next(context);
        }
    }
}