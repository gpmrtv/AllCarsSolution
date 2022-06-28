using System.Collections.Generic;

namespace Rolf.WebApi.Contracts.Identity
{
    public class CreatePermissionsRequest
    {
        public HashSet<string> Permissions { get; set; }
    }
}
