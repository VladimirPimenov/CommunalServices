using CommunalServices.Domain.Entities;

namespace CommunalServices.Domain.Contracts
{
    /// <summary>
    /// Интерфейс для работы с уведомлениями по электронной почте.
    /// Этот интерфейс предоставляет методы для отправки уведомлений абонентам.
    /// </summary>
    public interface INotificationService
    {
        /// <summary>
        /// Отправляет новый пароль абоненту по электронной почте.
        /// </summary>
        /// <param name="abonent">Абонент, которому нужно отправить новый пароль.</param>
        public void SendNewAbonentPasswordToEmail(Abonent abonent);

        /// <summary>
        /// Отправляет квитанцию об оплате абоненту по электронной почте.
        /// </summary>
        /// <param name="abonent">Абонент, которому нужно отправить квитанцию.</param>
        /// <param name="paymentAccount">Счет оплаты, содержащий информацию о платеже.</param>
        public void SendPaymentReceipt(Abonent abonent, PaymentAccount paymentAccount);
    }
}
