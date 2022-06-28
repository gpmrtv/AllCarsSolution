using AllCar.Core.Middlewares.Identity;
using Microsoft.AspNetCore.Builder;

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
