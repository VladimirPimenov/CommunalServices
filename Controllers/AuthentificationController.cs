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
    [Route("abonent")]
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
        /// - 401 (Unauthorized) если абонент не найден или пароль неверен
        /// </returns>
        [HttpGet]
        [ProducesResponseType<Abonent>(200)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> LoginAsync(string login, string password)
        {
            var abonent = await abonentAuthService.LoginAsync(login, password);
            return abonent == null ? Unauthorized() : Ok(abonent);
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
        [HttpPost]
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
        /// <param name="login">Логин абонента, для которого необходимо изменить пароль.</param>
        /// <param name="currentPassword">Текущий пароль абонента для проверки.</param>
        /// <param name="newPassword">Новый пароль.</param>
        /// <returns>
        /// Возвращает:
        /// - 200 (Ok) с обновленным абонентом, если изменение пароля успешно
        /// - 401 (Unauthorized) если абонент не найден или текущий пароль неверен
        /// </returns>
        [HttpPut]
        [ProducesResponseType<Abonent>(200)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> ChangePassword(string login, string currentPassword, string newPassword)
        {
            var abonent = await abonentAuthService.ChangePasswordAsync(login, currentPassword, newPassword);
            return abonent == null ? Unauthorized() : Ok(abonent);
        }
    }
}
