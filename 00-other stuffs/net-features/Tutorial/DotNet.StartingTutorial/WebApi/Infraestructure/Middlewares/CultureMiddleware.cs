using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebApi.Infraestructure.Middlewares
{
    /**
            Middleware should follow the Explicit Dependencies Principle by exposing its dependencies in its constructor.
            Middleware is constructed once per application lifetime. See Per-request dependencies below if you need to
            share services with middleware within a request.
            Middleware components can resolve their dependencies from dependency injection through constructor
            parameters. UseMiddleware<T> can also accept additional parameters directly.*/

    public class CultureMiddleware
    {
        private readonly RequestDelegate _next;
        public CultureMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            var cultureQuery = context.Request.Query["culture"];
            if (!string.IsNullOrWhiteSpace(cultureQuery))
            {
                var culture = new CultureInfo(cultureQuery);
                CultureInfo.CurrentCulture = culture;
                CultureInfo.CurrentUICulture = culture;
            }
            // Call the next delegate/middleware in the pipeline
            return this._next(context);
        }
    }
}