using System.ComponentModel.DataAnnotations;

namespace CommunalServices.Models
{
	public class Debt
	{
		public Guid Id { get; set; }
		public string PaymentNumber { get; set; }
		public string ResourceType { get; set; }
		public string ResourceProvider { get; set; }
		public DateTime AccrualDate { get; set; }
		public decimal Amount { get; set; }
	}
}
