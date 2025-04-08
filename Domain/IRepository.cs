using CommunalServices.Domain.Entities;

namespace CommunalServices.Domain
{
    /// <summary>
    /// Интерфейс для работы с базой данных абонентов, квартир и задолженностей.
    /// Этот интерфейс предоставляет методы для выполнения операций с данными абонентов, квартир и задолженностей.
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Получает абонента по логину.
        /// </summary>
        /// <param name="login">Логин абонента.</param>
        /// <returns>Абонент или null, если не найден.</returns>
        Task<Abonent> GetAbonentByLoginAsync(string login);

        /// <summary>
        /// Получает абонента по email.
        /// </summary>
        /// <param name="email">Email абонента.</param>
        /// <returns>Абонент или null, если не найден.</returns>
        Task<Abonent> GetAbonentByEmailAsync(string email);

        /// <summary>
        /// Добавляет нового абонента.
        /// </summary>
        /// <param name="newAbonent">Данные нового абонента.</param>
        /// <returns>Зарегистрированный абонент.</returns>
        Task<Abonent> AddAbonentAsync(Abonent newAbonent);

        /// <summary>
        /// Обновляет данные абонента.
        /// </summary>
        /// <param name="updatedAbonent">Обновленные данные абонента.</param>
        /// <returns>Обновленный абонент.</returns>
        Task<Abonent> UpdateAbonentAsync(Abonent updatedAbonent);

        /// <summary>
        /// Удаляет абонента по идентификатору.
        /// </summary>
        /// <param name="abonentId">Идентификатор абонента.</param>
        /// <returns>Идентификатор удаленного абонента.</returns>
        Task<int> RemoveAbonentAsync(int abonentId);

        /// <summary>
        /// Получает список квартир, принадлежащих указанному абоненту.
        /// </summary>
        /// <param name="abonent">Абонент, для которого нужно получить квартиры.</param>
        /// <returns>Список квартир абонента.</returns>
        Task<List<Flat>> GetAbonentFlatsAsync(Abonent abonent);

        /// <summary>
        /// Получает квартиру по номеру лицевого счета.
        /// </summary>
        /// <param name="paymentNumber">Номер лицевого счета квартиры.</param>
        /// <returns>Квартира или null, если не найдена.</returns>
        Task<Flat> GetFlatByPaymentNumberAsync(string paymentNumber);

        /// <summary>
        /// Получает список задолженностей для указанной квартиры.
        /// </summary>
        /// <param name="flat">Квартира, для которой нужно получить задолженности.</param>
        /// <returns>Список задолженностей для квартиры.</returns>
        Task<List<Debt>> GetFlatDebtsAsync(Flat flat);

        /// <summary>
        /// Получает задолженность по идентификатору.
        /// </summary>
        /// <param name="debtId">Идентификатор задолженности.</param>
        /// <returns>Задолженность или null, если не найдена.</returns>
        Task<Debt> GetDebtByIdAsync(int debtId);

        /// <summary>
        /// Удаляет задолженность по идентификатору.
        /// </summary>
        /// <param name="debtId">Идентификатор задолженности.</param>
        /// <returns>Идентификатор удаленной задолженности.</returns>
        Task<int> RemoveDebtAsync(int debtId);

        /// <summary>
        /// Добавляет новый счет оплаты.
        /// </summary>
        /// <param name="paymentAccount">Данные нового счета оплаты.</param>
        /// <returns>Созданный счет оплаты.</returns>
        Task<PaymentAccount> AddPaymentAccountAsync(PaymentAccount paymentAccount);

        /// <summary>
        /// Удаляет счет оплаты по идентификатору.
        /// </summary>
        /// <param name="paymentAccountId">Идентификатор счета оплаты.</param>
        /// <returns>Идентификатор удаленного счета оплаты.</returns>
        Task<int> RemovePaymentAccountAsync(int paymentAccountId);
    }
}