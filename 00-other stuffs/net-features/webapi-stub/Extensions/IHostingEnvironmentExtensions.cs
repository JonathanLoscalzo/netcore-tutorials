using Microsoft.AspNetCore.Hosting;

namespace webapi_stub.Extensions
{
    public static class IHostingEnvironmentExtensions
    {
        public static bool IsDevelopment(this IHostingEnvironment hosting) => hosting.EnvironmentName == "Development";

        public static bool IsProduction(this IHostingEnvironment hosting) => hosting.EnvironmentName == "Production";
    }
}