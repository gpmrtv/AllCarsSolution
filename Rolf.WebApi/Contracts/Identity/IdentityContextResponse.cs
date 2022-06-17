using AllCar.Shared.ViewModels.Identity;
using System;
using System.Collections.Generic;

namespace AllCar.WebApi.Contracts.Identity
{
    public class IdentityContextResponse
    {
        public Guid Id { get; init; }

        public string Login { get; init; }

        public IEnumerable<AccessListViewModel> AccessList { get; init; }
    }
}
