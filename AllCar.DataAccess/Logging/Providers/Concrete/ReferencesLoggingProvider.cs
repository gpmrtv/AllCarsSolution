using AllCar.DataAccess.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllCar.DataAccess.Logging.Providers.Concrete
{
    public class ReferencesLoggingProvider : TableLoggingProvider
    {
        public ReferencesLoggingProvider(ReferencesContext context, IHttpContextAccessor httpContextAccessor) 
            : base(context, httpContextAccessor)
        {
        }
    }
}
