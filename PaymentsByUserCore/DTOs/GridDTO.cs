using PaymentsByUserCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentsByUserCore.DTOs
{
    public class GridDTO
    {
        public GridDTO(PaymentTypeEnum gridA, PaymentTypeEnum gridB, PaymentTypeEnum gridC)
        {
            GridA = gridA;
            GridB = gridB;
            GridC = gridC;
        }

        public PaymentTypeEnum GridA { get; private set; }
        public PaymentTypeEnum GridB { get; private set; }
        public PaymentTypeEnum GridC { get; private set; }
    }
}
