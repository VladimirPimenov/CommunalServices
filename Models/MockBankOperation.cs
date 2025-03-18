namespace CommunalServices.Models
{
    public class MockBankOperation:IBankPaymentOperation
    {
        public void SendPaymentAccount(PaymentAccount payAccount) { }
        public bool IsSuccessPayOperation() { return true; }
    }
}
