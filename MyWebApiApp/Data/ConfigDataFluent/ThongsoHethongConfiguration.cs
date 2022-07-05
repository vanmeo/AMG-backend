using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Data.ConfigDataFluent
{
    public class ThongsoHethongConfiguration : IEntityTypeConfiguration<ThongsoHethong>
    {
        public void Configure(EntityTypeBuilder<ThongsoHethong> builder)
        {
            builder.Property(x => x.CreateDate).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.ModifiedDate).HasDefaultValueSql("getutcdate()"); 
        }
    }
}