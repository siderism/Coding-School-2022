using Final.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.EF.Configurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(item => item.Id);
            builder.Property(item => item.Id).ValueGeneratedOnAdd();

            builder.Property(item => item.Code).HasMaxLength(10);
            builder.HasIndex(item => item.Code).IsUnique();
            builder.Property(item => item.Description).HasMaxLength(30);
            builder.Property(item => item.ItemType).HasConversion(itemType => itemType.ToString(), itemType => (ItemType)Enum.Parse(typeof(ItemType), itemType)).HasMaxLength(7);
            builder.Property(item => item.Price).HasPrecision(7, 2);
            builder.Property(item => item.Cost).HasPrecision(8, 2);

            builder.HasMany(item => item.TransactionLines).WithOne(transactionLine => transactionLine.Item).HasForeignKey(transactionLine => transactionLine.ItemId);
        }
    }
}
