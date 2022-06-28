using AllCar.Core.Common.Providers;
using AllCar.Core.Identity;
using AllCar.Core.Interfaces.Common.Providers;
using AllCar.Core.Interfaces.Identity;
using AllCar.Core.Mappers;
using AllCar.Core.Middlewares.Identity;
using AutoMapper.EquivalencyExpression;
using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.Extensions.DependencyInjection;

namespace AllCar.Core.DI
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IUserIdentityService, UserIdentityService>();

            services.AddScoped<IdentityProcessingMiddleware>();


            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile(typeof(CoreMapperProfile));
                cfg.AddExpressionMapping();
                cfg.AddCollectionMappers();
            });

            return services;
        }

        public static IServiceCollection AddCoreProviders(this IServiceCollection services)
        {
            services.AddScoped<ICachingProvider, CoreCachingProvider>();
            services.AddScoped<IReplicationProvider, CoreReplicationProvider>();

            return services;
        }
    }
}
