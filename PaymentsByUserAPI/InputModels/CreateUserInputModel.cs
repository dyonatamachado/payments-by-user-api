using PaymentsByUserCore.Enums;
using System.ComponentModel.DataAnnotations;

namespace PaymentsByUserAPI.InputModels
{
    public class CreateUserInputModel
    {
        [Required(ErrorMessage = "Id is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Must be greater than 0.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Grid A is required")]
        [EnumDataType(typeof(PaymentTypeEnum), ErrorMessage = "Invalid value")]
        public PaymentTypeEnum GridA { get; set; }


        [Required(ErrorMessage = "Grid B is required")]
        [EnumDataType(typeof(PaymentTypeEnum), ErrorMessage = "Invalid value")]
        public PaymentTypeEnum GridB { get; set; }

        [Required(ErrorMessage = "Grid C is required")]
        [EnumDataType(typeof(PaymentTypeEnum), ErrorMessage = "Invalid value")]
        public PaymentTypeEnum GridC { get; set; }

    }
}
