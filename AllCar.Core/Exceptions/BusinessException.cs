using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllCar.Core.Exceptions
{
    public class BusinessException : Exception
    {
        public string Domain { get; private set; }

        public BusinessException(string domain, string message)
            :base(message)
        {
            Domain = domain;
        }

        public override string ToString()
        {
            return $"In business domain {Domain} logical error occured.{Environment.NewLine}Error: {Message}";
        }
    }
}
