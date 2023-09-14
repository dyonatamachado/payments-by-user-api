using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentsByUserCore.DomainExceptions
{
    public class InvalidSheetException : Exception
    {
        public InvalidSheetException(string message) : base(message)    
        {

        }
    }
}
