using System;
using System.Collections.Generic;

namespace AllCar.Shared.ViewModels.Identity
{
    public class AccessListViewModel
    {
        public Guid RoleId { get; set; }
        public Guid? ContextUid { get; set; }
        public string RoleName { get; set; }
        public HashSet<string> Permissions { get; set; } = new HashSet<string>();
    }
}
