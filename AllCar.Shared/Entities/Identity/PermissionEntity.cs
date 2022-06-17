using System.Collections.Generic;

namespace AllCar.Shared.Entities.Identity
{
    public class PermissionEntity : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual ICollection<RolePermissionsEntity> Roles { get; set; }
    }
}
