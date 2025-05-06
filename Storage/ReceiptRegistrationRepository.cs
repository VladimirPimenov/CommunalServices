using CommunalServices.Domain.Entities;
using CommunalServices.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CommunalServices.Storage
{
    public class ReceiptRegistrationRepository(CommunalServicesPaymentContext context) : IReceiptRegistrationRepository
    {
        public async Task<Abonent> GetAbonentByIdAsync(int abonentId)
        {
            return await context.Abonent.FindAsync(abonentId);
        }

        public async Task<PaymentAccount> GetPaymentAccountByIdAsync(int paymentId)
        {
            return await context.PaymentAccount.FindAsync(paymentId);
        }
    }
}
