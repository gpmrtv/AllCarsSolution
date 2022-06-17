using System.Collections.Generic;

namespace AllCar.Shared.Entities.Identity
{
    public class UserEntity : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Login { get; set; }
        public virtual ICollection<UserRolesEntity> Roles { get; set; }
    }
}
