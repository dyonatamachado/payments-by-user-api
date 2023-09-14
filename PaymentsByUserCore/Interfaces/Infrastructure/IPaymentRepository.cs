using PaymentsByUserCore.Entities;
using PaymentsByUserCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentsByUserCore.Interfaces.Infrastructure
{
    public interface IPaymentRepository
    {
        void SavePayments(List<Payment> payments);
        List<Payment> GetPaymentsByType(PaymentTypeEnum type);
    }
}
