using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMGAPI.Data
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DmUngdung>().HasData(
              new DmUngdung() { Id = new Guid("5f606928-41d0-4b2d-a251-56ed76e1dffd"), Ten = "Hệ thông tin CĐ-ĐH", Viettat = "CĐ-ĐH", Ghichu = "CĐ-ĐH", is_Delete = false },
              new DmUngdung() { Id = new Guid("16a5a7df-3f2c-49d9-b5ee-024e2487d7e1"), Ten = "Chỉ đạo ngành", Viettat = "CĐN", Ghichu = "CĐN", is_Delete = false },
              new DmUngdung() { Id = new Guid("538a0883-c18d-40c8-ac53-70a3cc32215b"), Ten = "Quản lý văn bản", Viettat = "QLVB", Ghichu = "QLVB", is_Delete = false }
              );
            modelBuilder.Entity<Dangkykenh>().HasData(
              new Dangkykenh() { Id = new Guid("e0f582de-420f-4902-8cee-cf85389cc6bf"), TenNguoidangky = "Đc Vân", IdDonvi = new Guid("574b452c-b586-499b-d7b9-08da44749b96"), TenUngdung = "CĐ-ĐH", ID_Canbodangky = Guid.Parse("fe3cad63-5187-4f4b-adaa-798ff932b5c4"), IP_Ungdung = "10.10.10.1", Port_Ungdung = 80, UngdungId = Guid.Parse("5f606928-41d0-4b2d-a251-56ed76e1dffd"), Trangthai = 0, Ngaytao = DateTime.UtcNow, Ngaysua = DateTime.UtcNow, is_Delete = false, Ngayduyet = DateTime.UtcNow },
              new Dangkykenh() { Id = new Guid("37f70f55-7dcb-4ca5-b0c8-7466b9cedf3d"), TenNguoidangky = "Đc Minh", IdDonvi = new Guid("574b452c-b586-499b-d7b9-08da44749b96"), TenUngdung = "CĐN", ID_Canbodangky = Guid.Parse("fe3cad63-5187-4f4b-adaa-798ff932b5c4"), IP_Ungdung = "10.10.10.2", Port_Ungdung = 80, UngdungId = Guid.Parse("16a5a7df-3f2c-49d9-b5ee-024e2487d7e1"), Trangthai = 0, Ngaytao = DateTime.UtcNow, Ngaysua = DateTime.UtcNow, is_Delete = false, Ngayduyet = DateTime.UtcNow }
              );
            modelBuilder.Entity<Dangkykenh_Duyet>().HasData(
             new Dangkykenh_Duyet() { Id = new Guid("6746de28-4d95-4a77-96de-c75a8eb80bc4"), TenUngdung = "CĐ-ĐH", IdDonvi = new Guid("574b452c-b586-499b-d7b9-08da44749b96"), ID_Canboduyet = Guid.Parse("fe3cad63-5187-4f4b-adaa-798ff932b5c4"), IP_Internalgate = "10.10.10.0", Port_Internalgate = 80, UngdungId = Guid.Parse("5f606928-41d0-4b2d-a251-56ed76e1dffd"), NgayTao = DateTime.UtcNow, Ngaysua = DateTime.UtcNow, DangkykenhId = Guid.Parse("e0f582de-420f-4902-8cee-cf85389cc6bf"), Canbothamdinh = "Đồng chí A" },
             new Dangkykenh_Duyet() { Id = new Guid("97c3636d-cff0-4b80-b426-dc299e373053"), TenUngdung = "CĐN", IdDonvi = new Guid("574b452c-b586-499b-d7b9-08da44749b96"), ID_Canboduyet = Guid.Parse("fe3cad63-5187-4f4b-adaa-798ff932b5c4"), IP_Internalgate = "10.10.10.0", Port_Internalgate = 80, UngdungId = Guid.Parse("16a5a7df-3f2c-49d9-b5ee-024e2487d7e1"), NgayTao = DateTime.UtcNow, Ngaysua = DateTime.UtcNow, DangkykenhId = Guid.Parse("e0f582de-420f-4902-8cee-cf85389cc6bf"), Canbothamdinh = "Đồng chí A" }
             );
            modelBuilder.Entity<DmThongbao>().HasData(
            new DmThongbao() { Id = new Guid("b079a0b9-50b1-4e54-af26-96f1e6576926"), Noidungtinnhan = "CĐ-ĐH", Sodienthoainhan = "0395248002", SoquanlykenhId = Guid.Parse("565b84a8-792f-4bcc-a701-1c7aae1930f0"), Ngaytao = DateTime.UtcNow },
            new DmThongbao() { Id = new Guid("9b773e21-4ee4-4e50-adc7-1edb42dbcfb1"), Noidungtinnhan = "CĐN", Sodienthoainhan = "0395248002", SoquanlykenhId = Guid.Parse("565b84a8-792f-4bcc-a701-1c7aae1930f0"), Ngaytao = DateTime.UtcNow }
            );
            modelBuilder.Entity<Soquanlykenh>().HasData(
             new Soquanlykenh() { Id = new Guid("565b84a8-792f-4bcc-a701-1c7aae1930f0"), IdDonvi = new Guid("574b452c-b586-499b-d7b9-08da44749b96"), TenUngdung = "CĐ-ĐH", Dangkykenh_DuyetId = Guid.Parse("6746de28-4d95-4a77-96de-c75a8eb80bc4"), IP_Internalgate = "10.10.10.0", Port_Internalgate = 80, UngdungId = Guid.Parse("5f606928-41d0-4b2d-a251-56ed76e1dffd"), IP_Ungdung = "10.10.10.1", Port_Ungdung = 80, Ngaytao = DateTime.UtcNow, Ngaysua = DateTime.UtcNow, Ngayvaoso = DateTime.UtcNow, Trangthai = 0, Ten_Kihieukenh="CDDH" },
             new Soquanlykenh() { Id = new Guid("46988f74-1475-4283-a128-dda4f4b16094"), IdDonvi = new Guid("574b452c-b586-499b-d7b9-08da44749b96"), TenUngdung = "CĐN", Dangkykenh_DuyetId = Guid.Parse("97c3636d-cff0-4b80-b426-dc299e373053"), IP_Internalgate = "10.10.10.0", Port_Internalgate = 80, UngdungId = Guid.Parse("16a5a7df-3f2c-49d9-b5ee-024e2487d7e1"), IP_Ungdung = "10.10.10.2", Port_Ungdung = 80, Ngaytao = DateTime.UtcNow, Ngaysua = DateTime.UtcNow, Ngayvaoso = DateTime.UtcNow, Trangthai = 0, Ten_Kihieukenh = "CDN" }
             );
            modelBuilder.Entity<DmCapbac>().HasData(
               new DmCapbac() { Id = new Guid("3f7eb3c4-28b0-48f4-bda4-08da44746177"), Ten = "Đại úy", Viettat = "4/", Ghichu = "4/", Status = true },
               new DmCapbac() { Id = new Guid("df803dd4-2fac-49a3-5c0c-08da49246d39"), Ten = "Thượng úy", Viettat = "3/", Ghichu = "3/", Status = true },
               new DmCapbac() { Id = new Guid("fe3cad63-5187-4f4b-adaa-798ff932b5c4"), Ten = "Thiếu úy", Viettat = "1/", Ghichu = "1/", Status = true }
               );
            modelBuilder.Entity<DmChucvu>().HasData(
             new DmChucvu() { Id = new Guid("3509de02-52dd-4ba7-e244-08da44747730"), Ten = "Trưởng phòng", Viettat = "TP", Ghichu = "TP", Status = true },
             new DmChucvu() { Id = new Guid("68cf890a-33e7-496a-c46e-08da4475ee1a"), Ten = "Phó Trưởng phòng", Viettat = "PTP", Ghichu = "PTP", Status = true }
             );
            modelBuilder.Entity<DmDonvi>().HasData(
             new DmDonvi() { Id = new Guid("574b452c-b586-499b-d7b9-08da44749b96"), Ma = "V10", Ten = "Viện 10", Viettat = "V10", Ghichu = "Viện 10", Status = true },
             new DmDonvi() { Id = new Guid("07ca1673-4e6c-448e-8f65-a1ef3b65717b"), Ma = "PKH", ParentId = Guid.Parse("574b452c-b586-499b-d7b9-08da44749b96"), Ten = "PKH", Viettat = "PKH", Ghichu = "PKH", Status = true }
             );
            modelBuilder.Entity<DmRole>().HasData(
            new DmRole() { Id = new Guid("830da2e4-c293-4026-b2e6-29ad8c935def"), Ten = "Administrator", is_Delete = false, Ghichu = "Quản trị hệ thống" },
            new DmRole() { Id = new Guid("dde7744a-c33f-4b37-a89a-b99fa576fc5c"), Ten = "User", is_Delete = false, Ghichu = "Người dùng hệ thống" }
            );
            modelBuilder.Entity<DmApp>().HasData(
          new DmApp() { Id = new Guid("e680169e-7c1c-4be3-8158-4146ddc1c587"), Ten = "Quản trị danh mục", is_Delete = false, Viettat = "QLDM", Ghichu = "Quản trị danh mục" },
          new DmApp() { Id = new Guid("c00464fc-ea88-428b-8904-25fa4afc07d5"), Ten = "Quản lý kênh", is_Delete = false, Viettat = "QLKenh", Ghichu = "Đăng ký kênh" },
           new DmApp() { Id = new Guid("3efbe184-cf3b-4afc-936c-bdf5f3784615"), Ten = "Hệ thống", is_Delete = false, Viettat = "Hệ thống", Ghichu = "Hệ thống" }
          );
            modelBuilder.Entity<DmFeature>().HasData(
           //Admin -Danh mục
           new DmFeature() { Id = new Guid("dde7744a-c33f-4b37-a89a-b99fa576fc5c"), AppId = Guid.Parse("e680169e-7c1c-4be3-8158-4146ddc1c587"), Ten = "Capbac", is_Delete = false },
           new DmFeature() { Id = new Guid("f527444e-9e28-4ea2-adce-c0c9c80a8531"), AppId = Guid.Parse("e680169e-7c1c-4be3-8158-4146ddc1c587"), Ten = "Chucvu", is_Delete = false },
           new DmFeature() { Id = new Guid("5267b5e2-ce19-465f-ad2d-9557e70aeeae"), AppId = Guid.Parse("e680169e-7c1c-4be3-8158-4146ddc1c587"), Ten = "Donvi", is_Delete = false },
           new DmFeature() { Id = new Guid("8b40b1e3-7e78-4fb4-9d7e-361a68e6a866"), AppId = Guid.Parse("e680169e-7c1c-4be3-8158-4146ddc1c587"), Ten = "Canbo", is_Delete = false },
           //Admin-QLKenh
           new DmFeature() { Id = new Guid("de976e05-5749-44c2-ba10-057e2aff7881"), AppId = Guid.Parse("c00464fc-ea88-428b-8904-25fa4afc07d5"), Ten = "Dangkykenh", is_Delete = false },
           new DmFeature() { Id = new Guid("b41759f2-2d93-419b-b527-095269951534"), AppId = Guid.Parse("c00464fc-ea88-428b-8904-25fa4afc07d5"), Ten = "Dangkykenh_Duyet", is_Delete = false },
           new DmFeature() { Id = new Guid("3e062997-8d32-454b-8f56-874ca6fc0b82"), AppId = Guid.Parse("c00464fc-ea88-428b-8904-25fa4afc07d5"), Ten = "Soquanlykenh", is_Delete = false },
            //Admin-Thamsohethong
           new DmFeature() { Id = new Guid("f42719ed-dd92-4c46-9ac3-c85ffd192c69"), AppId = Guid.Parse("3efbe184-cf3b-4afc-936c-bdf5f3784615"), Ten = "Thongsohethong", is_Delete = false },
           new DmFeature() { Id = new Guid("90937fa7-9ac9-44e6-8aad-1cb9f73aa4c7"), AppId = Guid.Parse("3efbe184-cf3b-4afc-936c-bdf5f3784615"), Ten = "DmBlackWord", is_Delete = false }
           );
            modelBuilder.Entity<DmRole_Feature>().HasData(
                //Admin-Capbac
        new DmRole_Feature() { Id = new Guid("7a90068f-2c2d-4d44-8ccf-e04b88d5d51e"), RoleId = Guid.Parse("830da2e4-c293-4026-b2e6-29ad8c935def"), FeatureId = Guid.Parse("dde7744a-c33f-4b37-a89a-b99fa576fc5c"), is_Delete = false, AllowAdd = true, AllowDelete = true, AllowEdit = true, AllowView = true, AllowDuyet = true },
        //Admin-Chucvu
        new DmRole_Feature() { Id = new Guid("93651816-67d0-4e0d-86a9-50d22899cb1d"), RoleId = Guid.Parse("830da2e4-c293-4026-b2e6-29ad8c935def"), FeatureId = Guid.Parse("f527444e-9e28-4ea2-adce-c0c9c80a8531"), is_Delete = false, AllowAdd = true, AllowDelete = true, AllowEdit = true, AllowView = true, AllowDuyet = true },
        //Admin-Donvi
        new DmRole_Feature() { Id = new Guid("8633caac-e41c-4c4c-9c4a-b1ed2e960bf8"), RoleId = Guid.Parse("830da2e4-c293-4026-b2e6-29ad8c935def"), FeatureId = Guid.Parse("5267b5e2-ce19-465f-ad2d-9557e70aeeae"), is_Delete = false, AllowAdd = true, AllowDelete = true, AllowEdit = true, AllowView = true, AllowDuyet = true },
        //Admin-Canbo
        new DmRole_Feature() { Id = new Guid("1f5cf7a4-b4ac-4620-9c3e-51644548151b"), RoleId = Guid.Parse("830da2e4-c293-4026-b2e6-29ad8c935def"), FeatureId = Guid.Parse("8b40b1e3-7e78-4fb4-9d7e-361a68e6a866"), is_Delete = false, AllowAdd = true, AllowDelete = true, AllowEdit = true, AllowView = true, AllowDuyet = true },
        //Admin-Soquanlykenh
         new DmRole_Feature() { Id = new Guid("b5b9fcc6-1bb8-4576-982b-530d3429861c"), RoleId = Guid.Parse("830da2e4-c293-4026-b2e6-29ad8c935def"), FeatureId = Guid.Parse("3e062997-8d32-454b-8f56-874ca6fc0b82"), is_Delete = false, AllowAdd = true, AllowDelete = true, AllowEdit = true, AllowView = true, AllowDuyet = true },
          //Admin-Thongsohethong
          new DmRole_Feature() { Id = new Guid("cf82e238-aef6-4145-8674-73fa21be5c1d"), RoleId = Guid.Parse("830da2e4-c293-4026-b2e6-29ad8c935def"), FeatureId = Guid.Parse("f42719ed-dd92-4c46-9ac3-c85ffd192c69"), is_Delete = false, AllowAdd = true, AllowDelete = true, AllowEdit = true, AllowView = true, AllowDuyet = true },
          //Admin-DmBlackWord
          new DmRole_Feature() { Id = new Guid("6e7cc4c4-a3c6-42cc-9772-2e83abdc18b3"), RoleId = Guid.Parse("830da2e4-c293-4026-b2e6-29ad8c935def"), FeatureId = Guid.Parse("90937fa7-9ac9-44e6-8aad-1cb9f73aa4c7"), is_Delete = false, AllowAdd = true, AllowDelete = true, AllowEdit = true, AllowView = true, AllowDuyet = true },
          //Admin-Dangkykenh_Duyet
          new DmRole_Feature() { Id = new Guid("9e87e047-2c57-4e40-8b69-ae478861f07a"), RoleId = Guid.Parse("830da2e4-c293-4026-b2e6-29ad8c935def"), FeatureId = Guid.Parse("b41759f2-2d93-419b-b527-095269951534"), is_Delete = false, AllowAdd = true, AllowDelete = true, AllowEdit = true, AllowView = true, AllowDuyet = true },
          //Admin- Dangkykenh
          new DmRole_Feature() { Id = new Guid("17f71279-793d-4b2a-a12c-a9f4013bb779"), RoleId = Guid.Parse("830da2e4-c293-4026-b2e6-29ad8c935def"), FeatureId = Guid.Parse("de976e05-5749-44c2-ba10-057e2aff7881"), is_Delete = false, AllowAdd = true, AllowDelete = true, AllowEdit = true, AllowView = true, AllowDuyet = true }



        );
            modelBuilder.Entity<Canbo>().HasData(
           new Canbo() { Id = new Guid("fe3cad63-5187-4f4b-adaa-798ff932b5c4"), Tendangnhap = "admin", Matkhau = "1", Tendaydu = "Admin", Dienthoai_mobile = "0123456789", CapbacId = Guid.Parse("3f7eb3c4-28b0-48f4-bda4-08da44746177"), ChucvuId = Guid.Parse("3509de02-52dd-4ba7-e244-08da44747730"), DonviId = Guid.Parse("07ca1673-4e6c-448e-8f65-a1ef3b65717b"), RoleId = Guid.Parse("830da2e4-c293-4026-b2e6-29ad8c935def") }
           );
            modelBuilder.Entity<ThongsoHethong>().HasData(
          new ThongsoHethong() { Id = new Guid("9645cf84-11af-485f-8b90-fd34f3d7f26a"), TansuatQuet_Phut = 10, TanSuatXoanhatky_ngay = 1, Datadiode_IP = "1.1.1.1", Datadiode_Port = 5033, Datadiode_Token = "123", KichthuocFilesMax = 1, CreateDate = DateTime.UtcNow, ModifiedDate=DateTime.UtcNow}
          );


        }
    }
}