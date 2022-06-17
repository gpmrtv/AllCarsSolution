using System;
using System.Collections.Generic;

namespace AllCar.Shared.ViewModels.Identity
{
    public class RoleViewModel : BaseViewModel
    {
        public Guid? ContextUid { get; set; }
        public string Name { get; set; }
        public Guid? ParentId { get; set; }
        public HashSet<Guid> Permissions { get; set; } = new HashSet<Guid>();
    }
}
