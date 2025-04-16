using CommunalServices.Domain.Contracts;
using CommunalServices.Domain.Entities;

namespace CommunalServices.Domain.ContractsRealization
{
    public class DebtPaymentService(IRepository _repository, IBankPaymentService _bankPaymentService): IDebtPaymentService
    {
        public async Task<Debt> PayDebtAsync(int debtId)
        {
            var debt = await _repository.GetDebtByIdAsync(debtId);

            if (debt == null)
                return null;

            var paymentAccount = await _repository.AddPaymentAccountAsync(new PaymentAccount { DebtId = debtId });
            bool isSuccessPayment = await _bankPaymentService.ProcessPaymentOperationAsync(paymentAccount);

            if (!isSuccessPayment)
                return null;

            await _repository.RemovePaymentAccountAsync(paymentAccount.PaymentId);
            await _repository.RemoveDebtAsync(debt.DebtId);

            return debt;
        }
    }
}
