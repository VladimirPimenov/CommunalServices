using System.ComponentModel.DataAnnotations;

namespace CommunalServices.Models
{
	public class Flat
	{
		[Key]
		public string PaymentNumber { get; set; }
		public Guid OwnerId { get; set; }
	}
}
