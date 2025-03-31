using CommunalServices.Domain.Entities;

namespace CommunalServices.Domain
{
    public interface IRepository
    {
		public Task<Abonent> GetAbonentByLoginAsync(string login);
        public Task<Abonent> GetAbonentByEmailAsync(string email);
        public Task<Abonent> AddAbonentAsync(Abonent newAbonent);
		public Task<Abonent> UpdateAbonentAsync(Abonent updatedAbonent);
		public Task<int> RemoveAbonentAsync(int abonentId);

        public Task<List<Flat>> GetAbonentFlatsAsync(Abonent abonent);

        public Task<Flat> GetFlatByPaymentNumberAsync(string paymentNumber);
        public Task<List<Debt>> GetFlatDebtsAsync(Flat flat);

        public Task<Debt> GetDebtByIdAsync(int debtId);
        public Task<int> RemoveDebtAsync(int debtId);

        public Task<PaymentAccount> AddPaymentAccountAsync(PaymentAccount paymentAccount);
        public Task<int> RemovePaymentAccountAsync(int paymentAccountId);
    }
}