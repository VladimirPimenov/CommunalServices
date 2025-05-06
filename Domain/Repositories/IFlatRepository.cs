using CommunalServices.Domain.Entities;

namespace CommunalServices.Domain.Repositories
{
    public interface IFlatRepository
    {
        Task<List<Flat>> GetAbonentFlatsAsync(Abonent abonent);

        Task<Flat> GetFlatByPaymentNumberAsync(string paymentNumber);
    }
}
