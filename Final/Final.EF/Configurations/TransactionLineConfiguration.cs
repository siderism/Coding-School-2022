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
    public class TransactionLineConfiguration : IEntityTypeConfiguration<TransactionLine>
    {
        public void Configure(EntityTypeBuilder<TransactionLine> builder)
        {
            builder.HasKey(transactionLine => transactionLine.Id);
            builder.Property(transactionLine => transactionLine.Id).ValueGeneratedOnAdd();

            builder.Property(transactionLine => transactionLine.Quantity).HasMaxLength(100);
            builder.Property(transactionLine => transactionLine.ItemPrice).HasPrecision(7, 2);
            builder.Property(transactionLine => transactionLine.NetValue).HasPrecision(8, 2);
            builder.Property(transactionLine => transactionLine.DiscountPercent).HasPrecision(3, 2);
            builder.Property(transactionLine => transactionLine.DiscountValue).HasPrecision(8, 2);
            builder.Property(transactionLine => transactionLine.TotalValue).HasPrecision(8, 2);
        }
    }
}
