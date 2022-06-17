using AllCar.Core.Interfaces.Common;
using AllCar.Shared.Dto.Identity;
using AllCar.Shared.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AllCar.Core.Interfaces.Identity
{
    public interface IUserIdentityService : IBaseCrudService<UserEntity, UserDto>
    {
        ValueTask<ICollection<AccessListDto>> GetAccessListAsync(Guid? userId = null, CancellationToken cancellationToken = default);
        Task AssignUserToRolesAsync(Guid userId, IReadOnlyCollection<Guid> roleIds, CancellationToken cancellationToken = default);
        Task UnassignUserFromRolesAsync(Guid userId, IReadOnlyCollection<Guid> roleIds, CancellationToken cancellationToken = default);
        Task CreateRolesAsync(IEnumerable<RoleDto> roles, CancellationToken cancellationToken = default);
        Task RemoveRolesAsync(IEnumerable<Guid> roleIds, CancellationToken cancellationToken = default);
        Task CreatePermissionsAsync(IEnumerable<string> permissions, CancellationToken cancellationToken = default);
        Task RemovePermissionsAsync(IEnumerable<Guid> permissionsId, CancellationToken cancellationToken = default);
    }
}
