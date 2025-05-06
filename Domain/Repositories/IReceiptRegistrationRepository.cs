using CommunalServices.Domain.Entities;

namespace CommunalServices.Domain.Repositories
{
    public interface IReceiptRegistrationRepository
    {
        Task<Abonent> GetAbonentByIdAsync(int abonentId);

        Task<PaymentAccount> GetPaymentAccountByIdAsync(int paymentId);
    }
}
