namespace CommunalServices.Domain.Entities
{
	/// <summary>
	/// Представляет абонента в системе жилищно-коммунальных услуг.
	/// Этот класс содержит информацию о пользователе приложения.
	/// </summary>
	public class Abonent
	{
		/// <summary>
		/// Уникальный идентификатор абонента.
		/// </summary>
		public int Id { get; set; }

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

		public bool IsValidPassword(string password)
		{
			return Password == password;
		}
	}
}
