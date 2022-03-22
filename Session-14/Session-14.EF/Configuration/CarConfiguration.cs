using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Session_14.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_14.EF.Configuration
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.Property(c => c.Model).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Brand).IsRequired().HasMaxLength(50);
            builder.Property(c => c.CarRegNumber).IsRequired().HasMaxLength(50);
        }
    }
}
