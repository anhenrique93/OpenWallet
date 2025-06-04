using Microsoft.EntityFrameworkCore;
using OpenWallet.Application.Database.Configurations;
using OpenWallet.Application.Models;
using OpenWallet.Application.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWallet.Application.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Account> Accounts => Set<Account>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                    "Server=localhost,1433;Database=OpenWalletDB;User Id=sa;Password=MyPassword123;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
        }
    }
}
