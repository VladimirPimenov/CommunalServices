using CommunalServices.Domain.Entities;

namespace CommunalServices.Domain.Repositories
{
    public interface IDebtPaymentRepository
    {
        Task<Debt> GetDebtByIdAsync(int debtId);

        Task<int> RemoveDebtAsync(int debtId);

        Task<PaymentAccount> AddPaymentAccountAsync(PaymentAccount paymentAccount);

        Task<int> RemovePaymentAccountAsync(int paymentAccountId);
    }
}
