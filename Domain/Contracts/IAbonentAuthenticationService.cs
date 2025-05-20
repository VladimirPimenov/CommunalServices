using CommunalServices.Domain.Entities;
using CommunalServices.Domain.DTO;

namespace CommunalServices.Domain.Contracts
{
    /// <summary>
    /// Интерфейс для аутентификации абонентов.
    /// Определяет методы для регистрации, входа и изменения пароля абонента.
    /// </summary>
    public interface IAbonentAuthenticationService
    {
        /// <summary>
        /// Выполняет регистрацию нового абонента.
        /// </summary>
        /// <param name="newAbonent">DTO, содержащий информацию о новом абоненте.</param>
        /// <returns>Возвращает объект абонента, если регистрация прошла успешно; иначе null.</returns>
        public Task<Abonent> RegisterAsync(AbonentDTO newAbonentDto);

        /// <summary>
        /// Выполняет вход абонента в систему.
        /// </summary>
        /// <param name="login">Логин абонента.</param>
        /// <param name="password">Пароль абонента.</param>
        /// <returns>Возвращает объект абонента, если вход прошел успешно; иначе null.</returns>
        public Task<Abonent> LoginAsync(string login, string password);

        /// <summary>
        /// Изменяет пароль абонента.
        /// </summary>
        /// <param name="updatedAbonent">DTO, содержащий информацию об абоненте с новым паролем.</param>
        /// <returns>Возвращает объект абонента с обновленным паролем, если операция прошла успешно; иначе null.</returns>
        public Task<Abonent> ChangePasswordAsync(string login, string currentPassword, string newPassword);
    }
}
