using System;
using System.Collections.Generic;

namespace Rolf.WebApi.Contracts.Identity
{
    public class RemovePermissionsRequest
    {
        public HashSet<Guid> Permissions { get; set; }
    }
}
