using CommunalServices.Domain.Contracts;
using CommunalServices.Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CommunalServices.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthentificationController(IAbonentAuthenticationService _abonentAuthService): ControllerBase
    {
        [Route("Login")]
        [HttpGet]
        public async Task<IActionResult> LoginAsync(string login, string password)
        {
            var abonent = await _abonentAuthService.LoginAsync(login, password);

            if (abonent == null)
                return NotFound();

            return Ok(abonent);
        }

        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> RegisterAsync(AbonentDTO newAbonent)
        {
            var registeredAbonent = await _abonentAuthService.RegisterAsync(newAbonent);

            if (registeredAbonent == null)
                return BadRequest();

            return Ok(registeredAbonent);
        }

        [Route("ChangePassword")]
        [HttpPut]
        public async Task<IActionResult> ChangePassword(AbonentDTO updatedAbonent)
        {
            var abonent = await _abonentAuthService.ChangePasswordAsync(updatedAbonent);

            if (abonent == null)
                return NotFound();

            return Ok(abonent);
        }
    }
}
