using PaymentsByUserCore.Entities;
using PaymentsByUserCore.Enums;
using PaymentsByUserCore.Interfaces.Infrastructure;
using PaymentsByUserInfrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentsByUserInfrastructure.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly List<Payment> _payments;

        public PaymentRepository(DataContext context)
        {
            _payments = context.Payments;
        }

        public List<Payment> GetPaymentsByType(PaymentTypeEnum type)
        {
            return _payments.Where(payment => payment.Type == type).ToList();
        }

        public void SavePayments(List<Payment> payments)
        {
            var distinctPayments = payments.DistinctBy(payment => payment.Id);
            _payments.Clear();
            _payments.AddRange(distinctPayments);
        }
    }
}
