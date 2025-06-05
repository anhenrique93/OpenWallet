using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenWallet.Application.Models;

namespace OpenWallet.Application.Database.Configurations
{
    public class AccountCategoryConfiguration : IEntityTypeConfiguration<AccountCategory>
    {
        public void Configure(EntityTypeBuilder<AccountCategory> builder)
        {
            builder
                .HasKey(accountCategory => accountCategory.Id);

            builder
                .HasMany(category => category.Accounts)
                .WithOne(account => account.Category);

            builder
                .Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}
