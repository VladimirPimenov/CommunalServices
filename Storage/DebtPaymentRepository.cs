using CommunalServices.Domain.Repositories;
using CommunalServices.Domain.Entities;

namespace CommunalServices.Storage
{
    public class DebtPaymentRepository(CommunalServicesPaymentContext context): IDebtPaymentRepository
    {
        public async Task<Debt> GetDebtByIdAsync(int debtId)
        {
            return await context.Debt.FindAsync(debtId);
        }

        public async Task<int> RemoveDebtAsync(int debtId)
        {
            var debt = await context.Debt.FindAsync(debtId);

            context.Debt.Remove(debt);
            await context.SaveChangesAsync();

            return debtId;
        }

        public async Task<PaymentAccount> AddPaymentAccountAsync(PaymentAccount paymentAccount)
        {
            await context.PaymentAccount.AddAsync(paymentAccount);
            await context.SaveChangesAsync();

            return paymentAccount;
        }

        public async Task<int> RemovePaymentAccountAsync(int paymentId)
        {
            var paymentAccount = await context.PaymentAccount.FindAsync(paymentId);

            context.PaymentAccount.Remove(paymentAccount);
            await context.SaveChangesAsync();

            return paymentId;
        }
    }
}
