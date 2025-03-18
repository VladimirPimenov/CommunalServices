namespace CommunalServices.Models
{
    public interface IBankPaymentOperation
    {
        public void SendPaymentAccount(PaymentAccount payAccount);
        public bool IsSuccessPayOperation();
    }
}
