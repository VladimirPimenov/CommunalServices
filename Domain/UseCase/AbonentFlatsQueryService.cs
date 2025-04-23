using CommunalServices.Domain.Contracts;
using CommunalServices.Domain.Entities;

namespace CommunalServices.Domain.ContractsRealization
{
    public class AbonentFlatsQueryService(IRepository _repository): IAbonentFlatsQueryService
    {
        public async Task<List<Flat>> GetAbonentFlatsAsync(string login)
        {
            var abonent = await _repository.GetAbonentByLoginAsync(login);
            return abonent == null ? null : await _repository.GetAbonentFlatsAsync(abonent);
        }
    }
}
