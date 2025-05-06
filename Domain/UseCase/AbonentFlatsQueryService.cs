using CommunalServices.Domain.Contracts;
using CommunalServices.Domain.Repositories;
using CommunalServices.Domain.Entities;

namespace CommunalServices.Domain.UseCase
{
    public class AbonentFlatsQueryService(
        IFlatRepository flatRepository,
        IAuthentificationRepository authRepository): IAbonentFlatsQueryService
    {
        public async Task<List<Flat>> GetAbonentFlatsAsync(string login)
        {
            var abonent = await authRepository.GetAbonentByLoginAsync(login);
            return abonent == null ? null : await flatRepository.GetAbonentFlatsAsync(abonent);
        }
    }
}
