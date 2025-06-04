using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenWallet.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace OpenWallet.Application.Database.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder
                .HasKey(account => account.Id);       

            builder
                .OwnsOne(a => a.Type);

            builder
                .Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(128);

            builder
                .Property(a => a.Description)
                .IsRequired()
                .HasMaxLength(1150);

            builder
                .OwnsOne(a => a.Money)
                .OwnsOne(m => m.Currency);
        }
    }
}
