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
    public class TransactionLineConfiguration : IEntityTypeConfiguration<TransactionLine>
    {
        public void Configure(EntityTypeBuilder<TransactionLine> builder)
        {
            builder.Property(tl => tl.EngineerID).IsRequired();
            builder.Property(tl => tl.TransactionID).IsRequired();
            builder.Property(tl => tl.ServiceTaskID).IsRequired();
        }
    }
}
