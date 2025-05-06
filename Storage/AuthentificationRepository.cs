using Microsoft.EntityFrameworkCore;

using CommunalServices.Domain.Repositories;
using CommunalServices.Domain.Entities;

namespace CommunalServices.Storage
{
    public class AuthentificationRepository(CommunalServicesPaymentContext context) : IAuthentificationRepository
    {
        public async Task<Abonent> GetAbonentByLoginAsync(string login)
        {
            return await context.Abonent.FirstOrDefaultAsync(abonent => abonent.Login == login);
        }
        public async Task<Abonent> GetAbonentByEmailAsync(string email)
        {
            return await context.Abonent.FirstOrDefaultAsync(abonent => abonent.Email == email);
        }

        public async Task<Abonent> AddAbonentAsync(Abonent newAbonent)
        {
            await context.Abonent.AddAsync(newAbonent);
            await context.SaveChangesAsync();

            return newAbonent;
        }
        public async Task<Abonent> UpdateAbonentAsync(Abonent updatedAbonent)
        {
            context.Attach(updatedAbonent);
            await context.SaveChangesAsync();

            return updatedAbonent;
        }
    }
}
