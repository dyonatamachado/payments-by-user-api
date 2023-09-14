using PaymentsByUserCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentsByUserCore.Entities
{
    public class Payment
    {
        public int Id { get; private set; }
        public PaymentTypeEnum Type { get; private set; }
        public double Value { get; private set; }

        public Payment(int id, PaymentTypeEnum type, double value)
        {
            Id = id;
            Type = type;
            Value = value;
        }
    }
}
