using Microsoft.EntityFrameworkCore;
using OpenWallet.Application.Database.Configurations;
using OpenWallet.Application.Models;
using OpenWallet.Application.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace OpenWallet.Application.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Account> Accounts => Set<Account>();
        public DbSet<AccountCategory> AccountCategories => Set<AccountCategory>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                    "Server=localhost,1433;Database=OpenWalletDB;User Id=sa;Password=MyPassword123;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseAsyncSeeding(async (context, _, ct) =>
            {
                context.Set<AccountCategory>().AddRange(
                    [
                        AccountCategory.CreateSavingsCategory,
                        AccountCategory.CreateInvestmentsCategory,
                        AccountCategory.CreateExpensesCategory,
                        AccountCategory.CreateINcomeCategory
                    ]
                );

                await context.SaveChangesAsync(ct);
            });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
        }
    }
}
