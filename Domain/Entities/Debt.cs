using System.ComponentModel.DataAnnotations;

namespace CommunalServices.Domain.Entities
{
    /// <summary>
    /// Представляет задолженность в системе жилищно-коммунальных услуг.
    /// Этот класс содержит информацию о задолженности.
    public class Debt
    {
        /// <summary>
        /// Уникальный идентификатор задолженности.
        /// </summary>
        [Key]
        public int DebtId { get; set; }

        /// <summary>
        /// Идентификатор квартиры.
        /// </summary>
        public int FlatId { get; set; }

        /// <summary>
        /// Идентификатор ресурса, за который начислена задолженность.
        /// </summary>
        public int ResourceId { get; set; }

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
