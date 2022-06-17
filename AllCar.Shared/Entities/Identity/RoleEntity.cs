using System;
using System.Collections.Generic;

namespace AllCar.Shared.Entities.Identity
{
    public class RoleEntity : BaseEntity
    {
        public virtual Guid? ContextUid { get; set; }
        public virtual string Name { get; set; }
        public virtual Guid? ParentId { get; set; }
        public virtual RoleEntity Parent { get; set; }
        public virtual ICollection<UserRolesEntity> Users { get; set; }
        public virtual ICollection<RolePermissionsEntity> Permissions { get; set; }
    }
}
