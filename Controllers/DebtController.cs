using CommunalServices.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace CommunalServices.Controllers
{
    [Route("/Debt")]
    [ApiController]
    public class DebtController(ApplicationDbContext dbContext) : Controller
    {
        [HttpGet("{payNumber}")]
        public IActionResult GetDebtsByPaymentNumber(string payNumber)
        {
            var debts = dbContext.Debt.Where(debt => debt.PaymentNumber == payNumber).ToList();

            return debts.Count == 0 ? NotFound() : Ok(debts);
        }

        [HttpDelete("{debtId}")]
        public IActionResult RemoveDebtById(Guid debtId)
        {
            var debt = dbContext.Debt.Find(debtId);

            if (debt == null) return NotFound();

            dbContext.Debt.Remove(debt);
            dbContext.SaveChanges();

            return Ok(debtId);
        }
    }
}
