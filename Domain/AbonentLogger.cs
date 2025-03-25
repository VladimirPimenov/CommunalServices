using CommunalServices.Domain.Entities;
using CommunalServices.Domain.DTO;

namespace CommunalServices.Domain
{
    public class AbonentLogger(IRepository _repository):IAbonentLogger
    {
        public async Task<AbonentDTO> TryRegisterAsync(AbonentDTO newAbonent)
        {
            throw new NotImplementedException();
        }

        public async Task<AbonentDTO> TryLoginAsync(string login, string password)
        {
            var abonent = await _repository.GetAbonentByLoginAsync(login);

            if (abonent == null || !abonent.IsValidPassword(password)) 
                return null;

            return AbonentDTO.FromAbonent(abonent);
        }

        public async Task<AbonentDTO> ChangePasswordAsync(AbonentDTO updatedAbonent)
        {
            var abonent = await _repository.GetAbonentByLoginAsync(updatedAbonent.Login);

            abonent.Password = updatedAbonent.Password;

            await _repository.UpdateAbonentAsync(abonent);

            return AbonentDTO.FromAbonent(abonent);
        }

        public async Task<List<Flat>> GetAbonentFlatsAsync(string login)
        {
            var abonent = await _repository.GetAbonentByLoginAsync(login);

            if (abonent == null) 
                return null;

            var flats = await _repository.GetAbonentFlatsAsync(abonent);

            return flats;
        }
    }
}
