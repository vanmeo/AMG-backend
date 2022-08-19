using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AMGAPI.Migrations
{
    public partial class dbstart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Public_Key",
                table: "Danhsachnguoidung",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Dangkykenh",
                keyColumn: "Id",
                keyValue: new Guid("37f70f55-7dcb-4ca5-b0c8-7466b9cedf3d"),
                columns: new[] { "Ngayduyet", "Ngaysua", "Ngaytao" },
                values: new object[] { new DateTime(2022, 8, 17, 4, 15, 53, 592, DateTimeKind.Utc).AddTicks(1466), new DateTime(2022, 8, 17, 4, 15, 53, 592, DateTimeKind.Utc).AddTicks(1464), new DateTime(2022, 8, 17, 4, 15, 53, 592, DateTimeKind.Utc).AddTicks(1462) });

            migrationBuilder.UpdateData(
                table: "Dangkykenh",
                keyColumn: "Id",
                keyValue: new Guid("e0f582de-420f-4902-8cee-cf85389cc6bf"),
                columns: new[] { "Ngayduyet", "Ngaysua", "Ngaytao" },
                values: new object[] { new DateTime(2022, 8, 17, 4, 15, 53, 592, DateTimeKind.Utc).AddTicks(815), new DateTime(2022, 8, 17, 4, 15, 53, 592, DateTimeKind.Utc).AddTicks(348), new DateTime(2022, 8, 17, 4, 15, 53, 592, DateTimeKind.Utc).AddTicks(83) });

            migrationBuilder.UpdateData(
                table: "Dangkykenh_Duyet",
                keyColumn: "Id",
                keyValue: new Guid("6746de28-4d95-4a77-96de-c75a8eb80bc4"),
                columns: new[] { "NgayTao", "Ngaysua" },
                values: new object[] { new DateTime(2022, 8, 17, 4, 15, 53, 592, DateTimeKind.Utc).AddTicks(5927), new DateTime(2022, 8, 17, 4, 15, 53, 592, DateTimeKind.Utc).AddTicks(6481) });

            migrationBuilder.UpdateData(
                table: "Dangkykenh_Duyet",
                keyColumn: "Id",
                keyValue: new Guid("97c3636d-cff0-4b80-b426-dc299e373053"),
                columns: new[] { "NgayTao", "Ngaysua" },
                values: new object[] { new DateTime(2022, 8, 17, 4, 15, 53, 592, DateTimeKind.Utc).AddTicks(7900), new DateTime(2022, 8, 17, 4, 15, 53, 592, DateTimeKind.Utc).AddTicks(7903) });

            migrationBuilder.UpdateData(
                table: "DmThongbao",
                keyColumn: "Id",
                keyValue: new Guid("9b773e21-4ee4-4e50-adc7-1edb42dbcfb1"),
                column: "Ngaytao",
                value: new DateTime(2022, 8, 17, 4, 15, 53, 593, DateTimeKind.Utc).AddTicks(1356));

            migrationBuilder.UpdateData(
                table: "DmThongbao",
                keyColumn: "Id",
                keyValue: new Guid("b079a0b9-50b1-4e54-af26-96f1e6576926"),
                column: "Ngaytao",
                value: new DateTime(2022, 8, 17, 4, 15, 53, 593, DateTimeKind.Utc).AddTicks(988));

            migrationBuilder.UpdateData(
                table: "Soquanlykenh",
                keyColumn: "Id",
                keyValue: new Guid("46988f74-1475-4283-a128-dda4f4b16094"),
                columns: new[] { "Ngaysua", "Ngaytao", "Ngayvaoso" },
                values: new object[] { new DateTime(2022, 8, 17, 4, 15, 53, 593, DateTimeKind.Utc).AddTicks(6933), new DateTime(2022, 8, 17, 4, 15, 53, 593, DateTimeKind.Utc).AddTicks(6929), new DateTime(2022, 8, 17, 4, 15, 53, 593, DateTimeKind.Utc).AddTicks(6935) });

            migrationBuilder.UpdateData(
                table: "Soquanlykenh",
                keyColumn: "Id",
                keyValue: new Guid("565b84a8-792f-4bcc-a701-1c7aae1930f0"),
                columns: new[] { "Ngaysua", "Ngaytao", "Ngayvaoso" },
                values: new object[] { new DateTime(2022, 8, 17, 4, 15, 53, 593, DateTimeKind.Utc).AddTicks(5260), new DateTime(2022, 8, 17, 4, 15, 53, 593, DateTimeKind.Utc).AddTicks(4683), new DateTime(2022, 8, 17, 4, 15, 53, 593, DateTimeKind.Utc).AddTicks(5839) });

            migrationBuilder.UpdateData(
                table: "ThongsoHethong",
                keyColumn: "Id",
                keyValue: new Guid("9645cf84-11af-485f-8b90-fd34f3d7f26a"),
                columns: new[] { "CreateDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 17, 4, 15, 53, 597, DateTimeKind.Utc).AddTicks(1242), new DateTime(2022, 8, 17, 4, 15, 53, 597, DateTimeKind.Utc).AddTicks(1502) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Public_Key",
                table: "Danhsachnguoidung");

            migrationBuilder.UpdateData(
                table: "Dangkykenh",
                keyColumn: "Id",
                keyValue: new Guid("37f70f55-7dcb-4ca5-b0c8-7466b9cedf3d"),
                columns: new[] { "Ngayduyet", "Ngaysua", "Ngaytao" },
                values: new object[] { new DateTime(2022, 8, 17, 2, 35, 10, 890, DateTimeKind.Utc).AddTicks(4208), new DateTime(2022, 8, 17, 2, 35, 10, 890, DateTimeKind.Utc).AddTicks(4207), new DateTime(2022, 8, 17, 2, 35, 10, 890, DateTimeKind.Utc).AddTicks(4204) });

            migrationBuilder.UpdateData(
                table: "Dangkykenh",
                keyColumn: "Id",
                keyValue: new Guid("e0f582de-420f-4902-8cee-cf85389cc6bf"),
                columns: new[] { "Ngayduyet", "Ngaysua", "Ngaytao" },
                values: new object[] { new DateTime(2022, 8, 17, 2, 35, 10, 890, DateTimeKind.Utc).AddTicks(3439), new DateTime(2022, 8, 17, 2, 35, 10, 890, DateTimeKind.Utc).AddTicks(2859), new DateTime(2022, 8, 17, 2, 35, 10, 890, DateTimeKind.Utc).AddTicks(2534) });

            migrationBuilder.UpdateData(
                table: "Dangkykenh_Duyet",
                keyColumn: "Id",
                keyValue: new Guid("6746de28-4d95-4a77-96de-c75a8eb80bc4"),
                columns: new[] { "NgayTao", "Ngaysua" },
                values: new object[] { new DateTime(2022, 8, 17, 2, 35, 10, 890, DateTimeKind.Utc).AddTicks(7670), new DateTime(2022, 8, 17, 2, 35, 10, 890, DateTimeKind.Utc).AddTicks(8148) });

            migrationBuilder.UpdateData(
                table: "Dangkykenh_Duyet",
                keyColumn: "Id",
                keyValue: new Guid("97c3636d-cff0-4b80-b426-dc299e373053"),
                columns: new[] { "NgayTao", "Ngaysua" },
                values: new object[] { new DateTime(2022, 8, 17, 2, 35, 10, 890, DateTimeKind.Utc).AddTicks(9393), new DateTime(2022, 8, 17, 2, 35, 10, 890, DateTimeKind.Utc).AddTicks(9396) });

            migrationBuilder.UpdateData(
                table: "DmThongbao",
                keyColumn: "Id",
                keyValue: new Guid("9b773e21-4ee4-4e50-adc7-1edb42dbcfb1"),
                column: "Ngaytao",
                value: new DateTime(2022, 8, 17, 2, 35, 10, 891, DateTimeKind.Utc).AddTicks(1881));

            migrationBuilder.UpdateData(
                table: "DmThongbao",
                keyColumn: "Id",
                keyValue: new Guid("b079a0b9-50b1-4e54-af26-96f1e6576926"),
                column: "Ngaytao",
                value: new DateTime(2022, 8, 17, 2, 35, 10, 891, DateTimeKind.Utc).AddTicks(1512));

            migrationBuilder.UpdateData(
                table: "Soquanlykenh",
                keyColumn: "Id",
                keyValue: new Guid("46988f74-1475-4283-a128-dda4f4b16094"),
                columns: new[] { "Ngaysua", "Ngaytao", "Ngayvaoso" },
                values: new object[] { new DateTime(2022, 8, 17, 2, 35, 10, 891, DateTimeKind.Utc).AddTicks(6525), new DateTime(2022, 8, 17, 2, 35, 10, 891, DateTimeKind.Utc).AddTicks(6522), new DateTime(2022, 8, 17, 2, 35, 10, 891, DateTimeKind.Utc).AddTicks(6526) });

            migrationBuilder.UpdateData(
                table: "Soquanlykenh",
                keyColumn: "Id",
                keyValue: new Guid("565b84a8-792f-4bcc-a701-1c7aae1930f0"),
                columns: new[] { "Ngaysua", "Ngaytao", "Ngayvaoso" },
                values: new object[] { new DateTime(2022, 8, 17, 2, 35, 10, 891, DateTimeKind.Utc).AddTicks(5637), new DateTime(2022, 8, 17, 2, 35, 10, 891, DateTimeKind.Utc).AddTicks(5327), new DateTime(2022, 8, 17, 2, 35, 10, 891, DateTimeKind.Utc).AddTicks(5939) });

            migrationBuilder.UpdateData(
                table: "ThongsoHethong",
                keyColumn: "Id",
                keyValue: new Guid("9645cf84-11af-485f-8b90-fd34f3d7f26a"),
                columns: new[] { "CreateDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 8, 17, 2, 35, 10, 894, DateTimeKind.Utc).AddTicks(1976), new DateTime(2022, 8, 17, 2, 35, 10, 894, DateTimeKind.Utc).AddTicks(2338) });
        }
    }
}
