using System.ComponentModel.DataAnnotations;

namespace CommunalServices.Models
{
	public class Flat
	{
		[Key]
		public string PaymentNumber { get; set; }
		public string Region { get; set; }
		public string City { get; set; }
		public string Street { get; set; }
	}
}
