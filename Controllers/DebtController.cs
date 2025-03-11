using CommunalServices.Data;
using CommunalServices.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommunalServices.Controllers
{
    [Route("/Debt")]
    [ApiController]
    public class DebtController : Controller
    {
        private ApplicationDbContext dbContext;

        public DebtController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("{payNumber}")]
        public IActionResult GetDebtsByPaymentNumber(string payNumber)
        {
            var debts = dbContext.Debt.Where(debt => debt.PaymentNumber == payNumber).ToList();

            if(debts.Count == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(debts);
            }
        }
    }
}
