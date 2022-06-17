using Microsoft.AspNetCore.Builder;
using AllCar.Core.Middlewares.Identity;

namespace AllCar.Core.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseIdentityProcessing(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<IdentityProcessingMiddleware>();
        }
    }
}
