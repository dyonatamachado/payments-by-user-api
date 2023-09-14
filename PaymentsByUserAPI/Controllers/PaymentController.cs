using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentsByUserAPI.InputModels;
using PaymentsByUserAPI.ViewModels;
using PaymentsByUserCore.DomainExceptions;
using PaymentsByUserCore.Enums;
using PaymentsByUserCore.Interfaces.Application;

namespace PaymentsByUserAPI.Controllers
{
    [Route("api/payments")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }


        [HttpGet("{type}")]
        public IActionResult GetPaymentByType(PaymentTypeEnum type)
        {
            var payments = _paymentService.GetPaymentsByType(type);
            var paymentsViewModel = payments.ConvertAll(payment => new PaymentViewModel(payment.Id, payment.Type, payment.Value));
            return Ok(paymentsViewModel);
        }

        [HttpPost("upload")]
        public IActionResult SavePaymentsBySheet(SheetFileInputModel file)
        {
            try
            {
                _paymentService.SavePayments(file.Base64String);
                return Ok();
            }
            catch (InvalidSheetException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
