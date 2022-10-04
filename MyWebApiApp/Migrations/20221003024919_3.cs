using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AMGAPI.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrackingChanges");

            migrationBuilder.CreateTable(
                name: "TrackingChange",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDBang = table.Column<int>(type: "int", nullable: false),
                    ID_ROW = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackingChange", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Dangkykenh",
                keyColumn: "Id",
                keyValue: new Guid("37f70f55-7dcb-4ca5-b0c8-7466b9cedf3d"),
                columns: new[] { "Ngayduyet", "Ngaysua", "Ngaytao" },
                values: new object[] { new DateTime(2022, 10, 3, 2, 49, 18, 925, DateTimeKind.Utc).AddTicks(8889), new DateTime(2022, 10, 3, 2, 49, 18, 925, DateTimeKind.Utc).AddTicks(8888), new DateTime(2022, 10, 3, 2, 49, 18, 925, DateTimeKind.Utc).AddTicks(8886) });

            migrationBuilder.UpdateData(
                table: "Dangkykenh",
                keyColumn: "Id",
                keyValue: new Guid("e0f582de-420f-4902-8cee-cf85389cc6bf"),
                columns: new[] { "Ngayduyet", "Ngaysua", "Ngaytao" },
                values: new object[] { new DateTime(2022, 10, 3, 2, 49, 18, 925, DateTimeKind.Utc).AddTicks(8305), new DateTime(2022, 10, 3, 2, 49, 18, 925, DateTimeKind.Utc).AddTicks(7847), new DateTime(2022, 10, 3, 2, 49, 18, 925, DateTimeKind.Utc).AddTicks(7601) });

            migrationBuilder.UpdateData(
                table: "Dangkykenh_Duyet",
                keyColumn: "Id",
                keyValue: new Guid("6746de28-4d95-4a77-96de-c75a8eb80bc4"),
                columns: new[] { "NgayTao", "Ngaysua" },
                values: new object[] { new DateTime(2022, 10, 3, 2, 49, 18, 926, DateTimeKind.Utc).AddTicks(1376), new DateTime(2022, 10, 3, 2, 49, 18, 926, DateTimeKind.Utc).AddTicks(1613) });

            migrationBuilder.UpdateData(
                table: "Dangkykenh_Duyet",
                keyColumn: "Id",
                keyValue: new Guid("97c3636d-cff0-4b80-b426-dc299e373053"),
                columns: new[] { "NgayTao", "Ngaysua" },
                values: new object[] { new DateTime(2022, 10, 3, 2, 49, 18, 926, DateTimeKind.Utc).AddTicks(2324), new DateTime(2022, 10, 3, 2, 49, 18, 926, DateTimeKind.Utc).AddTicks(2327) });

            migrationBuilder.UpdateData(
                table: "DmThongbao",
                keyColumn: "Id",
                keyValue: new Guid("9b773e21-4ee4-4e50-adc7-1edb42dbcfb1"),
                column: "Ngaytao",
                value: new DateTime(2022, 10, 3, 2, 49, 18, 926, DateTimeKind.Utc).AddTicks(3973));

            migrationBuilder.UpdateData(
                table: "DmThongbao",
                keyColumn: "Id",
                keyValue: new Guid("b079a0b9-50b1-4e54-af26-96f1e6576926"),
                column: "Ngaytao",
                value: new DateTime(2022, 10, 3, 2, 49, 18, 926, DateTimeKind.Utc).AddTicks(3731));

            migrationBuilder.UpdateData(
                table: "Soquanlykenh",
                keyColumn: "Id",
                keyValue: new Guid("46988f74-1475-4283-a128-dda4f4b16094"),
                columns: new[] { "Ngaysua", "Ngaytao", "Ngayvaoso", "Ten_Kihieukenh" },
                values: new object[] { new DateTime(2022, 10, 3, 2, 49, 18, 926, DateTimeKind.Utc).AddTicks(7508), new DateTime(2022, 10, 3, 2, 49, 18, 926, DateTimeKind.Utc).AddTicks(7506), new DateTime(2022, 10, 3, 2, 49, 18, 926, DateTimeKind.Utc).AddTicks(7509), "CDN" });

            migrationBuilder.UpdateData(
                table: "Soquanlykenh",
                keyColumn: "Id",
                keyValue: new Guid("565b84a8-792f-4bcc-a701-1c7aae1930f0"),
                columns: new[] { "Ngaysua", "Ngaytao", "Ngayvaoso", "Ten_Kihieukenh" },
                values: new object[] { new DateTime(2022, 10, 3, 2, 49, 18, 926, DateTimeKind.Utc).AddTicks(6642), new DateTime(2022, 10, 3, 2, 49, 18, 926, DateTimeKind.Utc).AddTicks(6414), new DateTime(2022, 10, 3, 2, 49, 18, 926, DateTimeKind.Utc).AddTicks(6864), "CDDH" });

            migrationBuilder.UpdateData(
                table: "ThongsoHethong",
                keyColumn: "Id",
                keyValue: new Guid("9645cf84-11af-485f-8b90-fd34f3d7f26a"),
                columns: new[] { "CreateDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 10, 3, 2, 49, 18, 928, DateTimeKind.Utc).AddTicks(6441), new DateTime(2022, 10, 3, 2, 49, 18, 928, DateTimeKind.Utc).AddTicks(6675) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrackingChange");

            migrationBuilder.CreateTable(
                name: "TrackingChanges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDBang = table.Column<int>(type: "int", nullable: false),
                    ID_ROW = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackingChanges", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Dangkykenh",
                keyColumn: "Id",
                keyValue: new Guid("37f70f55-7dcb-4ca5-b0c8-7466b9cedf3d"),
                columns: new[] { "Ngayduyet", "Ngaysua", "Ngaytao" },
                values: new object[] { new DateTime(2022, 10, 3, 0, 25, 3, 196, DateTimeKind.Utc).AddTicks(7168), new DateTime(2022, 10, 3, 0, 25, 3, 196, DateTimeKind.Utc).AddTicks(7167), new DateTime(2022, 10, 3, 0, 25, 3, 196, DateTimeKind.Utc).AddTicks(7165) });

            migrationBuilder.UpdateData(
                table: "Dangkykenh",
                keyColumn: "Id",
                keyValue: new Guid("e0f582de-420f-4902-8cee-cf85389cc6bf"),
                columns: new[] { "Ngayduyet", "Ngaysua", "Ngaytao" },
                values: new object[] { new DateTime(2022, 10, 3, 0, 25, 3, 196, DateTimeKind.Utc).AddTicks(6527), new DateTime(2022, 10, 3, 0, 25, 3, 196, DateTimeKind.Utc).AddTicks(6080), new DateTime(2022, 10, 3, 0, 25, 3, 196, DateTimeKind.Utc).AddTicks(5829) });

            migrationBuilder.UpdateData(
                table: "Dangkykenh_Duyet",
                keyColumn: "Id",
                keyValue: new Guid("6746de28-4d95-4a77-96de-c75a8eb80bc4"),
                columns: new[] { "NgayTao", "Ngaysua" },
                values: new object[] { new DateTime(2022, 10, 3, 0, 25, 3, 196, DateTimeKind.Utc).AddTicks(9813), new DateTime(2022, 10, 3, 0, 25, 3, 197, DateTimeKind.Utc).AddTicks(53) });

            migrationBuilder.UpdateData(
                table: "Dangkykenh_Duyet",
                keyColumn: "Id",
                keyValue: new Guid("97c3636d-cff0-4b80-b426-dc299e373053"),
                columns: new[] { "NgayTao", "Ngaysua" },
                values: new object[] { new DateTime(2022, 10, 3, 0, 25, 3, 197, DateTimeKind.Utc).AddTicks(805), new DateTime(2022, 10, 3, 0, 25, 3, 197, DateTimeKind.Utc).AddTicks(807) });

            migrationBuilder.UpdateData(
                table: "DmThongbao",
                keyColumn: "Id",
                keyValue: new Guid("9b773e21-4ee4-4e50-adc7-1edb42dbcfb1"),
                column: "Ngaytao",
                value: new DateTime(2022, 10, 3, 0, 25, 3, 197, DateTimeKind.Utc).AddTicks(2481));

            migrationBuilder.UpdateData(
                table: "DmThongbao",
                keyColumn: "Id",
                keyValue: new Guid("b079a0b9-50b1-4e54-af26-96f1e6576926"),
                column: "Ngaytao",
                value: new DateTime(2022, 10, 3, 0, 25, 3, 197, DateTimeKind.Utc).AddTicks(2233));

            migrationBuilder.UpdateData(
                table: "Soquanlykenh",
                keyColumn: "Id",
                keyValue: new Guid("46988f74-1475-4283-a128-dda4f4b16094"),
                columns: new[] { "Ngaysua", "Ngaytao", "Ngayvaoso", "Ten_Kihieukenh" },
                values: new object[] { new DateTime(2022, 10, 3, 0, 25, 3, 197, DateTimeKind.Utc).AddTicks(5881), new DateTime(2022, 10, 3, 0, 25, 3, 197, DateTimeKind.Utc).AddTicks(5878), new DateTime(2022, 10, 3, 0, 25, 3, 197, DateTimeKind.Utc).AddTicks(5882), null });

            migrationBuilder.UpdateData(
                table: "Soquanlykenh",
                keyColumn: "Id",
                keyValue: new Guid("565b84a8-792f-4bcc-a701-1c7aae1930f0"),
                columns: new[] { "Ngaysua", "Ngaytao", "Ngayvaoso", "Ten_Kihieukenh" },
                values: new object[] { new DateTime(2022, 10, 3, 0, 25, 3, 197, DateTimeKind.Utc).AddTicks(5205), new DateTime(2022, 10, 3, 0, 25, 3, 197, DateTimeKind.Utc).AddTicks(4973), new DateTime(2022, 10, 3, 0, 25, 3, 197, DateTimeKind.Utc).AddTicks(5432), null });

            migrationBuilder.UpdateData(
                table: "ThongsoHethong",
                keyColumn: "Id",
                keyValue: new Guid("9645cf84-11af-485f-8b90-fd34f3d7f26a"),
                columns: new[] { "CreateDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 10, 3, 0, 25, 3, 199, DateTimeKind.Utc).AddTicks(5841), new DateTime(2022, 10, 3, 0, 25, 3, 199, DateTimeKind.Utc).AddTicks(6080) });
        }
    }
}
