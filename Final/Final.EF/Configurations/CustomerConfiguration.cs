﻿using Final.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.EF.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(customer => customer.Id);
            builder.Property(customer => customer.Id).ValueGeneratedOnAdd();

            builder.Property(customer => customer.Name).HasMaxLength(20);
            builder.Property(customer => customer.Surname).HasMaxLength(20);
            builder.Property(customer => customer.CardNumber).HasMaxLength(20);
            builder.HasIndex(customer => customer.CardNumber).IsUnique();

            builder.HasMany(customer => customer.Transactions).WithOne(transaction => transaction.Customer).HasForeignKey(transaction => transaction.CustomerId);
        }
    }
}
