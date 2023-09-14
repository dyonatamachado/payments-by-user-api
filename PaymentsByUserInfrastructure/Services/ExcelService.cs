using OfficeOpenXml;
using PaymentsByUserCore.DomainExceptions;
using PaymentsByUserCore.DTOs;
using PaymentsByUserCore.Entities;
using PaymentsByUserCore.Enums;
using PaymentsByUserCore.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentsByUserInfrastructure.Services
{
    public class ExcelService : IExcelService
    {
        public List<Payment> GetPaymentsFromSheetFile(string base64)
        {
            try
            {
                var payments = new List<Payment>();

                byte[] bytes = Convert.FromBase64String(base64);

                using(var stream = new MemoryStream(bytes))
                {
                    using (var package = new ExcelPackage(stream))
                    {
                        var paymentsSheet = package.Workbook.Worksheets[0];
                        var rowsCount = paymentsSheet.Dimension.Rows;

                        if (paymentsSheet.Dimension.Columns != 3)
                            throw new InvalidSheetException("The number of cols is invalid");

                        for (int row = 1; row <= rowsCount; row++)
                        {
                            var id = paymentsSheet.Cells[row, 1].Text;
                            var type = paymentsSheet.Cells[row, 2].Text;
                            var value = paymentsSheet.Cells[row, 3].Text;

                            var cell = new SheetCellDTO(id, type, value);
                            var payment = ConvertCellToPayment(cell);
                            if(payment != null) payments.Add(payment);
                        }
                    }
                }

                return payments;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private Payment ConvertCellToPayment(SheetCellDTO dto)
        {
            int id = 0;
            if (!int.TryParse(dto.Id, out id)) return null;

            double value = 0.00;
            if (!double.TryParse(dto.Value, out value)) return null;

            var typeInvariant = dto.Type.ToUpperInvariant().Trim();
            if (!(typeInvariant == "ÁGUA" || typeInvariant == "LUZ" || typeInvariant == "INTERNET")) return null;

            var type = PaymentTypeEnum.Water;
            if (typeInvariant == "LUZ") type = PaymentTypeEnum.Eletricity;
            if (typeInvariant == "INTERNET") type = PaymentTypeEnum.Internet;

            return new Payment(id, type, value);
        }
    }
}
