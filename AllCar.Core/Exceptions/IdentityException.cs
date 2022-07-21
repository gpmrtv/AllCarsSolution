using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllCar.Core.Exceptions
{
    public class IdentityException : Exception
    {
        public string Domain { get; init; }
        public string Action { get; init; }
        public Guid? ContextUid { get; init; }

        public IdentityException()
        { }

        public IdentityException(string domain)
        {
            Domain = domain;
        }

        public IdentityException(string domain, string action)
            : this(domain)
        {
            Action = action;
        }

        public IdentityException(string domain, string action, Guid? contextUid)
            : this(domain, action)
        {
            ContextUid = contextUid;
        }

        public override string ToString()
        {
            return ContextUid is null
                ? $"Access for action {Action} with resource {Domain} is denied."
                : $"Access for action {Action} with resource {Domain} and Uid={ContextUid} is denied.";
        }

        public static implicit operator string(IdentityException ex) => ex.ToString();
    }
}
