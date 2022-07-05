using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Data.ConfigDataFluent
{
    public class DmRole_FeatureConfiguration : IEntityTypeConfiguration<DmRole_Feature>
    {
        public void Configure(EntityTypeBuilder<DmRole_Feature> builder)
        {
            builder.HasOne(x => x.Role).WithMany(e => e.Role_Features).HasForeignKey(k => k.RoleId).HasConstraintName("FK_RoleFeature_Role").OnDelete(DeleteBehavior.Restrict);
        }
    }
}