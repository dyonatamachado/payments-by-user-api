using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentsByUserCore.DomainExceptions
{
    public class DuplicatedGridException : Exception
    {
        public DuplicatedGridException(string message) : base(message)
        {

        }
    }
}
