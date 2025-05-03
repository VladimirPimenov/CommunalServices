using Microsoft.AspNetCore.Mvc;

using CommunalServices.Domain.Contracts;
using CommunalServices.Domain.DTO;
using CommunalServices.Domain.Entities;

namespace CommunalServices.Controllers
{
    /// <summary>
    /// Контроллер для аутентификации абонентов.
    /// Этот контроллер предоставляет методы для входа, регистрации и изменения пароля абонентов.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class AuthentificationController(IAbonentAuthenticationService abonentAuthService) : ControllerBase
    {
        /// <summary>
        /// Выполняет вход абонента по логину и паролю.
        /// </summary>
        /// <param name="login">Логин абонента.</param>
        /// <param name="password">Пароль абонента.</param>
        /// <returns>
        /// Возвращает:
        /// - 200 (Ok) с данными абонента, если вход успешен
        /// - 404 (NotFound) если абонент не найден или пароль неверен
        /// </returns>
        [HttpGet("Login")]
        [ProducesResponseType<Abonent>(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> LoginAsync(string login, string password)
        {
            var abonent = await abonentAuthService.LoginAsync(login, password);
            return abonent == null ? NotFound() : Ok(abonent);
        }

        /// <summary>
        /// Выполняет регистрацию нового абонента.
        /// </summary>
        /// <param name="newAbonent">Данные нового абонента.</param>
        /// <returns>
        /// Возвращает:
        /// - 200 (Ok) с зарегистрированным абонентом, если регистрация успешна
        /// - 400 (BadRequest) если произошла ошибка при регистрации
        /// </returns>
        [HttpPost("Register")]
        [ProducesResponseType<Abonent>(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> RegisterAsync(AbonentDTO newAbonent)
        {
            var registeredAbonent = await abonentAuthService.RegisterAsync(newAbonent);
            return registeredAbonent == null ? BadRequest() : Ok(registeredAbonent);
        }

        /// <summary>
        /// Изменяет пароль абонента.
        /// </summary>
        /// <param name="updatedAbonent">Обновленные данные абонента с новым паролем.</param>
        /// <returns>
        /// Возвращает:
        /// - 200 (Ok) с обновленным абонентом, если изменение пароля успешно
        /// - 404 (NotFound) если абонент не найден
        /// </returns>
        [HttpPut("ChangePassword")]
        [ProducesResponseType<Abonent>(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> ChangePassword(AbonentDTO updatedAbonent)
        {
            var abonent = await abonentAuthService.ChangePasswordAsync(updatedAbonent);
            return abonent == null ? NotFound() : Ok(abonent);
        }
    }
}
