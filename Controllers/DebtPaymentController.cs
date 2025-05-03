using Microsoft.AspNetCore.Mvc;

using CommunalServices.Domain.Contracts;
using CommunalServices.Domain.Entities;

namespace CommunalServices.Controllers
{
    /// <summary>
    /// Контроллер для управления платежами по задолженностям.
    /// Этот контроллер предоставляет функциональность для оплаты задолженностей абонентов.
    /// </summary>
    [Route("debt-payment")]
    [ApiController]
    public class DebtPaymentController(IDebtPaymentService debtPayService) : ControllerBase
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
        [HttpDelete("{debtId:int}")]
        [ProducesResponseType<Debt>(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> PayDebt(int debtId)
        {
            var paidDebt = await debtPayService.PayDebtAsync(debtId);
            return paidDebt == null ? NotFound() : Ok(paidDebt);
        }
    }
}
