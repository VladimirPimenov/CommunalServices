using Microsoft.AspNetCore.Mvc;

using CommunalServices.Domain.Contracts;
using CommunalServices.Domain.Entities;

namespace CommunalServices.Controllers
{
    /// <summary>
    /// Контроллер для получения информации о квартирах абонентов.
    /// Этот контроллер предоставляет методы для получения списка квартир, принадлежащих абоненту.
    /// </summary>
    [Route("flats")]
    [ApiController]
    public class FlatQueryController(IAbonentFlatsQueryService abonentFlatsQueryService) : ControllerBase
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
        [HttpGet]
        [ProducesResponseType<List<Flat>>(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAbonentFlats(string abonentLogin)
        {
            var flats = await abonentFlatsQueryService.GetAbonentFlatsAsync(abonentLogin);
            return flats == null ? NotFound() : Ok(flats);
        }
    }
}
