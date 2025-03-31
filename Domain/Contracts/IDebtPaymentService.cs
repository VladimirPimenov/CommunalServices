using CommunalServices.Domain.Entities;

namespace CommunalServices.Domain.Contracts
{
    /// <summary>
    /// Интерфейс для сервиса осуществления оплаты задолженностей.
    /// Этот интерфейс определяет методы для обработки платежей по задолженностям.
    /// </summary>
    public interface IDebtPaymentService
    {
        /// <summary>
        /// Обрабатывает оплату задолженности.
        /// </summary>
        /// <param name="debtId">Идентификатор задолженности, которую нужно оплатить.</param>
        /// <returns>Возвращает объект задолженности после успешной оплаты; иначе null.</returns>
        public Task<Debt> PayDebtAsync(int debtId);
    }
}
