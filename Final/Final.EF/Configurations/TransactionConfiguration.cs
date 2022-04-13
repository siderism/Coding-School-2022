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
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(transaction => transaction.Id);
            builder.Property(transaction => transaction.Id).ValueGeneratedOnAdd();
            builder.Property(transaction => transaction.EmployeeId).HasMaxLength(10);
            builder.Property(transaction => transaction.CustomerId).HasMaxLength(10);
            builder.Property(transaction => transaction.Date);
            builder.Property(transaction => transaction.PaymentMethod);
            builder.Property(transaction => transaction.TotalValue).HasPrecision(18, 2);
            builder.Property(transaction => transaction.PaymentMethod).HasConversion(paymentMethod => paymentMethod.ToString(), paymentMethod => (PaymentMethod)Enum.Parse(typeof(PaymentMethod), paymentMethod)).HasMaxLength(15);

            builder.HasMany(transaction => transaction.TransactionLines).WithOne(transactionLine => transactionLine.Transaction)
                .HasForeignKey(transactionLine => transactionLine.TransactionId);

        }
    }
}
