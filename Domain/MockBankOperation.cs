using CommunalServices.Domain.Entities;

namespace CommunalServices.Domain
{
    public class MockBankOperation : IBankPaymentOperation
    {
        public void SendPaymentAccount(PaymentAccount payAccount) { }
        public bool IsSuccessPayOperation() { return true; }
    }
}
