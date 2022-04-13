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
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(employee => employee.Id);
            builder.Property(employee => employee.Id).ValueGeneratedOnAdd();

            builder.Property(employee => employee.Name).HasMaxLength(20);
            builder.Property(employee => employee.Surname).HasMaxLength(20);
            builder.Property(employee => employee.SallaryPerMonth).HasPrecision(7, 2);
            builder.Property(employee => employee.EmployeeType).HasConversion(employeeType => employeeType.ToString(), employeeType => (EmployeeType)Enum.Parse(typeof(EmployeeType), employeeType)).HasMaxLength(15);

            builder.HasMany(employee => employee.Transactions).WithOne(transaction => transaction.Employee).HasForeignKey(transaction => transaction.EmployeeId);
        }
    }
}
