using CommunalServices.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CommunalServices.Controllers
{
    [Route("Payment")]
    [ApiController]
    /// <summary>
    /// Контроллер для управления платежами по задолженностям.
    /// Этот контроллер предоставляет методы для получения списка задолженностей и оплаты долгов.
    /// </summary>
    public class DebtPaymentController(
        IDebtPaymentService _debtPayService, 
        IFlatDebtsQueryService _flatDebtsQueryService) : ControllerBase
    {
        /// <summary>
        /// Получает список задолженностей для указанной квартиры.
        /// </summary>
        /// <param name="paymentNumber">Номер лицевого счета квартиры.</param>
        /// <returns>Возвращает статус 200 (Ok) с задолженностями, если они найдены; иначе 404 (NotFound).</returns>
        [HttpGet("GetDebts")]
        public async Task<IActionResult> GetFlatDebts(string paymentNumber)
        {
            var debts = await _flatDebtsQueryService.GetFlatDebtsAsync(paymentNumber);
            return debts == null ? NotFound() : Ok(debts);
        }

        /// <summary>
        /// Выполняет оплату задолженности по её идентификатору.
        /// </summary>
        /// <param name="debtId">Идентификатор задолженности.</param>
        /// <returns>Возвращает статус 200 (Ok) с информацией о погашенной задолженности, если оплата успешна; иначе 404 (NotFound).</returns>
        [HttpDelete("PayDebt")]
        public async Task<IActionResult> RemoveDebt(int debtId)
        {
            var paidDebt = await _debtPayService.PayDebtAsync(debtId);
            return paidDebt == null ? NotFound() : Ok(paidDebt);
        }
    }
}
