using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace CommunalServices.Models
{
	/// <summary>
	/// Представляет абонента в системе коммунальных услуг.
	/// Этот класс содержит информацию о пользователе.
	/// </summary>
	public class Abonent
	{
		/// <summary>
		/// Уникальный идентификатор абонента.
		/// </summary>
		public Guid Id { get; set; }

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
