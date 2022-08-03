using System.Collections.Generic;

namespace AllCar.Users.WebApi.Contracts.Identity
{
    public class CreatePermissionsRequest
    {
        public HashSet<string>? Permissions { get; set; }
    }
}
