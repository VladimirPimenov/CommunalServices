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
            _context.Attach(updatedAbonent);
            await _context.SaveChangesAsync();

            return updatedAbonent;
        }

        public async Task<Guid> RemoveAbonentAsync(Guid abonentId)
        {
            var abonent = await _context.Abonent.FindAsync(abonentId);

            _context.Abonent.Remove(abonent);
            await _context.SaveChangesAsync();

            return abonentId;
        }

        public async Task<List<Flat>> GetAbonentFlatsAsync(Abonent abonent)
        {
            var paymentNumbers = await GetAbonentPaymentNumbers(abonent);
            
            var flats = await _context.Flat.Where(flat => paymentNumbers.Contains(flat.PaymentNumber)).ToListAsync();

            return flats;
        }
        public async Task<List<string>> GetAbonentPaymentNumbers(Abonent abonent)
        {
            var paymentNumbers = await _context.AbonentsFlats
                                                .Where(a => a.AbonentId == abonent.Id)
                                                .Select(a => a.PaymentNumber)
                                                .ToListAsync();
            return paymentNumbers;
        }

        public async Task<Flat> GetFlatByPaymentNumber(string paymentNumber)
        {
            var flat = await _context.Flat.FindAsync(paymentNumber);

            return flat;
        }
        public async Task<List<Debt>> GetFlatDebts(Flat flat)
        {
            var debts = await _context.Debt.Where(debt => debt.PaymentNumber == flat.PaymentNumber).ToListAsync();

            return debts;
        }
    }
}