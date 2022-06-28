using System;
using System.Collections.Generic;

namespace Rolf.WebApi.Contracts.Identity
{
    public class AssignationRolesRequest
    {
        public IReadOnlyCollection<Guid> RoleIds { get; set; }
    }
}
