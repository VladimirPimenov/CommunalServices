using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace CommunalServices.Models
{
	public class Abonent
	{
		public Guid Id { get; set; }
		public string? Login { get; set; }
		public string? Password { get; set; }
		public string? Email { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
	}
}
