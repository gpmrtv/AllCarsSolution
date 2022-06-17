using Microsoft.AspNetCore.Http;
using AllCar.Shared.Dto.Identity;
using AllCar.Shared.ViewModels.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AllCar.Core.Extensions
{
    public static class HttpContextAccessorExtensions
    {
        //public static Guid GetCurrentUserId(this IHttpContextAccessor httpContextAccessor) => httpContextAccessor.GetCurrentUser().Id;
        public static Guid GetCurrentUserId(this IHttpContextAccessor httpContextAccessor) => httpContextAccessor.GetCurrentUser().Id;

        //public static UserDto GetCurrentUser(this IHttpContextAccessor httpContextAccessor) => httpContextAccessor.HttpContext.Features.Get<UserDto>();
        public static UserDto GetCurrentUser(this IHttpContextAccessor _) => new() { Id = Guid.Parse("2802D518-E375-4478-9202-9BD602C59959") };

        public static IEnumerable<AccessListViewModel> GetCurrentUserAccessList(this IHttpContextAccessor httpContextAccessor)
        {
            var accessListDtos = httpContextAccessor.HttpContext.Features.Get<IEnumerable<AccessListDto>>();

            return accessListDtos.Select(dto => new AccessListViewModel()
            {
                ContextUid = dto.ContextUid,
                RoleId = dto.RoleId,
                RoleName = dto.RoleName,
                Permissions = dto.Permissions
            });
        }
    }
}
