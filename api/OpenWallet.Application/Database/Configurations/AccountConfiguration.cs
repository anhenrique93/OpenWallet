using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenWallet.Application.Models;

namespace OpenWallet.Application.Database.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder
                .HasKey(account => account.Id);

            builder
                .HasOne(account => account.Category) // Account has one Category
                .WithMany(category => category.Accounts) // Category has many Accounts
                .HasPrincipalKey(category => category.Id) // Principal key in Category
                .HasForeignKey(account => account.CategoryId); // Category Foreign key in Account

            builder
                .Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(128);

            builder
                .Property(a => a.Description)
                .IsRequired()
                .HasMaxLength(1000);

            builder
                .OwnsOne(a => a.Money)
                .OwnsOne(m => m.Currency);
        }
    }
}
