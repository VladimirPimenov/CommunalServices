using CommunalServices.Domain.Entities;
using CommunalServices.Domain.DTO;
using CommunalServices.Domain.Contracts;

namespace CommunalServices.Domain.ContractsRealization
{
    public class AbonentAuthenticationService(IRepository _repository) : IAbonentAuthenticationService
    {
        public async Task<Abonent> TryRegisterAsync(AbonentDTO newAbonent)
        {
            throw new NotImplementedException();
        }

        public async Task<Abonent> TryLoginAsync(string login, string password)
        {
            var abonent = await _repository.GetAbonentByLoginAsync(login);

            if (abonent == null || !abonent.IsValidPassword(password))
                return null;

            return abonent;
        }

        public async Task<Abonent> ChangePasswordAsync(AbonentDTO updatedAbonent)
        {
            var abonent = await _repository.GetAbonentByLoginAsync(updatedAbonent.Login);

            abonent.Password = updatedAbonent.Password;

            await _repository.UpdateAbonentAsync(abonent);

            return abonent;
        }
    }
}
