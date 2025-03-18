using System.ComponentModel.DataAnnotations;

namespace CommunalServices.Models
{
	/// <summary>
	/// Представляет задолженность абонента в системе коммунальных услуг.
	/// Этот класс содержит информацию о задолженности.
	public class Debt
	{
		/// <summary>
		/// Уникальный идентификатор задолженности.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Номер лицевого счета квартиры.
		/// </summary>
		public string PaymentNumber { get; set; }

		/// <summary>
		/// Тип ресурса, за который начислена задолженность.
		/// </summary>
		public string ResourceType { get; set; }

		/// <summary>
		/// Поставщик ресурса.
		/// </summary>
		public string ResourceProvider { get; set; }

		/// <summary>
		/// Дата начисления задолженности.
		/// </summary>
		public DateTime AccrualDate { get; set; }

		/// <summary>
		/// Величина задолженности.
		/// </summary>
		public decimal Amount { get; set; }
	}
}
