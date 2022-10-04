using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Data.ConfigDataFluent
{
    public class SoquanlykenhConfiguration : IEntityTypeConfiguration<Soquanlykenh>
    {
        public void Configure(EntityTypeBuilder<Soquanlykenh> builder)
        {
            builder.Property(x => x.Ngaytao).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.Ngaysua).HasDefaultValueSql("getutcdate()");
            builder.HasIndex(x => x.Ten_Kihieukenh).IsUnique();
            builder.HasOne(x => x.Ungdung).WithMany(e => e.Soquanlykenhs).HasForeignKey(k => k.UngdungId).HasConstraintName("FK_SoQLKenh_Ungdung").OnDelete(DeleteBehavior.NoAction);
           

        }
    }
}