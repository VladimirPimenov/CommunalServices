using System.ComponentModel.DataAnnotations;

namespace CommunalServices.Domain.Entities
{
    public class AbonentsFlats
    {
        [Key]
        public int OwnerDocumentId { get; set; }
        public int AbonentId { get; set; }
        public string PaymentNumber { get; set; }
    }
}
