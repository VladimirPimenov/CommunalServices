using CommunalServices.Domain;
using CommunalServices.Domain.DTO;
using CommunalServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CommunalServices.Storage
{
    public class Repository(ApplicationDbContext _context) : IRepository
    {
        public async Task<Abonent> GetAbonentByIdAsync(Guid id)
        {
            var abonent = await _context.Abonent.FindAsync(id);

            return abonent;
        }

        public async Task<Abonent> GetAbonentByLoginAsync(string login)
        {
            var abonent = await _context.Abonent.FirstOrDefaultAsync(abonent => abonent.Login == login);

            return abonent;
        }

        public async Task<Abonent> AddAbonentAsync(AbonentDTO abonentDto)
        {
            var abonent = abonentDto.ConvertToAbonent();

            await _context.Abonent.AddAsync(abonent);
            await _context.SaveChangesAsync();

            return abonent;
        }

        public async Task<Abonent> UpdateAbonentAsync(Abonent updatedAbonent)
        {
            var abonent = await _context.Abonent.FirstOrDefaultAsync(abonent => abonent.Login == updatedAbonent.Login);

            _context.Attach(abonent);
            abonent = updatedAbonent;
            await _context.SaveChangesAsync();

            return abonent;
        }

        public async Task<Guid> RemoveAbonentAsync(Guid abonentId)
        {
            var abonent = await _context.Abonent.FindAsync(abonentId);

            _context.Abonent.Remove(abonent);
            await _context.SaveChangesAsync();

            return abonentId;
        }
    }
}