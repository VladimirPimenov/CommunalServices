namespace CommunalServices.Models
{
    /// <summary>
    /// Представляет платежный аккаунт в системе жилищно-коммунальных услуг.
    /// Этот класс используется для отслеживания платежей, связанных с задолженностями.
    /// </summary>
    public class PaymentAccount
    {
        /// <summary>
        /// Уникальный идентификатор платежа.
        /// </summary>
        public Guid PaymentId { get; set; }

        /// <summary>
        /// Идентификатор задолженности, к которой относится данный платеж.
        /// </summary>
        public Guid DebtId { get; set; }
    }
}
