using CommunalServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CommunalServices.Storage
{
    public class CommunalServicesPaymentContext : DbContext
    {
        public DbSet<Abonent> Abonent { get; set; }
        public DbSet<Flat> Flat { get; set; }
        public DbSet<Debt> Debt { get; set; }
        public DbSet<PaymentAccount> PaymentAccount { get; set; }
        public DbSet<AbonentFlat> AbonentFlat { get; set; }
        public CommunalServicesPaymentContext(DbContextOptions<CommunalServicesPaymentContext> options) : base(options) { }
    }
}
