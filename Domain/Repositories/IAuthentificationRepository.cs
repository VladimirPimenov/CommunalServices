using CommunalServices.Domain.Entities;

namespace CommunalServices.Domain.Repositories
{
    public interface IAuthentificationRepository
    {
        Task<Abonent> GetAbonentByLoginAsync(string login);

        Task<Abonent> GetAbonentByEmailAsync(string email);

        Task<Abonent> AddAbonentAsync(Abonent newAbonent);

        Task<Abonent> UpdateAbonentAsync(Abonent updatedAbonent);
    }
}
