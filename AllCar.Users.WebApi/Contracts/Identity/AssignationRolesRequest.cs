using System;
using System.Collections.Generic;

namespace AllCar.Users.WebApi.Contracts.Identity
{
    public class AssignationRolesRequest
    {
        public IReadOnlyCollection<Guid>? RoleIds { get; set; }
    }
}
