using CommunalServices.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CommunalServices.Controllers
{
    [Route("Flats")]
    [ApiController]
    public class FlatQueryController(IAbonentFlatsQueryService _abonentFlatsQueryService) : ControllerBase
    {
        [HttpGet("GetAbonentFlats")]
        public async Task<IActionResult> GetAbonentFlats(string abonentLogin)
        {
            var flats = _abonentFlatsQueryService.GetAbonentFlatsAsync(abonentLogin);
            return flats == null ? NotFound() : Ok(flats);
        }
    }
}
