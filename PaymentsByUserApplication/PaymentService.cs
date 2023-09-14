using PaymentsByUserCore.Entities;
using PaymentsByUserCore.Enums;
using PaymentsByUserCore.Interfaces.Application;
using PaymentsByUserCore.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentsByUserApplication
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IExcelService _excelService;

        public PaymentService(IPaymentRepository paymentRepository, IExcelService excelService)
        {
            _paymentRepository = paymentRepository;
            _excelService = excelService;
        }

        public List<Payment> GetPaymentsByType(PaymentTypeEnum type)
        {
            return _paymentRepository.GetPaymentsByType(type);
        }

        public void SavePayments(string base64)
        {
            var payments = _excelService.GetPaymentsFromSheetFile(base64);
            _paymentRepository.SavePayments(payments);
        }
    }
}
