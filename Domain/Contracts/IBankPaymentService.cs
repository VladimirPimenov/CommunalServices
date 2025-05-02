using CommunalServices.Domain.Entities;

namespace CommunalServices.Domain.Contracts
{
    /// <summary>
    /// Интерфейс для сервиса банковских операций оплаты.
    /// Этот интерфейс определяет методы для обработки платежных операций в банковской системе.
    /// </summary>
    public interface IBankPaymentService
    {
        /// <summary>
        /// Обрабатывает платежную операцию в банковской системе.
        /// </summary>
        /// <param name="payAccount">Объект счета оплаты, который нужно обработать.</param>
        /// <returns>Возвращает true, если операция прошла успешно; иначе false.</returns>
        public Task<bool> ProcessPaymentOperationAsync(PaymentAccount payAccount);
    }
}
