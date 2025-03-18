namespace CommunalServices.Models
{
    /// <summary>
    /// Интерфейс для операций оплаты через банк.
    /// Определяет методы для отправки информации о платеже и проверки статуса операции.
    /// </summary>
    public interface IBankPaymentOperation
    {
        /// <summary>
        /// Отправляет информацию о платеже в банковскую систему.
        /// </summary>
        /// <param name="payAccount">Объект, содержащий информацию о платеже.</param>
        void SendPaymentAccount(PaymentAccount payAccount);

        /// <summary>
        /// Проверяет, была ли операция оплаты успешной.
        /// </summary>
        /// <returns>Возвращает <c>true</c>, если операция успешна; в противном случае <c>false</c>.</returns>
        bool IsSuccessPayOperation();
    }
}
