using CommunalServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CommunalServices.Controllers
{
    [Route("/Debt")]
    [ApiController]
    public class DebtController(ApplicationDbContext dbContext) : Controller
    {
        [HttpGet("{payNumber}")]
        public async Task<IActionResult> GetDebtsByPaymentNumber(string payNumber)
        {
            var debts = await dbContext.Debt.Where(debt => debt.PaymentNumber == payNumber).ToListAsync();

            return debts.Count == 0 ? NotFound() : Ok(debts);
        }

        [HttpDelete("{debtId}")]
        public async Task<IActionResult> RemoveDebtById(Guid debtId)
        {
            var debt = await dbContext.Debt.FindAsync(debtId);

            if (debt == null) return NotFound();

            dbContext.Debt.Remove(debt);
            await dbContext.SaveChangesAsync();

            return Ok(debtId);
        }
    }
}
