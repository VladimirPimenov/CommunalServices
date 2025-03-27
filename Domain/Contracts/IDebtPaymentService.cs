using CommunalServices.Domain.Entities;

namespace CommunalServices.Domain.Contracts
{
    public interface IDebtPaymentService
    {
        public Task<Debt> PayDebtAsync(int debtId);
    }
}
