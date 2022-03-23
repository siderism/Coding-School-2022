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
    public class EngineerConfiguration : IEntityTypeConfiguration<Engineer>
    {
        public void Configure(EntityTypeBuilder<Engineer> builder)
        {
            builder.HasKey(e => e.ID);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Surname).IsRequired().HasMaxLength(50);
            builder.Property(e => e.SallaryPerMonth).IsRequired();
            builder.Property(e => e.ManagerID).IsRequired();
            builder.Property(e => e.Status).IsRequired();
        }
    }
}
