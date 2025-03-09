using CommunalServices.Models;
using Microsoft.EntityFrameworkCore;

namespace CommunalServices.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Abonent> Abonent { get; set; }
        public DbSet<Flat> Flat { get; set; }
        public DbSet<Flat> Debt { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }		
	}
}
