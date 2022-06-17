using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Security.Claims;

namespace AllCar.Identity
{
    public static class IdentityExtensions
    {
        public static ClaimsPrincipal GetIdentity(this HttpContext context) => context.Features.Get<ClaimsPrincipal>();

        public static IServiceCollection AddAllCarIdentity(
            this IServiceCollection services,
            Action<IdentityAuthenticationBuilder> configureAuthentication)
        {
            configureAuthentication(new IdentityAuthenticationBuilder(services));

            return services;
        }
    }
}
