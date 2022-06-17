using System;
using System.Collections.Generic;

namespace AllCar.Shared.Dto.Identity
{
    public class AccessListDto
    {
        public Guid RoleId { get; set; }
        public Guid? ContextUid { get; set; }
        public string RoleName { get; set; }
        public HashSet<string> Permissions { get; set; } = new HashSet<string>();
    }
}
