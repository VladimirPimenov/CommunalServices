using CommunalServices.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CommunalServices.Controllers
{
    /// <summary>
    /// Контроллер для получения информации о квартирах абонентов.
    /// Этот контроллер предоставляет методы для получения списка квартир, принадлежащих абоненту.
    /// </summary>
    [Route("Flats")]
    [ApiController]
    public class FlatQueryController(IAbonentFlatsQueryService _abonentFlatsQueryService) : ControllerBase
    {
        /// <summary>
        /// Получает список квартир, принадлежащих абоненту.
        /// </summary>
        /// <param name="abonentLogin">Логин абонента, для которого необходимо получить список квартир.</param>
        /// <returns>
        /// Возвращает:
        /// - 200 (Ok) со списком квартир абонента
        /// - 404 (NotFound) если квартиры не найдены
        /// </returns>
        [HttpGet("GetAbonentFlats")]
        public async Task<IActionResult> GetAbonentFlats(string abonentLogin)
        {
            var flats = _abonentFlatsQueryService.GetAbonentFlatsAsync(abonentLogin);
            return flats == null ? NotFound() : Ok(flats);
        }
    }
}
