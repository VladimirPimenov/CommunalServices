using CommunalServices.Domain.Entities;

namespace CommunalServices.Domain.Contracts
{
    /// <summary>
    /// Интерфейс для работы с задолженностями квартир.
    /// Этот интерфейс предоставляет методы для получения информации о задолженностях по квартире.
    /// </summary>
    public interface IFlatDebtsQueryService
    {
        /// <summary>
        /// Получает список задолженностей для указанной квартиры.
        /// </summary>
        /// <param name="paymentNumber">Номер лицевого счета квартиры, для которой нужно получить задолженности.</param>
        /// <returns>Список задолженностей для указанной квартиры.</returns>
        Task<List<Debt>> GetFlatDebtsAsync(string paymentNumber);
    }
}
