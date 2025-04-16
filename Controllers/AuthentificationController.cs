using CommunalServices.Domain.Contracts;
using CommunalServices.Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CommunalServices.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthentificationController(IAbonentAuthenticationService _abonentAuthService): ControllerBase
    {
        [HttpGet("Login")]
        public async Task<IActionResult> LoginAsync(string login, string password)
        {
            var abonent = await _abonentAuthService.LoginAsync(login, password);

            return abonent == null ? NotFound() : Ok(abonent);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync(AbonentDTO newAbonent)
        {
            var registeredAbonent = await _abonentAuthService.RegisterAsync(newAbonent);

            return registeredAbonent == null ? BadRequest() : Ok(registeredAbonent);
        }

        [HttpPut("ChangePassword")]
        public async Task<IActionResult> ChangePassword(AbonentDTO updatedAbonent)
        {
            var abonent = await _abonentAuthService.ChangePasswordAsync(updatedAbonent);

            return abonent == null ? NotFound() : Ok(abonent);
        }
    }
}
