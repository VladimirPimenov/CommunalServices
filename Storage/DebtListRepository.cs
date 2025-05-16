using Microsoft.EntityFrameworkCore;

using CommunalServices.Domain.Entities;
using CommunalServices.Domain.Repositories;

namespace CommunalServices.Storage
{
    public class DebtListRepository(CommunalServicesPaymentContext context) : IDebtListRepository
    {
        public async Task<List<Debt>> GetFlatDebtsAsync(Flat flat)
        {
            return await context.Debt.Where(debt => debt.FlatId == flat.FlatId).ToListAsync();
        }
    }
}
