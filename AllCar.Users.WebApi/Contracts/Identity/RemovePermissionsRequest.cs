using System;
using System.Collections.Generic;

namespace AllCar.Users.WebApi.Contracts.Identity
{
    public class RemovePermissionsRequest
    {
        public HashSet<Guid>? Permissions { get; set; }
    }
}
