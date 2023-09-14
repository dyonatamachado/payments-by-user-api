using PaymentsByUserCore.Enums;

namespace PaymentsByUserAPI.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(int id, string name, PaymentTypeEnum gridA, PaymentTypeEnum gridB, PaymentTypeEnum gridC)
        {
            Id = id;
            Name = name;
            GridA = gridA;
            GridB = gridB;
            GridC = gridC;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public PaymentTypeEnum GridA { get; set; }
        public PaymentTypeEnum GridB { get; set; }
        public PaymentTypeEnum GridC { get; set; }
    }
}
