using CommunalServices.Domain.Entities;
using CommunalServices.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CommunalServices.Storage
{
    public class FlatRepository(CommunalServicesPaymentContext context): IFlatRepository
    {
        public async Task<List<Flat>> GetAbonentFlatsAsync(Abonent abonent)
        {
            var flatsId = await GetAbonentFlatsIdAsync(abonent);

            return await context.Flat.Where(flat => flatsId.Contains(flat.FlatId)).ToListAsync();
        }

        public async Task<Flat> GetFlatByPaymentNumberAsync(string paymentNumber)
        {
            return await context.Flat.FirstOrDefaultAsync(flat => flat.PaymentNumber == paymentNumber);
        }

        private async Task<List<int>> GetAbonentFlatsIdAsync(Abonent abonent)
        {
            return await context.AbonentFlat
                                        .Where(a => a.AbonentId == abonent.AbonentId)
                                        .Select(a => a.FlatId)
                                        .ToListAsync();
        }
    }
}
