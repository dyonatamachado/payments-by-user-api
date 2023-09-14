using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentsByUserCore.DTOs
{
    public class SheetCellDTO
    {
        public SheetCellDTO(string id, string type, string value)
        {
            Id = id;
            Type = type;
            Value = value;
        }

        public string Id { get; private set; }
        public string Type { get; private set; }
        public string Value { get; private set; }
    }
}
