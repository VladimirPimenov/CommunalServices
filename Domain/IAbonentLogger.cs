using CommunalServices.Domain.DTO;
using CommunalServices.Domain.Entities;

namespace CommunalServices.Domain
{
    public interface IAbonentLogger
    {
        public Task<AbonentDTO> TryRegisterAsync(AbonentDTO newAbonent);
        public Task<AbonentDTO> TryLoginAsync(string login, string password);

        public Task<AbonentDTO> ChangePasswordAsync(AbonentDTO updatedAbonent);

        public Task<List<Flat>> GetAbonentFlatsAsync(string login);
    }
}
