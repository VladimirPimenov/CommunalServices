using CommunalServices.Domain.Entities;

namespace CommunalServices.Domain.Repositories
{
    public interface IDebtListRepository
    {
        Task<List<Debt>> GetFlatDebtsAsync(Flat flat);
    }
}
