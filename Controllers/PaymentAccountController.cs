using CommunalServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CommunalServices.Controllers
{
    [Route("/PaymentAccount")]
    [ApiController]
    public class PaymentAccountController(ApplicationDbContext dbContext) : Controller
    {
        [HttpGet("{paymentId}")]
        public async Task<IActionResult> GetPaymentAccountById(Guid paymentId)
        {
            var paymentAccount = await dbContext.PaymentAccount.FindAsync(paymentId);
            
            return paymentAccount == null ? NotFound() : Ok(paymentAccount);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePaymentAccount(PaymentAccount payAccount)
        {
            dbContext.PaymentAccount.Add(payAccount);
            await dbContext.SaveChangesAsync();

            return Ok(payAccount);

        }

        [HttpDelete("{paymentId}")]
        public async Task<IActionResult> RemovePaymentAccountById(Guid paymentId)
        {
            var paymentAccount = await dbContext.PaymentAccount.FindAsync(paymentId);

            if (paymentAccount == null) return NotFound();

            dbContext.PaymentAccount.Remove(paymentAccount);
            await dbContext.SaveChangesAsync();

            return Ok(paymentAccount);
        }
    }
}
