using PaymentsByUserCore.Enums;
using System.ComponentModel.DataAnnotations;

namespace PaymentsByUserAPI.InputModels
{
    public class GridInputModel
    {
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
