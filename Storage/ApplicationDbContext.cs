using CommunalServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CommunalServices.Storage
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Abonent> Abonent { get; set; }
        public DbSet<Flat> Flat { get; set; }
        public DbSet<Debt> Debt { get; set; }
        public DbSet<PaymentAccount> PaymentAccount { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
