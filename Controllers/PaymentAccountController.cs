using CommunalServices.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommunalServices.Controllers
{
    [Route("/PaymentAccount")]
    [ApiController]
    public class PaymentAccountController(ApplicationDbContext dbContext) : Controller
    {
        [HttpGet("{paymentId}")]
        public IActionResult GetPaymentAccountById(Guid paymentId)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult CreatePaymentAccount(PaymentAccount payAccount)
        {
            dbContext.PaymentAccount.Add(payAccount);
            dbContext.SaveChanges();

            return Ok(payAccount);

        }

        [HttpDelete("{paymentId}")]
        public IActionResult RemovePaymentAccountById(Guid paymentId)
        {
            throw new NotImplementedException();
        }
    }
}
