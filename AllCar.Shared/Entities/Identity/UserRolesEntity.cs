using System;

namespace AllCar.Shared.Entities.Identity
{
    public class UserRolesEntity : BaseEntity
    {
        public virtual Guid UserId { get; set; }
        public virtual UserEntity User { get; set; }
        public virtual Guid RoleId { get; set; }
        public virtual RoleEntity Role { get; set; }
    }
}
