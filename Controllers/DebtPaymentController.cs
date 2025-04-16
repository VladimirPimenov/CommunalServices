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
        [HttpGet("GetDebts")]
        public async Task<IActionResult> GetFlatDebts(string paymentNumber)
        {
            var debts = await _flatDebtsQueryService.GetFlatDebtsAsync(paymentNumber);

            return debts == null ? NotFound() : Ok(debts);
        }

        [HttpDelete("PayDebt")]
        public async Task<IActionResult> RemoveDebt(int debtId)
        {
            var paidDebt = await _debtPayService.PayDebtAsync(debtId);

            return paidDebt == null ? NotFound() : Ok(paidDebt);
        }
    }
}
