using CommunalServices.Domain.Entities;

namespace CommunalServices.Domain.DTO
{
    /// <summary>
    /// DTO для передачи данных об абоненте.
    /// </summary>
    public class AbonentDTO
    {
        /// <summary>
        /// Логин абонента.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Пароль абонента. 
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Электронная почта абонента.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Имя абонента.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия абонента.
        /// </summary>
        public string LastName { get; set; }
    }
}
