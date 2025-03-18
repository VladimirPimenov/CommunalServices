namespace CommunalServices.Models
{
    /// <summary>
    /// DTO для передачи данных о квартире.
    /// </summary>
    public class FlatDTO
    {
        public string PaymentNumber { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Street { get; set; }

        public Flat ConvertToFlat()
        {
            return new Flat
            {
                PaymentNumber = this.PaymentNumber,
                Region = this.Region,
                City = this.City,
                Street = this.Street
            };
        }
        
        public static FlatDTO FromFlat(Flat flat)
        {
            return new FlatDTO
            {
                PaymentNumber = flat.PaymentNumber,
                Region = flat.Region,
                City = flat.City,
                Street = flat.Street
            };
        }
    }
} 