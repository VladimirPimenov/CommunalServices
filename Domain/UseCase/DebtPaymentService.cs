using CommunalServices.Domain.Contracts;
using CommunalServices.Domain.Repositories;
using CommunalServices.Domain.Entities;

namespace CommunalServices.Domain.UseCase
{
    public class DebtPaymentService(
        IDebtPaymentRepository debtPayRepository, 
        IBankPaymentService bankPaymentService): IDebtPaymentService
    {
        public async Task<Debt> PayDebtAsync(int debtId)
        {
            var debt = await debtPayRepository.GetDebtByIdAsync(debtId);

            if (debt == null)
                return null;

            var paymentAccount = await debtPayRepository.AddPaymentAccountAsync(new PaymentAccount { DebtId = debtId });
            
            bool isSuccessPayment = await bankPaymentService.ProcessPaymentOperationAsync(paymentAccount);

            if (!isSuccessPayment)
                return null;

            await debtPayRepository.RemovePaymentAccountAsync(paymentAccount.PaymentId);
            await debtPayRepository.RemoveDebtAsync(debt.DebtId);

            return debt;
        }
    }
}
