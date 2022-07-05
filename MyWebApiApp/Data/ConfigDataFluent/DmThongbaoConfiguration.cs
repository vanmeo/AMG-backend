using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Data.ConfigDataFluent
{
    public class DmThongbaoConfiguration : IEntityTypeConfiguration<DmThongbao>
    {
        public void Configure(EntityTypeBuilder<DmThongbao> builder)
        {
            builder.Property(x=>x.Ngaytao).HasDefaultValueSql("getutcdate()");
            builder.HasOne(x => x.Soquanlykenh).WithMany(e => e.Thongbaos).HasForeignKey(k => k.SoquanlykenhId).HasConstraintName("FK_Thongbao_KenhQL").OnDelete(DeleteBehavior.Restrict);
        }
    }
}