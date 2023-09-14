using PaymentsByUserCore.DTOs;
using PaymentsByUserCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentsByUserCore.Interfaces.Infrastructure
{
    public interface IExcelService
    {
        List<Payment> GetPaymentsFromSheetFile(string base64);
    }
}
