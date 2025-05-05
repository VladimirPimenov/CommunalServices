using CommunalServices.Domain.Contracts;
using CommunalServices.Domain.Entities;
using CommunalServices.Domain.DTO;

namespace CommunalServices.Domain.UseCase
{
    public class AbonentAuthenticationService(
        IRepository _repository,
        INotificationService notificationService) : IAbonentAuthenticationService
    {
        public async Task<Abonent> RegisterAsync(AbonentDTO newAbonent)
        {
            if (await IsAbonentExistsAsync(newAbonent))
                return null;

            var registeredAbonent = await _repository.AddAbonentAsync(ConvertToAbonent(newAbonent));
            return registeredAbonent;
        }

        public async Task<Abonent> LoginAsync(string login, string password)
        {
            var abonent = await _repository.GetAbonentByLoginAsync(login);

            if (abonent == null)
                return null;

            if (!abonent.IsValidPassword(password))
                return null;

            return abonent;
        }

        public async Task<Abonent> ChangePasswordAsync(AbonentDTO updatedAbonent)
        {
            var abonent = await _repository.GetAbonentByLoginAsync(updatedAbonent.Login);

            if (abonent == null)
                return null;

            abonent.Password = updatedAbonent.Password;

            await _repository.UpdateAbonentAsync(abonent);

            notificationService.SendNewAbonentPasswordToEmail(abonent);

            return abonent;
        }

        private async Task<bool> IsAbonentExistsAsync(AbonentDTO abonentDto)
        {
            var abonentByLogin = await _repository.GetAbonentByLoginAsync(abonentDto.Login);
            var abonentByEmail = await _repository.GetAbonentByEmailAsync(abonentDto.Email);

            if (abonentByLogin == null && abonentByEmail == null)
                return false;
            return true;
        }

        private Abonent ConvertToAbonent(AbonentDTO abonentDto)
        {
            return new Abonent
            {
                Login = abonentDto.Login,
                Password = abonentDto.Password,
                Email = abonentDto.Email,
                FirstName = abonentDto.FirstName,
                LastName = abonentDto.LastName
            };
        }
    }
}
