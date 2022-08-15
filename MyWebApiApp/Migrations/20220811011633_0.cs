using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AMGAPI.Migrations
{
    public partial class _0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sodienthoaigui",
                table: "DmThongbao",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tieudetinnhan",
                table: "DmThongbao",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Trangthai",
                table: "DmThongbao",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Dangkykenh",
                keyColumn: "Id",
                keyValue: new Guid("37f70f55-7dcb-4ca5-b0c8-7466b9cedf3d"),
                columns: new[] { "Ngayduyet", "Ngaysua", "Ngaytao" },
                values: new object[] { new DateTime(2022, 8, 11, 1, 16, 32, 925, DateTimeKind.Utc).AddTicks(8444), new DateTime(2022, 8, 11, 1, 16, 32, 925, DateTimeKind.Utc).AddTicks(8443), new DateTime(2022, 8, 11, 1, 16, 32, 925, DateTimeKind.Utc).AddTicks(8441) });

            migrationBuilder.UpdateData(
                table: "Dangkykenh",
                keyColumn: "Id",
                keyValue: new Guid("e0f582de-420f-4902-8cee-cf85389cc6bf"),
                columns: new[] { "Ngayduyet", "Ngaysua", "Ngaytao" },
                values: new object[] { new DateTime(2022, 8, 11, 1, 16, 32, 925, DateTimeKind.Utc).AddTicks(7864), new DateTime(2022, 8, 11, 1, 16, 32, 925, DateTimeKind.Utc).AddTicks(7428), new DateTime(2022, 8, 11, 1, 16, 32, 925, DateTimeKind.Utc).AddTicks(7142) });

            migrationBuilder.UpdateData(
                table: "Dangkykenh_Duyet",
                keyColumn: "Id",
                keyValue: new Guid("6746de28-4d95-4a77-96de-c75a8eb80bc4"),
                columns: new[] { "NgayTao", "Ngaysua" },
                values: new object[] { new DateTime(2022, 8, 11, 1, 16, 32, 926, DateTimeKind.Utc).AddTicks(893), new DateTime(2022, 8, 11, 1, 16, 32, 926, DateTimeKind.Utc).AddTicks(1127) });

            migrationBuilder.UpdateData(
                table: "Dangkykenh_Duyet",
                keyColumn: "Id",
                keyValue: new Guid("97c3636d-cff0-4b80-b426-dc299e373053"),
                columns: new[] { "NgayTao", "Ngaysua" },
                values: new object[] { new DateTime(2022, 8, 11, 1, 16, 32, 926, DateTimeKind.Utc).AddTicks(1821), new DateTime(2022, 8, 11, 1, 16, 32, 926, DateTimeKind.Utc).AddTicks(1823) });

            migrationBuilder.UpdateData(
                table: "DmThongbao",
                keyColumn: "Id",
                keyValue: new Guid("9b773e21-4ee4-4e50-adc7-1edb42dbcfb1"),
                column: "Ngaytao",
                value: new DateTime(2022, 8, 11, 1, 16, 32, 926, DateTimeKind.Utc).AddTicks(3509));

            migrationBuilder.UpdateData(
                table: "DmThongbao",
                keyColumn: "Id",
                keyValue: new Guid("b079a0b9-50b1-4e54-af26-96f1e6576926"),
                column: "Ngaytao",
                value: new DateTime(2022, 8, 11, 1, 16, 32, 926, DateTimeKind.Utc).AddTicks(3235));

            migrationBuilder.UpdateData(
                table: "Soquanlykenh",
                keyColumn: "Id",
                keyValue: new Guid("46988f74-1475-4283-a128-dda4f4b16094"),
                columns: new[] { "Ngaysua", "Ngaytao", "Ngayvaoso" },
                values: new object[] { new DateTime(2022, 8, 11, 1, 16, 32, 926, DateTimeKind.Utc).AddTicks(6940), new DateTime(2022, 8, 11, 1, 16, 32, 926, DateTimeKind.Utc).AddTicks(6938), new DateTime(2022, 8, 11, 1, 16, 32, 926, DateTimeKind.Utc).AddTicks(6941) });

            migrationBuilder.UpdateData(
                table: "Soquanlykenh",
                keyColumn: "Id",
                keyValue: new Guid("565b84a8-792f-4bcc-a701-1c7aae1930f0"),
                columns: new[] { "Ngaysua", "Ngaytao", "Ngayvaoso" },
                values: new object[] { new DateTime(2022, 8, 11, 1, 16, 32, 926, DateTimeKind.Utc).AddTicks(6247), new DateTime(2022, 8, 11, 1, 16, 32, 926, DateTimeKind.Utc).AddTicks(6017), new DateTime(2022, 8, 11, 1, 16, 32, 926, DateTimeKind.Utc).AddTicks(6470) });

            migrationBuilder.UpdateData(
                table: "ThongsoHethong",
                keyColumn: "Id",
                keyValue: new Guid("9645cf84-11af-485f-8b90-fd34f3d7f26a"),
                columns: new[] { "CreateDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 11, 1, 16, 32, 928, DateTimeKind.Utc).AddTicks(5786), new DateTime(2022, 8, 11, 1, 16, 32, 928, DateTimeKind.Utc).AddTicks(6017) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sodienthoaigui",
                table: "DmThongbao");

            migrationBuilder.DropColumn(
                name: "Tieudetinnhan",
                table: "DmThongbao");

            migrationBuilder.DropColumn(
                name: "Trangthai",
                table: "DmThongbao");

            migrationBuilder.UpdateData(
                table: "Dangkykenh",
                keyColumn: "Id",
                keyValue: new Guid("37f70f55-7dcb-4ca5-b0c8-7466b9cedf3d"),
                columns: new[] { "Ngayduyet", "Ngaysua", "Ngaytao" },
                values: new object[] { new DateTime(2022, 7, 28, 3, 38, 41, 728, DateTimeKind.Utc).AddTicks(1036), new DateTime(2022, 7, 28, 3, 38, 41, 728, DateTimeKind.Utc).AddTicks(1035), new DateTime(2022, 7, 28, 3, 38, 41, 728, DateTimeKind.Utc).AddTicks(1033) });

            migrationBuilder.UpdateData(
                table: "Dangkykenh",
                keyColumn: "Id",
                keyValue: new Guid("e0f582de-420f-4902-8cee-cf85389cc6bf"),
                columns: new[] { "Ngayduyet", "Ngaysua", "Ngaytao" },
                values: new object[] { new DateTime(2022, 7, 28, 3, 38, 41, 728, DateTimeKind.Utc).AddTicks(473), new DateTime(2022, 7, 28, 3, 38, 41, 728, DateTimeKind.Utc).AddTicks(45), new DateTime(2022, 7, 28, 3, 38, 41, 727, DateTimeKind.Utc).AddTicks(9652) });

            migrationBuilder.UpdateData(
                table: "Dangkykenh_Duyet",
                keyColumn: "Id",
                keyValue: new Guid("6746de28-4d95-4a77-96de-c75a8eb80bc4"),
                columns: new[] { "NgayTao", "Ngaysua" },
                values: new object[] { new DateTime(2022, 7, 28, 3, 38, 41, 728, DateTimeKind.Utc).AddTicks(3852), new DateTime(2022, 7, 28, 3, 38, 41, 728, DateTimeKind.Utc).AddTicks(4085) });

            migrationBuilder.UpdateData(
                table: "Dangkykenh_Duyet",
                keyColumn: "Id",
                keyValue: new Guid("97c3636d-cff0-4b80-b426-dc299e373053"),
                columns: new[] { "NgayTao", "Ngaysua" },
                values: new object[] { new DateTime(2022, 7, 28, 3, 38, 41, 728, DateTimeKind.Utc).AddTicks(4774), new DateTime(2022, 7, 28, 3, 38, 41, 728, DateTimeKind.Utc).AddTicks(4776) });

            migrationBuilder.UpdateData(
                table: "DmThongbao",
                keyColumn: "Id",
                keyValue: new Guid("9b773e21-4ee4-4e50-adc7-1edb42dbcfb1"),
                column: "Ngaytao",
                value: new DateTime(2022, 7, 28, 3, 38, 41, 728, DateTimeKind.Utc).AddTicks(6400));

            migrationBuilder.UpdateData(
                table: "DmThongbao",
                keyColumn: "Id",
                keyValue: new Guid("b079a0b9-50b1-4e54-af26-96f1e6576926"),
                column: "Ngaytao",
                value: new DateTime(2022, 7, 28, 3, 38, 41, 728, DateTimeKind.Utc).AddTicks(6161));

            migrationBuilder.UpdateData(
                table: "Soquanlykenh",
                keyColumn: "Id",
                keyValue: new Guid("46988f74-1475-4283-a128-dda4f4b16094"),
                columns: new[] { "Ngaysua", "Ngaytao", "Ngayvaoso" },
                values: new object[] { new DateTime(2022, 7, 28, 3, 38, 41, 728, DateTimeKind.Utc).AddTicks(9939), new DateTime(2022, 7, 28, 3, 38, 41, 728, DateTimeKind.Utc).AddTicks(9936), new DateTime(2022, 7, 28, 3, 38, 41, 728, DateTimeKind.Utc).AddTicks(9940) });

            migrationBuilder.UpdateData(
                table: "Soquanlykenh",
                keyColumn: "Id",
                keyValue: new Guid("565b84a8-792f-4bcc-a701-1c7aae1930f0"),
                columns: new[] { "Ngaysua", "Ngaytao", "Ngayvaoso" },
                values: new object[] { new DateTime(2022, 7, 28, 3, 38, 41, 728, DateTimeKind.Utc).AddTicks(9053), new DateTime(2022, 7, 28, 3, 38, 41, 728, DateTimeKind.Utc).AddTicks(8827), new DateTime(2022, 7, 28, 3, 38, 41, 728, DateTimeKind.Utc).AddTicks(9272) });

            migrationBuilder.UpdateData(
                table: "ThongsoHethong",
                keyColumn: "Id",
                keyValue: new Guid("9645cf84-11af-485f-8b90-fd34f3d7f26a"),
                columns: new[] { "CreateDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 7, 28, 3, 38, 41, 730, DateTimeKind.Utc).AddTicks(9018), new DateTime(2022, 7, 28, 3, 38, 41, 730, DateTimeKind.Utc).AddTicks(9250) });
        }
    }
}
