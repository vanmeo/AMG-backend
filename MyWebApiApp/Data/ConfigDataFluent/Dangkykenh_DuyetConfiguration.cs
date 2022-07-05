using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Data.ConfigDataFluent
{
    public class Dangkykenh_DuyetConfiguration : IEntityTypeConfiguration<Dangkykenh_Duyet>
    {
        public void Configure(EntityTypeBuilder<Dangkykenh_Duyet> builder)
        {
            builder.Property(x => x.NgayTao).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.Ngaysua).HasDefaultValueSql("getutcdate()");
            builder.HasOne(x => x.Ungdung).WithMany(e => e.Dangkykenh_Duyets).HasForeignKey(k => k.UngdungId).HasConstraintName("FK_DKDuyet_Ungdung").OnDelete(DeleteBehavior.NoAction);
            
        }
    }
}