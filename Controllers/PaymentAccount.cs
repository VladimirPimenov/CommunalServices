using Microsoft.AspNetCore.Mvc;

namespace CommunalServices.Controllers
{
    [Route("/PaymentAccount")]
    [ApiController]
    public class PaymentAccount(ApplicationDbContext dbContext) : Controller
    {
        [HttpGet("{paymentId}")]
        public IActionResult GetPaymentAccountById(Guid paymentId)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{paymentId}")]
        public IActionResult RemovePaymentAccountById(Guid paymentId)
        {
            throw new NotImplementedException();
        }
    }
}
