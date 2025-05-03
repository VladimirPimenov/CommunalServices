using Microsoft.AspNetCore.Mvc;

using CommunalServices.Domain.Contracts;
using CommunalServices.Domain.Entities;

namespace CommunalServices.Controllers
{
    /// <summary>
    /// Контроллер для получения информации о задолженностях.
    /// Этот контроллер предоставляет методы для получения списка задолженностей по квартирам.
    /// </summary>
    [Route("debt")]
    [ApiController]
    public class DebtQueryController(IFlatDebtsQueryService flatDebtsQueryService) : ControllerBase
    {
        /// <summary>
        /// Получает список задолженностей для указанной квартиры по номеру лицевого счета.
        /// </summary>
        /// <param name="paymentNumber">Номер лицевого счета квартиры, для которой необходимо получить задолженности.</param>
        /// <returns>
        /// Возвращает:
        /// - 200 (Ok) со списком задолженностей квартиры
        /// - 404 (NotFound) если квартира не найдена или у нее нет задолженностей
        /// </returns>
        [HttpGet]
        [ProducesResponseType<List<Debt>>(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetFlatDebts(string paymentNumber)
        {
            var debts = await flatDebtsQueryService.GetFlatDebtsAsync(paymentNumber);
            return debts == null ? NotFound() : Ok(debts);
        }
    }
}
