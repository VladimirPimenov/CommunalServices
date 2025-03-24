using CommunalServices.Domain.DTO;
using CommunalServices.Domain.Entities;

namespace CommunalServices.Domain
{
    public interface IAbonentLogger
    {
        public Task<AbonentDTO> TryLoginAsync(string login, string password);

        public Task<AbonentDTO> ChangePassword(AbonentDTO updatedAbonent);

        public Task<List<Flat>> GetAbonentFlats(string login);
    }
}
