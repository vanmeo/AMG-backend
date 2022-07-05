using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Data.ConfigDataFluent
{
    public class CanboConfiguration : IEntityTypeConfiguration<Canbo>
    {
        public void Configure(EntityTypeBuilder<Canbo> builder)
        {
            builder.HasIndex(x => x.Tendangnhap).IsUnique(true);
            builder.Property(x => x.Status).HasDefaultValue(true);
            builder.HasOne(x => x.Capbac).WithMany(e => e.Canbos).HasForeignKey(k => k.CapbacId).HasConstraintName("FK_Canbo_Capbac").OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Chucvu).WithMany(e => e.Canbos).HasForeignKey(k => k.ChucvuId).HasConstraintName("FK_Canbo_Chucvu").OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Donvi).WithMany(e => e.Canbos).HasForeignKey(k => k.DonviId).HasConstraintName("FK_Canbo_Donvi").OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Role).WithMany(e => e.Canbos).HasForeignKey(k => k.RoleId).HasConstraintName("FK_Canbo_Role").OnDelete(DeleteBehavior.Restrict);
        }
    }
}