using CommunalServices.Domain.Contracts;
using CommunalServices.Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CommunalServices.Controllers
{
    [Route("[controller]")]
    [ApiController]
    /// <summary>
    /// Контроллер для аутентификации абонентов.
    /// Этот контроллер предоставляет методы для входа, регистрации и изменения пароля абонентов.
    /// </summary>
    public class AuthentificationController(IAbonentAuthenticationService _abonentAuthService) : ControllerBase
    {
        /// <summary>
        /// Выполняет вход абонента по логину и паролю.
        /// </summary>
        /// <param name="login">Логин абонента.</param>
        /// <param name="password">Пароль абонента.</param>
        /// <returns>Возвращает статус 200 (Ok) с данными абонента, если вход успешен; иначе 404 (NotFound).</returns>
        [HttpGet("Login")]
        public async Task<IActionResult> LoginAsync(string login, string password)
        {
            var abonent = await _abonentAuthService.LoginAsync(login, password);
            return abonent == null ? NotFound() : Ok(abonent);
        }

        /// <summary>
        /// Выполняет регистрацию нового абонента.
        /// </summary>
        /// <param name="newAbonent">Данные нового абонента.</param>
        /// <returns>Возвращает статус 200 (Ok) с зарегистрированным абонентом, если регистрация успешна; иначе 400 (BadRequest).</returns>
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync(AbonentDTO newAbonent)
        {
            var registeredAbonent = await _abonentAuthService.RegisterAsync(newAbonent);
            return registeredAbonent == null ? BadRequest() : Ok(registeredAbonent);
        }

        /// <summary>
        /// Изменяет пароль абонента.
        /// </summary>
        /// <param name="updatedAbonent">Обновленные данные абонента с новым паролем.</param>
        /// <returns>Возвращает статус 200 (Ok) с обновленным абонентом, если изменение пароля успешно; иначе 404 (NotFound).</returns>
        [HttpPut("ChangePassword")]
        public async Task<IActionResult> ChangePassword(AbonentDTO updatedAbonent)
        {
            var abonent = await _abonentAuthService.ChangePasswordAsync(updatedAbonent);
            return abonent == null ? NotFound() : Ok(abonent);
        }
    }
}
