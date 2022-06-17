using System.Collections.Generic;

namespace AllCar.WebApi.Contracts.Identity
{
    public class CreatePermissionsRequest
    {
        public HashSet<string> Permissions { get; set; }
    }
}
