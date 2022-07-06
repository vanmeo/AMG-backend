using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AMGAPI.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DmApp",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Viettat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ghichu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    is_Delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmApp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DmBlackWord",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Word = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ngaytao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ngaysua = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmBlackWord", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DmCapbac",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Viettat = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ghichu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmCapbac", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DmChucvu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Viettat = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Ghichu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmChucvu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DmDonvi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Ma = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Viettat = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Ghichu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmDonvi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DmRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ghichu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_Delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DmUngdung",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Viettat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ghichu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    is_Delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmUngdung", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThongsoHethong",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TansuatQuet_Phut = table.Column<int>(type: "int", nullable: false),
                    Datadiode_IP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Datadiode_Port = table.Column<int>(type: "int", nullable: false),
                    Datadiode_Token = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TanSuatXoanhatky_ngay = table.Column<byte>(type: "tinyint", nullable: false),
                    KichthuocFilesMax = table.Column<byte>(type: "tinyint", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongsoHethong", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DmFeature",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Viettat = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Ghichu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    is_Delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmFeature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feature_App",
                        column: x => x.AppId,
                        principalTable: "DmApp",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Canbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tendaydu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Tendangnhap = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Matkhau = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Dienthoai_mobile = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Dienthoai_cd1 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Dienthoai_cd2 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Dienthoai_cd3 = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Ngaysinh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Anhdaidien_ten = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Anhdaidien_url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DonviId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChucvuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CapbacId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Publickey_value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Publickey_status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Canbo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Canbo_Capbac",
                        column: x => x.CapbacId,
                        principalTable: "DmCapbac",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Canbo_Chucvu",
                        column: x => x.ChucvuId,
                        principalTable: "DmChucvu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Canbo_Donvi",
                        column: x => x.DonviId,
                        principalTable: "DmDonvi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Canbo_Role",
                        column: x => x.RoleId,
                        principalTable: "DmRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DmRole_Feature",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FeatureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AllowView = table.Column<bool>(type: "bit", nullable: false),
                    AllowEdit = table.Column<bool>(type: "bit", nullable: false),
                    AllowDelete = table.Column<bool>(type: "bit", nullable: false),
                    AllowAdd = table.Column<bool>(type: "bit", nullable: false),
                    AllowDuyet = table.Column<bool>(type: "bit", nullable: false),
                    is_Delete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmRole_Feature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DmRole_Feature_DmFeature_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "DmFeature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleFeature_Role",
                        column: x => x.RoleId,
                        principalTable: "DmRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dangkykenh",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenNguoidangky = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TenDonvi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TenUngdung = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UngdungId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IP_Ungdung = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Port_Ungdung = table.Column<int>(type: "int", nullable: false),
                    ID_Canbodangky = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ngaytao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    Ngaysua = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    Trangthai = table.Column<int>(type: "int", nullable: false),
                    Ngayduyet = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Log_process = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_Delete = table.Column<bool>(type: "bit", nullable: false),
                    CanboDangkyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dangkykenh", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dangkykenh_Canbo_CanboDangkyId",
                        column: x => x.CanboDangkyId,
                        principalTable: "Canbo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dangkykenh_Ungdung",
                        column: x => x.UngdungId,
                        principalTable: "DmUngdung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JwtId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false),
                    IssuedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiredAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_Canbo_UserId",
                        column: x => x.UserId,
                        principalTable: "Canbo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dangkykenh_Duyet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DangkykenhId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenUngdung = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UngdungId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IP_Internalgate = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Port_Internalgate = table.Column<int>(type: "int", nullable: false),
                    Canbothamdinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID_Canboduyet = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    Ngaysua = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    is_Delete = table.Column<bool>(type: "bit", nullable: false),
                    Trangthai = table.Column<bool>(type: "bit", nullable: false),
                    Log_process = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dangkykenh_Duyet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dangkykenh_Duyet_Canbo_ID_Canboduyet",
                        column: x => x.ID_Canboduyet,
                        principalTable: "Canbo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dangkykenh_Duyet_Dangkykenh_DangkykenhId",
                        column: x => x.DangkykenhId,
                        principalTable: "Dangkykenh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DKDuyet_Ungdung",
                        column: x => x.UngdungId,
                        principalTable: "DmUngdung",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Soquanlykenh",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Dangkykenh_DuyetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenUngdung = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UngdungId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CanboId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IP_Internalgate = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Port_Internalgate = table.Column<int>(type: "int", nullable: false),
                    IP_Ungdung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Port_Ungdung = table.Column<int>(type: "int", nullable: false),
                    Ngayvaoso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Trangthai = table.Column<int>(type: "int", nullable: false),
                    Ngaytao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    Ngaysua = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    is_Delete = table.Column<bool>(type: "bit", nullable: false),
                    Log_process = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Soquanlykenh", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoQLKenh_Ungdung",
                        column: x => x.UngdungId,
                        principalTable: "DmUngdung",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Soquanlykenh_Dangkykenh_Duyet_Dangkykenh_DuyetId",
                        column: x => x.Dangkykenh_DuyetId,
                        principalTable: "Dangkykenh_Duyet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Danhsachnguoidung",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sodienthoai = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SokenhId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CanboId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ngaytao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ngaysua = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Danhsachnguoidung", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Danhsachnguoidung_Canbo_CanboId",
                        column: x => x.CanboId,
                        principalTable: "Canbo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Danhsachnguoidung_Soquanlykenh_SokenhId",
                        column: x => x.SokenhId,
                        principalTable: "Soquanlykenh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DmThongbao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoquanlykenhId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Noidungtinnhan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sodienthoainhan = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Ngaytao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmThongbao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DmThongbao_Soquanlykenh_SoquanlykenhId",
                        column: x => x.SoquanlykenhId,
                        principalTable: "Soquanlykenh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DmApp",
                columns: new[] { "Id", "Ghichu", "Ten", "Viettat", "is_Delete" },
                values: new object[,]
                {
                    { new Guid("e680169e-7c1c-4be3-8158-4146ddc1c587"), "Quản trị danh mục", "Quản trị danh mục", "QLDM", false },
                    { new Guid("c00464fc-ea88-428b-8904-25fa4afc07d5"), "Đăng ký kênh", "Quản lý kênh", "QLKenh", false },
                    { new Guid("3efbe184-cf3b-4afc-936c-bdf5f3784615"), "Hệ thống", "Hệ thống", "Hệ thống", false }
                });

            migrationBuilder.InsertData(
                table: "DmCapbac",
                columns: new[] { "Id", "Ghichu", "Status", "Ten", "Viettat" },
                values: new object[,]
                {
                    { new Guid("3f7eb3c4-28b0-48f4-bda4-08da44746177"), "4/", true, "Đại úy", "4/" },
                    { new Guid("df803dd4-2fac-49a3-5c0c-08da49246d39"), "3/", true, "Thượng úy", "3/" },
                    { new Guid("fe3cad63-5187-4f4b-adaa-798ff932b5c4"), "1/", true, "Thiếu úy", "1/" }
                });

            migrationBuilder.InsertData(
                table: "DmChucvu",
                columns: new[] { "Id", "Ghichu", "Status", "Ten", "Viettat" },
                values: new object[,]
                {
                    { new Guid("3509de02-52dd-4ba7-e244-08da44747730"), "TP", true, "Trưởng phòng", "TP" },
                    { new Guid("68cf890a-33e7-496a-c46e-08da4475ee1a"), "PTP", true, "Phó Trưởng phòng", "PTP" }
                });

            migrationBuilder.InsertData(
                table: "DmDonvi",
                columns: new[] { "Id", "Ghichu", "Ma", "ParentId", "Status", "Ten", "Viettat" },
                values: new object[,]
                {
                    { new Guid("574b452c-b586-499b-d7b9-08da44749b96"), "Viện 10", "V10", null, true, "Viện 10", "V10" },
                    { new Guid("07ca1673-4e6c-448e-8f65-a1ef3b65717b"), "PKH", "PKH", new Guid("574b452c-b586-499b-d7b9-08da44749b96"), true, "PKH", "PKH" }
                });

            migrationBuilder.InsertData(
                table: "DmRole",
                columns: new[] { "Id", "Ghichu", "Ten", "is_Delete" },
                values: new object[,]
                {
                    { new Guid("830da2e4-c293-4026-b2e6-29ad8c935def"), "Quản trị hệ thống", "Administrator", false },
                    { new Guid("dde7744a-c33f-4b37-a89a-b99fa576fc5c"), "Người dùng hệ thống", "User", false }
                });

            migrationBuilder.InsertData(
                table: "DmUngdung",
                columns: new[] { "Id", "Ghichu", "Ten", "Viettat", "is_Delete" },
                values: new object[,]
                {
                    { new Guid("5f606928-41d0-4b2d-a251-56ed76e1dffd"), "CĐ-ĐH", "Hệ thông tin CĐ-ĐH", "CĐ-ĐH", false },
                    { new Guid("16a5a7df-3f2c-49d9-b5ee-024e2487d7e1"), "CĐN", "Chỉ đạo ngành", "CĐN", false },
                    { new Guid("538a0883-c18d-40c8-ac53-70a3cc32215b"), "QLVB", "Quản lý văn bản", "QLVB", false }
                });

            migrationBuilder.InsertData(
                table: "ThongsoHethong",
                columns: new[] { "Id", "CreateDate", "Datadiode_IP", "Datadiode_Port", "Datadiode_Token", "KichthuocFilesMax", "ModifiedDate", "TanSuatXoanhatky_ngay", "TansuatQuet_Phut" },
                values: new object[] { new Guid("9645cf84-11af-485f-8b90-fd34f3d7f26a"), new DateTime(2022, 7, 6, 2, 27, 38, 696, DateTimeKind.Utc).AddTicks(2786), "1.1.1.1", 5033, "123", (byte)1, new DateTime(2022, 7, 6, 2, 27, 38, 696, DateTimeKind.Utc).AddTicks(3020), (byte)1, 10 });

            migrationBuilder.InsertData(
                table: "Canbo",
                columns: new[] { "Id", "Anhdaidien_ten", "Anhdaidien_url", "CapbacId", "ChucvuId", "Dienthoai_cd1", "Dienthoai_cd2", "Dienthoai_cd3", "Dienthoai_mobile", "DonviId", "Email", "Matkhau", "Ngaysinh", "Publickey_status", "Publickey_value", "RoleId", "Tendangnhap", "Tendaydu" },
                values: new object[] { new Guid("fe3cad63-5187-4f4b-adaa-798ff932b5c4"), null, null, new Guid("3f7eb3c4-28b0-48f4-bda4-08da44746177"), new Guid("3509de02-52dd-4ba7-e244-08da44747730"), null, null, null, "0123456789", new Guid("07ca1673-4e6c-448e-8f65-a1ef3b65717b"), null, "1", null, false, null, new Guid("830da2e4-c293-4026-b2e6-29ad8c935def"), "admin", "Admin" });

            migrationBuilder.InsertData(
                table: "Dangkykenh",
                columns: new[] { "Id", "CanboDangkyId", "ID_Canbodangky", "IP_Ungdung", "Log_process", "Ngayduyet", "Ngaysua", "Ngaytao", "Port_Ungdung", "TenDonvi", "TenNguoidangky", "TenUngdung", "Trangthai", "UngdungId", "is_Delete" },
                values: new object[,]
                {
                    { new Guid("e0f582de-420f-4902-8cee-cf85389cc6bf"), null, new Guid("fe3cad63-5187-4f4b-adaa-798ff932b5c4"), "10.10.10.1", null, new DateTime(2022, 7, 6, 2, 27, 38, 693, DateTimeKind.Utc).AddTicks(3246), new DateTime(2022, 7, 6, 2, 27, 38, 693, DateTimeKind.Utc).AddTicks(2815), new DateTime(2022, 7, 6, 2, 27, 38, 693, DateTimeKind.Utc).AddTicks(2573), 80, "V10", "Đc Vân", "CĐ-ĐH", 0, new Guid("5f606928-41d0-4b2d-a251-56ed76e1dffd"), false },
                    { new Guid("37f70f55-7dcb-4ca5-b0c8-7466b9cedf3d"), null, new Guid("fe3cad63-5187-4f4b-adaa-798ff932b5c4"), "10.10.10.2", null, new DateTime(2022, 7, 6, 2, 27, 38, 693, DateTimeKind.Utc).AddTicks(3819), new DateTime(2022, 7, 6, 2, 27, 38, 693, DateTimeKind.Utc).AddTicks(3818), new DateTime(2022, 7, 6, 2, 27, 38, 693, DateTimeKind.Utc).AddTicks(3815), 80, "V10", "Đc Minh", "CĐN", 0, new Guid("16a5a7df-3f2c-49d9-b5ee-024e2487d7e1"), false }
                });

            migrationBuilder.InsertData(
                table: "DmFeature",
                columns: new[] { "Id", "AppId", "Ghichu", "Ten", "Viettat", "is_Delete" },
                values: new object[,]
                {
                    { new Guid("dde7744a-c33f-4b37-a89a-b99fa576fc5c"), new Guid("e680169e-7c1c-4be3-8158-4146ddc1c587"), null, "Capbac", null, false },
                    { new Guid("f527444e-9e28-4ea2-adce-c0c9c80a8531"), new Guid("e680169e-7c1c-4be3-8158-4146ddc1c587"), null, "Chucvu", null, false },
                    { new Guid("5267b5e2-ce19-465f-ad2d-9557e70aeeae"), new Guid("e680169e-7c1c-4be3-8158-4146ddc1c587"), null, "Donvi", null, false },
                    { new Guid("8b40b1e3-7e78-4fb4-9d7e-361a68e6a866"), new Guid("e680169e-7c1c-4be3-8158-4146ddc1c587"), null, "Canbo", null, false },
                    { new Guid("de976e05-5749-44c2-ba10-057e2aff7881"), new Guid("c00464fc-ea88-428b-8904-25fa4afc07d5"), null, "Dangkykenh", null, false },
                    { new Guid("b41759f2-2d93-419b-b527-095269951534"), new Guid("c00464fc-ea88-428b-8904-25fa4afc07d5"), null, "Dangkykenh_Duyet", null, false },
                    { new Guid("3e062997-8d32-454b-8f56-874ca6fc0b82"), new Guid("c00464fc-ea88-428b-8904-25fa4afc07d5"), null, "Soquanlykenh", null, false },
                    { new Guid("f42719ed-dd92-4c46-9ac3-c85ffd192c69"), new Guid("3efbe184-cf3b-4afc-936c-bdf5f3784615"), null, "Thongsohethong", null, false },
                    { new Guid("90937fa7-9ac9-44e6-8aad-1cb9f73aa4c7"), new Guid("3efbe184-cf3b-4afc-936c-bdf5f3784615"), null, "DmBlackWord", null, false }
                });

            migrationBuilder.InsertData(
                table: "Dangkykenh_Duyet",
                columns: new[] { "Id", "Canbothamdinh", "DangkykenhId", "ID_Canboduyet", "IP_Internalgate", "Log_process", "NgayTao", "Ngaysua", "Port_Internalgate", "TenUngdung", "Trangthai", "UngdungId", "is_Delete" },
                values: new object[,]
                {
                    { new Guid("6746de28-4d95-4a77-96de-c75a8eb80bc4"), "Đồng chí A", new Guid("e0f582de-420f-4902-8cee-cf85389cc6bf"), new Guid("fe3cad63-5187-4f4b-adaa-798ff932b5c4"), "10.10.10.0", null, new DateTime(2022, 7, 6, 2, 27, 38, 693, DateTimeKind.Utc).AddTicks(6176), new DateTime(2022, 7, 6, 2, 27, 38, 693, DateTimeKind.Utc).AddTicks(6414), 80, "CĐ-ĐH", false, new Guid("5f606928-41d0-4b2d-a251-56ed76e1dffd"), false },
                    { new Guid("97c3636d-cff0-4b80-b426-dc299e373053"), "Đồng chí A", new Guid("e0f582de-420f-4902-8cee-cf85389cc6bf"), new Guid("fe3cad63-5187-4f4b-adaa-798ff932b5c4"), "10.10.10.0", null, new DateTime(2022, 7, 6, 2, 27, 38, 693, DateTimeKind.Utc).AddTicks(7116), new DateTime(2022, 7, 6, 2, 27, 38, 693, DateTimeKind.Utc).AddTicks(7117), 80, "CĐN", false, new Guid("16a5a7df-3f2c-49d9-b5ee-024e2487d7e1"), false }
                });

            migrationBuilder.InsertData(
                table: "DmRole_Feature",
                columns: new[] { "Id", "AllowAdd", "AllowDelete", "AllowDuyet", "AllowEdit", "AllowView", "FeatureId", "RoleId", "is_Delete" },
                values: new object[,]
                {
                    { new Guid("7a90068f-2c2d-4d44-8ccf-e04b88d5d51e"), true, true, true, true, true, new Guid("dde7744a-c33f-4b37-a89a-b99fa576fc5c"), new Guid("830da2e4-c293-4026-b2e6-29ad8c935def"), false },
                    { new Guid("93651816-67d0-4e0d-86a9-50d22899cb1d"), true, true, true, true, true, new Guid("f527444e-9e28-4ea2-adce-c0c9c80a8531"), new Guid("830da2e4-c293-4026-b2e6-29ad8c935def"), false },
                    { new Guid("8633caac-e41c-4c4c-9c4a-b1ed2e960bf8"), true, true, true, true, true, new Guid("5267b5e2-ce19-465f-ad2d-9557e70aeeae"), new Guid("830da2e4-c293-4026-b2e6-29ad8c935def"), false },
                    { new Guid("1f5cf7a4-b4ac-4620-9c3e-51644548151b"), true, true, true, true, true, new Guid("8b40b1e3-7e78-4fb4-9d7e-361a68e6a866"), new Guid("830da2e4-c293-4026-b2e6-29ad8c935def"), false },
                    { new Guid("17f71279-793d-4b2a-a12c-a9f4013bb779"), true, true, true, true, true, new Guid("de976e05-5749-44c2-ba10-057e2aff7881"), new Guid("830da2e4-c293-4026-b2e6-29ad8c935def"), false },
                    { new Guid("9e87e047-2c57-4e40-8b69-ae478861f07a"), true, true, true, true, true, new Guid("b41759f2-2d93-419b-b527-095269951534"), new Guid("830da2e4-c293-4026-b2e6-29ad8c935def"), false },
                    { new Guid("b5b9fcc6-1bb8-4576-982b-530d3429861c"), true, true, true, true, true, new Guid("3e062997-8d32-454b-8f56-874ca6fc0b82"), new Guid("830da2e4-c293-4026-b2e6-29ad8c935def"), false },
                    { new Guid("cf82e238-aef6-4145-8674-73fa21be5c1d"), true, true, true, true, true, new Guid("f42719ed-dd92-4c46-9ac3-c85ffd192c69"), new Guid("830da2e4-c293-4026-b2e6-29ad8c935def"), false },
                    { new Guid("6e7cc4c4-a3c6-42cc-9772-2e83abdc18b3"), true, true, true, true, true, new Guid("90937fa7-9ac9-44e6-8aad-1cb9f73aa4c7"), new Guid("830da2e4-c293-4026-b2e6-29ad8c935def"), false }
                });

            migrationBuilder.InsertData(
                table: "Soquanlykenh",
                columns: new[] { "Id", "CanboId", "Dangkykenh_DuyetId", "IP_Internalgate", "IP_Ungdung", "Log_process", "Ngaysua", "Ngaytao", "Ngayvaoso", "Port_Internalgate", "Port_Ungdung", "TenUngdung", "Trangthai", "UngdungId", "is_Delete" },
                values: new object[] { new Guid("565b84a8-792f-4bcc-a701-1c7aae1930f0"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("6746de28-4d95-4a77-96de-c75a8eb80bc4"), "10.10.10.0", "10.10.10.1", null, new DateTime(2022, 7, 6, 2, 27, 38, 694, DateTimeKind.Utc).AddTicks(1210), new DateTime(2022, 7, 6, 2, 27, 38, 694, DateTimeKind.Utc).AddTicks(985), new DateTime(2022, 7, 6, 2, 27, 38, 694, DateTimeKind.Utc).AddTicks(1429), 80, 80, "CĐ-ĐH", 0, new Guid("5f606928-41d0-4b2d-a251-56ed76e1dffd"), false });

            migrationBuilder.InsertData(
                table: "Soquanlykenh",
                columns: new[] { "Id", "CanboId", "Dangkykenh_DuyetId", "IP_Internalgate", "IP_Ungdung", "Log_process", "Ngaysua", "Ngaytao", "Ngayvaoso", "Port_Internalgate", "Port_Ungdung", "TenUngdung", "Trangthai", "UngdungId", "is_Delete" },
                values: new object[] { new Guid("46988f74-1475-4283-a128-dda4f4b16094"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("97c3636d-cff0-4b80-b426-dc299e373053"), "10.10.10.0", "10.10.10.2", null, new DateTime(2022, 7, 6, 2, 27, 38, 694, DateTimeKind.Utc).AddTicks(1856), new DateTime(2022, 7, 6, 2, 27, 38, 694, DateTimeKind.Utc).AddTicks(1854), new DateTime(2022, 7, 6, 2, 27, 38, 694, DateTimeKind.Utc).AddTicks(1857), 80, 80, "CĐN", 0, new Guid("16a5a7df-3f2c-49d9-b5ee-024e2487d7e1"), false });

            migrationBuilder.InsertData(
                table: "DmThongbao",
                columns: new[] { "Id", "Ngaytao", "Noidungtinnhan", "Sodienthoainhan", "SoquanlykenhId" },
                values: new object[] { new Guid("b079a0b9-50b1-4e54-af26-96f1e6576926"), new DateTime(2022, 7, 6, 2, 27, 38, 693, DateTimeKind.Utc).AddTicks(8556), "CĐ-ĐH", "0395248002", new Guid("565b84a8-792f-4bcc-a701-1c7aae1930f0") });

            migrationBuilder.InsertData(
                table: "DmThongbao",
                columns: new[] { "Id", "Ngaytao", "Noidungtinnhan", "Sodienthoainhan", "SoquanlykenhId" },
                values: new object[] { new Guid("9b773e21-4ee4-4e50-adc7-1edb42dbcfb1"), new DateTime(2022, 7, 6, 2, 27, 38, 693, DateTimeKind.Utc).AddTicks(8797), "CĐN", "0395248002", new Guid("565b84a8-792f-4bcc-a701-1c7aae1930f0") });

            migrationBuilder.CreateIndex(
                name: "IX_Canbo_CapbacId",
                table: "Canbo",
                column: "CapbacId");

            migrationBuilder.CreateIndex(
                name: "IX_Canbo_ChucvuId",
                table: "Canbo",
                column: "ChucvuId");

            migrationBuilder.CreateIndex(
                name: "IX_Canbo_DonviId",
                table: "Canbo",
                column: "DonviId");

            migrationBuilder.CreateIndex(
                name: "IX_Canbo_RoleId",
                table: "Canbo",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Canbo_Tendangnhap",
                table: "Canbo",
                column: "Tendangnhap",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dangkykenh_CanboDangkyId",
                table: "Dangkykenh",
                column: "CanboDangkyId");

            migrationBuilder.CreateIndex(
                name: "IX_Dangkykenh_UngdungId",
                table: "Dangkykenh",
                column: "UngdungId");

            migrationBuilder.CreateIndex(
                name: "IX_Dangkykenh_Duyet_DangkykenhId",
                table: "Dangkykenh_Duyet",
                column: "DangkykenhId");

            migrationBuilder.CreateIndex(
                name: "IX_Dangkykenh_Duyet_ID_Canboduyet",
                table: "Dangkykenh_Duyet",
                column: "ID_Canboduyet");

            migrationBuilder.CreateIndex(
                name: "IX_Dangkykenh_Duyet_UngdungId",
                table: "Dangkykenh_Duyet",
                column: "UngdungId");

            migrationBuilder.CreateIndex(
                name: "IX_Danhsachnguoidung_CanboId",
                table: "Danhsachnguoidung",
                column: "CanboId");

            migrationBuilder.CreateIndex(
                name: "IX_Danhsachnguoidung_SokenhId",
                table: "Danhsachnguoidung",
                column: "SokenhId");

            migrationBuilder.CreateIndex(
                name: "IX_DmFeature_AppId",
                table: "DmFeature",
                column: "AppId");

            migrationBuilder.CreateIndex(
                name: "IX_DmRole_Feature_FeatureId",
                table: "DmRole_Feature",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_DmRole_Feature_RoleId",
                table: "DmRole_Feature",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_DmThongbao_SoquanlykenhId",
                table: "DmThongbao",
                column: "SoquanlykenhId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_UserId",
                table: "RefreshToken",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Soquanlykenh_Dangkykenh_DuyetId",
                table: "Soquanlykenh",
                column: "Dangkykenh_DuyetId");

            migrationBuilder.CreateIndex(
                name: "IX_Soquanlykenh_UngdungId",
                table: "Soquanlykenh",
                column: "UngdungId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Danhsachnguoidung");

            migrationBuilder.DropTable(
                name: "DmBlackWord");

            migrationBuilder.DropTable(
                name: "DmRole_Feature");

            migrationBuilder.DropTable(
                name: "DmThongbao");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "ThongsoHethong");

            migrationBuilder.DropTable(
                name: "DmFeature");

            migrationBuilder.DropTable(
                name: "Soquanlykenh");

            migrationBuilder.DropTable(
                name: "DmApp");

            migrationBuilder.DropTable(
                name: "Dangkykenh_Duyet");

            migrationBuilder.DropTable(
                name: "Dangkykenh");

            migrationBuilder.DropTable(
                name: "Canbo");

            migrationBuilder.DropTable(
                name: "DmUngdung");

            migrationBuilder.DropTable(
                name: "DmCapbac");

            migrationBuilder.DropTable(
                name: "DmChucvu");

            migrationBuilder.DropTable(
                name: "DmDonvi");

            migrationBuilder.DropTable(
                name: "DmRole");
        }
    }
}
