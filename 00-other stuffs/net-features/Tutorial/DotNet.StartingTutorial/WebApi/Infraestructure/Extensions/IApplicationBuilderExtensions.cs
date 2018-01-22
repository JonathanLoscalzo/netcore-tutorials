using Microsoft.AspNetCore.Builder;
using WebApi.Infraestructure.Middlewares;

namespace WebApi.Infraestructure.Extensions
{
    public static class IApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseRequestCulture(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CultureMiddleware>();
        }

        public static IApplicationBuilder UseMapLevelApp(this IApplicationBuilder builder, string str)
        {
            return builder.UseMiddleware<MapLevelAppMiddleware>(builder, str);
        }
    }
}