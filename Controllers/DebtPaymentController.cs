using CommunalServices.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CommunalServices.Controllers
{
    /// <summary>
    /// Контроллер для управления платежами по задолженностям.
    /// Этот контроллер предоставляет функциональность для оплаты задолженностей абонентов.
    /// </summary>
    [Route("Payment")]
    [ApiController]
    public class DebtPaymentController(IDebtPaymentService _debtPayService) : ControllerBase
    {
        /// <summary>
        /// Выполняет оплату задолженности по её идентификатору.
        /// </summary>
        /// <param name="debtId">Идентификатор задолженности, которую необходимо оплатить.</param>
        /// <returns>
        /// Возвращает:
        /// - 200 (Ok) с информацией о погашенной задолженности в случае успешной оплаты
        /// - 404 (NotFound) если задолженность не найдена или произошла ошибка при оплате
        /// </returns>
        [HttpDelete("PayDebt")]
        public async Task<IActionResult> PayDebt(int debtId)
        {
            var paidDebt = await _debtPayService.PayDebtAsync(debtId);
            return paidDebt == null ? NotFound() : Ok(paidDebt);
        }
    }
}
