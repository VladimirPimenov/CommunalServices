using CommunalServices.Domain.Entities;

namespace CommunalServices.Domain.Contracts
{
    /// <summary>
    /// Интерфейс для работы с квартирами абонентов.
    /// </summary>
    public interface IAbonentFlatsQueryService
    {
        /// <summary>
        /// Получает список квартир, принадлежащих указанному абоненту по его логину.
        /// </summary>
        /// <param name="login">Логин абонента, для которого нужно получить квартиры.</param>
        /// <returns>Список квартир, принадлежащих абоненту.</returns>
        public Task<List<Flat>> GetAbonentFlatsAsync(string login);
    }
}
