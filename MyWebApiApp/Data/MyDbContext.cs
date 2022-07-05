using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMGAPI.Data.ConfigDataFluent;

namespace AMGAPI.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }


        #region DbSet
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public DbSet<DmCapbac> DmCapbacs { get; set; }
        public DbSet<DmChucvu> DmChucvus { get; set; }
        public DbSet<DmDonvi> DmDonvis { get; set; }
        public DbSet<Canbo> Canbos { get; set; }
        public DbSet<DmApp> DmApps { get; set; }

        public DbSet<DmRole> DmRoles { get; set; }
        public DbSet<DmFeature> DmFeatures { get; set; }
        public DbSet<DmRole_Feature> DmRole_Features { get; set; }
        public DbSet<DmUngdung> DmUngdungs { get; set; }
        public DbSet<ThongsoHethong> ThongsoHethongs { get; set; }
        public DbSet<Dangkykenh> Dangkykenhs { get; set; }
        public DbSet<Dangkykenh_Duyet> Dangkykenh_Duyets { get; set; }
        public DbSet<Soquanlykenh> Soquanlykenhs { get; set; }
        public DbSet<DmThongbao> DmThongbaos { get; set; }
        public DbSet<DmBlackWord> dmBlackWords { get; set; }
        public DbSet<Danhsachnguoidung> Danhsachnguoidungs { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CanboConfiguration());
            modelBuilder.ApplyConfiguration(new DmRole_FeatureConfiguration());
            modelBuilder.ApplyConfiguration(new DmFeatureConfiguration());
            modelBuilder.ApplyConfiguration(new ThongsoHethongConfiguration());
            modelBuilder.ApplyConfiguration(new DangkykenhConfiguration());
            modelBuilder.ApplyConfiguration(new Dangkykenh_DuyetConfiguration());
            modelBuilder.ApplyConfiguration(new SoquanlykenhConfiguration());
            // Seeding data
            SeedData.Seed(modelBuilder);
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseLazyLoadingProxies();

        //    optionsBuilder.EnableSensitiveDataLogging();

        //}
    }
}
