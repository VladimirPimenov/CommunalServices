using CommunalServices.Domain.Entities;

namespace CommunalServices.Domain.Contracts
{
    /// <summary>
    /// Интерфейс сервиса регистрации чеков
    /// </summary>
    public interface IReceiptRegistrationService
    {
        /// <summary>
        /// Регистрирует чек для указанного абонента и счета оплаты
        /// </summary>
        /// <param name="abonentId">Идентификатор абонента</param>
        /// <param name="paymentAccountId">Идентификатор счета оплаты</param>
        /// <returns>true, если чек успешно зарегистрирован; иначе false</returns>
        public Task<bool> RegisterReceiptAsync(int abonentId, int paymentAccountId);
    }
}
