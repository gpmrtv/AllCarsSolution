using System;

namespace AllCar.Shared.Entities.Identity
{
    public class RolePermissionsEntity : BaseEntity
    {
        public virtual Guid RoleId { get; set; }
        public virtual RoleEntity Role { get; set; }
        public virtual Guid PermissionId { get; set; }
        public virtual PermissionEntity Permission { get; set; }

    }
}
