using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerTap.Facade
{
    public class RbValidationException : Exception
    {
            public RbValidationException(string message)
                : base("Validation exception: " + message)
            {
            }
    }
}
