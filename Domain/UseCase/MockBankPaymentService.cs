using CommunalServices.Domain.Contracts;
using CommunalServices.Domain.Entities;

namespace CommunalServices.Domain.ContractsRealization
{
    public class MockBankPaymentService:IBankPaymentService
    {
        public async Task<bool> ProcessPaymentOperationAsync(PaymentAccount payAccount) 
        { 
            return true; 
        }
    }
}
