using CommunalServices.Domain;
using CommunalServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CommunalServices.Storage
{
    public class Repository(ApplicationDbContext _context) : IRepository
    {
        public async Task<Abonent> GetAbonentByIdAsync(int id)
        {
            var abonent = await _context.Abonent.FindAsync(id);

            return abonent;
        }
        public async Task<Abonent> GetAbonentByLoginAsync(string login)
        {
            var abonent = await _context.Abonent.FirstOrDefaultAsync(abonent => abonent.Login == login);

            return abonent;
        }
        public async Task<Abonent> AddAbonentAsync(Abonent newAbonent)
        {
            await _context.Abonent.AddAsync(newAbonent);
            await _context.SaveChangesAsync();

            return newAbonent;
        }
        public async Task<Abonent> UpdateAbonentAsync(Abonent updatedAbonent)
        {
            _context.Attach(updatedAbonent);
            await _context.SaveChangesAsync();

            return updatedAbonent;
        }
        public async Task<int> RemoveAbonentAsync(int abonentId)
        {
            var abonent = await _context.Abonent.FindAsync(abonentId);

            _context.Abonent.Remove(abonent);
            await _context.SaveChangesAsync();

            return abonentId;
        }

        public async Task<List<Flat>> GetAbonentFlatsAsync(Abonent abonent)
        {
            var flatsId = await GetAbonentFlatsIdAsync(abonent);

            var flats = await _context.Flat.Where(flat => flatsId.Contains(flat.PaymentNumber)).ToListAsync();

            return flats;
        }
        private async Task<List<string>> GetAbonentFlatsIdAsync(Abonent abonent)
        {
            var flatsId = await _context.AbonentFlat
                                                .Where(a => a.AbonentId == abonent.AbonentId)
                                                .Select(a => a.FlatId)
                                                .ToListAsync();
            return flatsId;
        }

        public async Task<Flat> GetFlatByPaymentNumberAsync(string paymentNumber)
        {
            var flat = await _context.Flat.FindAsync(paymentNumber);

            return flat;
        }
        public async Task<List<Debt>> GetFlatDebtsAsync(Flat flat)
        {
            var debts = await _context.Debt.Where(debt => debt.PaymentNumber == flat.PaymentNumber).ToListAsync();

            return debts;
        }
    }
}