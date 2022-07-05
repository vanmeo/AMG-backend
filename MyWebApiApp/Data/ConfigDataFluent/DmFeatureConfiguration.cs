using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Data.ConfigDataFluent
{
    public class DmFeatureConfiguration : IEntityTypeConfiguration<DmFeature>
    {
        public void Configure(EntityTypeBuilder<DmFeature> builder)
        {
            builder.HasOne(x => x.App).WithMany(e => e.Features).HasForeignKey(k => k.AppId).HasConstraintName("FK_Feature_App").OnDelete(DeleteBehavior.Restrict);
        }
    }
}