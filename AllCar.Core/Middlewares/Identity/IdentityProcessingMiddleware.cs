using AllCar.Core.Interfaces.Identity;
using AllCar.Shared.Dto.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;

namespace AllCar.Core.Middlewares.Identity
{
    public class IdentityProcessingMiddleware : IMiddleware
    {
        private readonly IUserIdentityService _userIdentityService;
        private readonly IMemoryCache _memoryCache;

        public IdentityProcessingMiddleware(IUserIdentityService userIdentityService, IMemoryCache memoryCache)
        {
            _userIdentityService = userIdentityService;
            _memoryCache = memoryCache;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var userLogin = context.User?.Identity?.Name;

            UserDto cacheUser = null;

            if (userLogin != null)
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(60));

                string key = userLogin;
                if (!_memoryCache.TryGetValue(key, out cacheUser))
                {
                    try
                    {
                        cacheUser = await _userIdentityService.GetAsync(x => x.Login.ToLower() == userLogin.ToLower(), cancellationToken: context.RequestAborted);
                    }
                    catch (ArgumentNullException)
                    {
                        context.Response.StatusCode = 403;
                        await context.Response.WriteAsync("You have no access to api");

                        return;
                    }

                    _memoryCache.Set(key, cacheUser, cacheEntryOptions);
                }

                context.Features.Set(cacheUser);
                context.Features.Set(await GetAccessListAsync(userLogin, context.RequestAborted));
            }

            if (cacheUser is null)
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("You have no access to api");
            }
            else
            {
                await next?.Invoke(context);
            }
        }

        private async Task<IEnumerable<AccessListDto>> GetAccessListAsync(string userLogin, CancellationToken cancellationToken = default)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(300));

            IEnumerable<AccessListDto> accessList;
            string key = $"{userLogin}_{nameof(accessList)}";
            if (!_memoryCache.TryGetValue(key, out accessList))
            {
                accessList = await _userIdentityService.GetAccessListAsync(cancellationToken: cancellationToken);

                _memoryCache.Set(key, accessList, cacheEntryOptions);
            }

            return accessList;
        }
    }
}
