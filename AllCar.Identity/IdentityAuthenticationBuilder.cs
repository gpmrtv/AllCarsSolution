using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AllCar.Identity
{
    public class IdentityAuthenticationBuilder
    {
        public IdentityAuthenticationBuilder(IServiceCollection services) => Services = services;

        public IServiceCollection Services { get; }


        public void UseIIS(Action<IISServerOptions> configure)
        {
            Services.Configure(configure);
            Services.AddAuthentication(options =>
            {
                options.DefaultScheme = IdentityDefaults.Scheme;
                options.DefaultChallengeScheme = IdentityDefaults.Scheme;
                options.AddScheme<IISServerAuthenticationHandler>(options.DefaultScheme, options.DefaultScheme);
            });
        }

        public void UseNegotiate(Action<NegotiateOptions> configure)
        {
            Services
                .AddAuthentication(IdentityDefaults.Scheme)
                .AddScheme<NegotiateOptions, NegotiateHandler>(IdentityDefaults.Scheme, configure);
        }
    }
}