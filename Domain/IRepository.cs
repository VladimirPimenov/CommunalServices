using CommunalServices.Domain.Entities;
using CommunalServices.Domain.DTO;

namespace CommunalServices.Domain
{
    public interface IRepository
    {
        public Task<Abonent> GetAbonentByIdAsync(Guid id);
		public Task<Abonent> GetAbonentByLoginAsync(string login);
		public Task<Abonent> AddAbonentAsync(AbonentDTO abonent);
		public Task<Abonent> UpdateAbonentAsync(Abonent updatedAbonent);
		public Task<Guid> RemoveAbonentAsync(Guid abonentId);

        public Task<List<Flat>> GetAbonentFlatsAsync(Abonent abonent);
    }
}