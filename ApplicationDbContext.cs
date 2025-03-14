﻿using CommunalServices.Models;
using Microsoft.EntityFrameworkCore;

namespace CommunalServices
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Abonent> Abonent { get; set; }
        public DbSet<Flat> Flat { get; set; }
        public DbSet<Debt> Debt { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
