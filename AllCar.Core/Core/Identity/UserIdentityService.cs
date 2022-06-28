using AllCar.Core.Common;
using AllCar.Core.Extensions;
using AllCar.Core.Interfaces;
using AllCar.Core.Interfaces.Common.Providers;
using AllCar.Core.Interfaces.Identity;
using AllCar.Shared.Dto.Identity;
using AllCar.Shared.Entities.Identity;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace AllCar.Core.Identity
{
    public class UserIdentityService : CoreCrudService<UserEntity, UserDto>, IUserIdentityService
    {
        public UserIdentityService(IMapper mapper, IUnitOfWork uow, ICachingProvider cachingProvider, IReplicationProvider replicationProvider, IHttpContextAccessor httpContextAccessor)
            : base(mapper, uow, cachingProvider, replicationProvider, httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        public async Task AssignUserToRolesAsync(Guid userId, IReadOnlyCollection<Guid> roleIds, CancellationToken cancellationToken = default)
        {
            //Removing old roles
            await UnassignUserFromRolesAsync(userId, roleIds, cancellationToken);

            var newUserRoles = new List<UserRolesEntity>();

            //Creating new roles for user
            foreach (var roleId in roleIds)
            {
                newUserRoles.Add(new UserRolesEntity()
                {
                    RoleId = roleId,
                    UserId = userId,
                    CreatedDateTime = DateTime.UtcNow,
                    CreatedUserId = HttpContextAccessor.GetCurrentUserId()
                });
            }

            await Repository.CreateRangeAsync(newUserRoles, cancellationToken);
        }

        public async Task UnassignUserFromRolesAsync(Guid userId, IReadOnlyCollection<Guid> roleIds, CancellationToken cancellationToken = default)
        {
            //Removing old roles
            var existRoles = await Repository.Get<UserRolesEntity>().Where(x => x.UserId == userId).ToListAsync(cancellationToken);
            await Repository.RemoveRangeAsync(existRoles, cancellationToken);
        }

        public async Task CreateRolesAsync(IEnumerable<RoleDto> roles, CancellationToken cancellationToken = default)
        {
            var rolesRef = roles.ToList();
            rolesRef.ForEach(role => role.Id = Guid.NewGuid());

            var rolesToDb = rolesRef.Select(role => new RoleEntity()
            {
                Id = role.Id,
                ContextUid = role.ContextUid,
                Name = role.Name,
                ParentId = role.ParentId,
                CreatedUserId = HttpContextAccessor.GetCurrentUserId(),
                CreatedDateTime = DateTime.UtcNow
            });

            await Repository.CreateRangeAsync(rolesToDb, cancellationToken);

            var roleLinks = new List<RolePermissionsEntity>();
            foreach (var role in rolesRef)
            {
                roleLinks.AddRange(role.Permissions.Select(permission => new RolePermissionsEntity()
                {
                    Id = Guid.NewGuid(),
                    PermissionId = permission,
                    RoleId = role.Id,
                    CreatedUserId = HttpContextAccessor.GetCurrentUserId(),
                    CreatedDateTime = DateTime.UtcNow
                }));
            }

            await Repository.CreateRangeAsync(roleLinks, cancellationToken);
        }

        public Task RemoveRolesAsync(IEnumerable<Guid> roleIds, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public async ValueTask<ICollection<AccessListDto>> GetAccessListAsync(Guid? userId = null, CancellationToken cancellationToken = default)
        {
            var currentUserId = userId.HasValue && userId.Value != Guid.Empty ? userId : HttpContextAccessor.GetCurrentUserId();

            var rolesDb = (await Repository.Get()
                .Include(user => user.Roles)
                .ThenInclude(link => link.Role)
                .ThenInclude(role => role.Permissions)
                .ThenInclude(link => link.Permission)
                .SingleOrDefaultAsync(user => user.Id == currentUserId, cancellationToken))
                .Roles.Select(link => link.Role);

            var accessList = rolesDb.Select(role => new AccessListDto()
            {
                RoleId = role.Id,
                ContextUid = role.ContextUid,
                RoleName = role.Name,
                Permissions = role.Permissions.Select(link => link.Permission.Name).ToHashSet()
            })
                .ToList();

            foreach (var roleDb in rolesDb.Where(role => role.ParentId != null && role.ParentId.Value != Guid.Empty))
            {
                var parentPermissions = (await Repository.Get<RoleEntity>()
                    .Include(role => role.Permissions)
                    .ThenInclude(link => link.Permission)
                    .SingleOrDefaultAsync(role => role.Id == roleDb.ParentId.Value, cancellationToken))
                    .Permissions.Select(link => link.Permission);

                var childRole = accessList.FirstOrDefault(role => role.RoleId == roleDb.Id);

                foreach (var permission in parentPermissions.Select(link => link.Name))
                {
                    childRole.Permissions.Add(permission);
                }
            }

            return accessList;
        }

        public async Task CreatePermissionsAsync(IEnumerable<string> permissions, CancellationToken cancellationToken = default)
        {
            await Repository.CreateRangeAsync(permissions.Select(perm => new PermissionEntity()
            {
                Id = Guid.NewGuid(),
                Name = perm,
                CreatedUserId = HttpContextAccessor.GetCurrentUserId(),
                CreatedDateTime = DateTime.UtcNow
            }), cancellationToken);
        }

        public async Task RemovePermissionsAsync(IEnumerable<Guid> permissionsId, CancellationToken cancellationToken = default)
        {
            await Repository.RemoveRangeAsync(permissionsId.Select(perm => new PermissionEntity() { Id = perm }), cancellationToken);
        }
    }
}
