using CommunalServices.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CommunalServices.Controllers
{
    [Route("Payment")]
    [ApiController]
    public class DebtPaymentController(
        IDebtPaymentService _debtPayService, 
        IFlatDebtsQueryService _flatDebtsQueryService) : ControllerBase
    {
        [Route("GetDebts")]
        [HttpGet]
        public async Task<IActionResult> GetFlatDebts(string paymentNumber)
        {
            var debts = await _flatDebtsQueryService.GetFlatDebtsAsync(paymentNumber);

            if (debts == null)
                return NotFound();
            return Ok(debts);
        }

        [Route("PayDebt")]
        [HttpDelete]
        public async Task<IActionResult> RemoveDebt(int debtId)
        {
            var paidDebt = await _debtPayService.PayDebtAsync(debtId);

            if (paidDebt == null)
                return NotFound();

            return Ok(paidDebt);
        }
    }
}
