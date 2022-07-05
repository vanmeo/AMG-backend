using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Data.ConfigDataFluent
{
    public class DangkykenhConfiguration : IEntityTypeConfiguration<Dangkykenh>
    {
        public void Configure(EntityTypeBuilder<Dangkykenh> builder)
        {
            builder.Property(x => x.Ngaytao).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.Ngaysua).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.Ngaysua).HasDefaultValueSql("getutcdate()");
            builder.HasOne(x => x.Ungdung).WithMany(e => e.Dangkykenhs).HasForeignKey(k => k.UngdungId).HasConstraintName("FK_Dangkykenh_Ungdung").OnDelete(DeleteBehavior.Restrict);
        }
    }
}