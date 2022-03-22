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
    public class ServiceTaskConfiguration : IEntityTypeConfiguration<ServiceTask>
    {
        public void Configure(EntityTypeBuilder<ServiceTask> builder)
        {
            builder.Property(st => st.Code).IsRequired().HasMaxLength(50);
            builder.Property(st => st.Description).IsRequired().HasMaxLength(200);
            builder.Property(st => st.Hours).IsRequired();
        }
    }
}
