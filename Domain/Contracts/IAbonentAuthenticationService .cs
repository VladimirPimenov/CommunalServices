using CommunalServices.Domain.DTO;
using CommunalServices.Domain.Entities;

namespace CommunalServices.Domain.Contracts
{
    public interface IAbonentAuthenticationService
    {
        public Task<Abonent> TryRegisterAsync(AbonentDTO newAbonent);
        public Task<Abonent> TryLoginAsync(string login, string password);
        public Task<Abonent> ChangePasswordAsync(AbonentDTO updatedAbonent);
    }
}
