using System.ComponentModel.DataAnnotations;

namespace CommunalServices.Domain.Entities
{
    /// <summary>
    /// Представляет квартиру в системе жилищно-коммунальных услуг.
    /// Этот класс содержит информацию о квартире.
    /// </summary>
    public class Flat
    {
        /// <summary>
        /// Номер лицевого счета квартиры.
        /// </summary>
        [Key]
        public string PaymentNumber { get; set; }

        /// <summary>
        /// Регион, в котором находится квартира.
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Город, в котором находится квартира.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Улица и дом, где находится квартира.
        /// </summary>
        public string Street { get; set; }
    }
}
