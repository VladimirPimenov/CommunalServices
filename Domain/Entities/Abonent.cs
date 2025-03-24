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

		private string hashedPassword;

		/// <summary>
		/// Пароль абонента. 
		/// При установке пароля он автоматически хешируется.
		/// </summary>
		public string Password 
		{
			get { return hashedPassword; }
			set { HashPassword(value); }
		}

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

		/// <summary>
		/// Проверяет, соответствует ли введенный пароль хешированному паролю абонента.
		/// </summary>
		/// <param name="password">Пароль для проверки.</param>
		/// <returns>true, если пароль соответствует; иначе false.</returns>
		public bool IsValidPassword(string password)
		{
			return Password == password;
		}

		/// <summary>
		/// Хеширует пароль абонента.
		/// </summary>
		/// <param name="password">Пароль, который нужно захешировать.</param>
		private void HashPassword(string password)
		{
			hashedPassword = password;
		}
	}
}
