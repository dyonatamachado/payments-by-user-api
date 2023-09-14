using PaymentsByUserCore.Entities;
using PaymentsByUserCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentsByUserCore.Interfaces.Application
{
    public interface IPaymentService
    {
        public void SavePayments(string base64);
        public List<Payment> GetPaymentsByType(PaymentTypeEnum type);
    }
}
