using System.ComponentModel.DataAnnotations;

namespace CommunalServices.Domain.Entities
{
    /// <summary>
    /// Представляет связь между абонентом и квартирой в системе.
    /// Этот класс используется для хранения информации о том, какие квартиры принадлежат абоненту.
    /// </summary>
    public class AbonentFlat
    {
        /// <summary>
        /// Уникальный идентификатор записи.
        /// </summary>
        [Key]
        public int AbonentFlatId { get; set; }

        /// <summary>
        /// Идентификатор абонента, которому принадлежит квартира.
        /// </summary>
        public int AbonentId { get; set; }

        /// <summary>
        /// Идентификатор квартиры, принадлежащей абоненту.
        /// </summary>
        public int FlatId { get; set; }

        /// <summary>
        /// Номер документа собственности.
        /// </summary>
        public string OwnershipDocumentNumber { get; set; }
    }
}
