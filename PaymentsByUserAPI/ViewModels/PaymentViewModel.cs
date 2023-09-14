using PaymentsByUserCore.Enums;

namespace PaymentsByUserAPI.ViewModels
{
    public class PaymentViewModel
    {
        public PaymentViewModel(int id, PaymentTypeEnum type, double value)
        {
            Id = id;
            Type = type;
            Value = value;
        }

        public int Id { get; set; }
        public PaymentTypeEnum Type { get; set; }
        public double Value { get; set; }
    }
}
