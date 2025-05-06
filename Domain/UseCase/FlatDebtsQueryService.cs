using CommunalServices.Domain.Contracts;
using CommunalServices.Domain.Repositories;
using CommunalServices.Domain.Entities;

namespace CommunalServices.Domain.UseCase
{
    public class FlatDebtsQueryService(
        IDebtListRepository debtListRepository,
        IFlatRepository flatRepository): IFlatDebtsQueryService
    {
        public async Task<List<Debt>> GetFlatDebtsAsync(string paymentNumber)
        {
            var flat = await flatRepository.GetFlatByPaymentNumberAsync(paymentNumber);
            return flat == null ? null : await debtListRepository.GetFlatDebtsAsync(flat);
        }
    }
}
