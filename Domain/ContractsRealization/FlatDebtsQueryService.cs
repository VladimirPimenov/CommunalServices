using CommunalServices.Domain.Contracts;
using CommunalServices.Domain.Entities;

namespace CommunalServices.Domain.ContractsRealization
{
    public class FlatDebtsQueryService(IRepository _repository): IFlatDebtsQueryService
    {
        public async Task<List<Debt>> GetFlatDebtsAsync(string paymentNumber)
        {
            var flat = await _repository.GetFlatByPaymentNumberAsync(paymentNumber);

            return flat == null ? null : await _repository.GetFlatDebtsAsync(flat);
        }
    }
}
