using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AMGAPI.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Trangthai",
                table: "Danhsachnguoidung",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Dangkykenh",
                keyColumn: "Id",
                keyValue: new Guid("37f70f55-7dcb-4ca5-b0c8-7466b9cedf3d"),
                columns: new[] { "Ngayduyet", "Ngaysua", "Ngaytao" },
                values: new object[] { new DateTime(2022, 7, 6, 9, 9, 6, 685, DateTimeKind.Utc).AddTicks(9971), new DateTime(2022, 7, 6, 9, 9, 6, 685, DateTimeKind.Utc).AddTicks(9970), new DateTime(2022, 7, 6, 9, 9, 6, 685, DateTimeKind.Utc).AddTicks(9968) });

            migrationBuilder.UpdateData(
                table: "Dangkykenh",
                keyColumn: "Id",
                keyValue: new Guid("e0f582de-420f-4902-8cee-cf85389cc6bf"),
                columns: new[] { "Ngayduyet", "Ngaysua", "Ngaytao" },
                values: new object[] { new DateTime(2022, 7, 6, 9, 9, 6, 685, DateTimeKind.Utc).AddTicks(9253), new DateTime(2022, 7, 6, 9, 9, 6, 685, DateTimeKind.Utc).AddTicks(8801), new DateTime(2022, 7, 6, 9, 9, 6, 685, DateTimeKind.Utc).AddTicks(8541) });

            migrationBuilder.UpdateData(
                table: "Dangkykenh_Duyet",
                keyColumn: "Id",
                keyValue: new Guid("6746de28-4d95-4a77-96de-c75a8eb80bc4"),
                columns: new[] { "NgayTao", "Ngaysua" },
                values: new object[] { new DateTime(2022, 7, 6, 9, 9, 6, 686, DateTimeKind.Utc).AddTicks(2208), new DateTime(2022, 7, 6, 9, 9, 6, 686, DateTimeKind.Utc).AddTicks(2453) });

            migrationBuilder.UpdateData(
                table: "Dangkykenh_Duyet",
                keyColumn: "Id",
                keyValue: new Guid("97c3636d-cff0-4b80-b426-dc299e373053"),
                columns: new[] { "NgayTao", "Ngaysua" },
                values: new object[] { new DateTime(2022, 7, 6, 9, 9, 6, 686, DateTimeKind.Utc).AddTicks(3184), new DateTime(2022, 7, 6, 9, 9, 6, 686, DateTimeKind.Utc).AddTicks(3186) });

            migrationBuilder.UpdateData(
                table: "DmThongbao",
                keyColumn: "Id",
                keyValue: new Guid("9b773e21-4ee4-4e50-adc7-1edb42dbcfb1"),
                column: "Ngaytao",
                value: new DateTime(2022, 7, 6, 9, 9, 6, 686, DateTimeKind.Utc).AddTicks(4895));

            migrationBuilder.UpdateData(
                table: "DmThongbao",
                keyColumn: "Id",
                keyValue: new Guid("b079a0b9-50b1-4e54-af26-96f1e6576926"),
                column: "Ngaytao",
                value: new DateTime(2022, 7, 6, 9, 9, 6, 686, DateTimeKind.Utc).AddTicks(4643));

            migrationBuilder.UpdateData(
                table: "Soquanlykenh",
                keyColumn: "Id",
                keyValue: new Guid("46988f74-1475-4283-a128-dda4f4b16094"),
                columns: new[] { "Ngaysua", "Ngaytao", "Ngayvaoso" },
                values: new object[] { new DateTime(2022, 7, 6, 9, 9, 6, 686, DateTimeKind.Utc).AddTicks(8173), new DateTime(2022, 7, 6, 9, 9, 6, 686, DateTimeKind.Utc).AddTicks(8171), new DateTime(2022, 7, 6, 9, 9, 6, 686, DateTimeKind.Utc).AddTicks(8174) });

            migrationBuilder.UpdateData(
                table: "Soquanlykenh",
                keyColumn: "Id",
                keyValue: new Guid("565b84a8-792f-4bcc-a701-1c7aae1930f0"),
                columns: new[] { "Ngaysua", "Ngaytao", "Ngayvaoso" },
                values: new object[] { new DateTime(2022, 7, 6, 9, 9, 6, 686, DateTimeKind.Utc).AddTicks(7490), new DateTime(2022, 7, 6, 9, 9, 6, 686, DateTimeKind.Utc).AddTicks(7251), new DateTime(2022, 7, 6, 9, 9, 6, 686, DateTimeKind.Utc).AddTicks(7722) });

            migrationBuilder.UpdateData(
                table: "ThongsoHethong",
                keyColumn: "Id",
                keyValue: new Guid("9645cf84-11af-485f-8b90-fd34f3d7f26a"),
                columns: new[] { "CreateDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 7, 6, 9, 9, 6, 688, DateTimeKind.Utc).AddTicks(7392), new DateTime(2022, 7, 6, 9, 9, 6, 688, DateTimeKind.Utc).AddTicks(7679) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Trangthai",
                table: "Danhsachnguoidung");

            migrationBuilder.UpdateData(
                table: "Dangkykenh",
                keyColumn: "Id",
                keyValue: new Guid("37f70f55-7dcb-4ca5-b0c8-7466b9cedf3d"),
                columns: new[] { "Ngayduyet", "Ngaysua", "Ngaytao" },
                values: new object[] { new DateTime(2022, 7, 6, 2, 27, 38, 693, DateTimeKind.Utc).AddTicks(3819), new DateTime(2022, 7, 6, 2, 27, 38, 693, DateTimeKind.Utc).AddTicks(3818), new DateTime(2022, 7, 6, 2, 27, 38, 693, DateTimeKind.Utc).AddTicks(3815) });

            migrationBuilder.UpdateData(
                table: "Dangkykenh",
                keyColumn: "Id",
                keyValue: new Guid("e0f582de-420f-4902-8cee-cf85389cc6bf"),
                columns: new[] { "Ngayduyet", "Ngaysua", "Ngaytao" },
                values: new object[] { new DateTime(2022, 7, 6, 2, 27, 38, 693, DateTimeKind.Utc).AddTicks(3246), new DateTime(2022, 7, 6, 2, 27, 38, 693, DateTimeKind.Utc).AddTicks(2815), new DateTime(2022, 7, 6, 2, 27, 38, 693, DateTimeKind.Utc).AddTicks(2573) });

            migrationBuilder.UpdateData(
                table: "Dangkykenh_Duyet",
                keyColumn: "Id",
                keyValue: new Guid("6746de28-4d95-4a77-96de-c75a8eb80bc4"),
                columns: new[] { "NgayTao", "Ngaysua" },
                values: new object[] { new DateTime(2022, 7, 6, 2, 27, 38, 693, DateTimeKind.Utc).AddTicks(6176), new DateTime(2022, 7, 6, 2, 27, 38, 693, DateTimeKind.Utc).AddTicks(6414) });

            migrationBuilder.UpdateData(
                table: "Dangkykenh_Duyet",
                keyColumn: "Id",
                keyValue: new Guid("97c3636d-cff0-4b80-b426-dc299e373053"),
                columns: new[] { "NgayTao", "Ngaysua" },
                values: new object[] { new DateTime(2022, 7, 6, 2, 27, 38, 693, DateTimeKind.Utc).AddTicks(7116), new DateTime(2022, 7, 6, 2, 27, 38, 693, DateTimeKind.Utc).AddTicks(7117) });

            migrationBuilder.UpdateData(
                table: "DmThongbao",
                keyColumn: "Id",
                keyValue: new Guid("9b773e21-4ee4-4e50-adc7-1edb42dbcfb1"),
                column: "Ngaytao",
                value: new DateTime(2022, 7, 6, 2, 27, 38, 693, DateTimeKind.Utc).AddTicks(8797));

            migrationBuilder.UpdateData(
                table: "DmThongbao",
                keyColumn: "Id",
                keyValue: new Guid("b079a0b9-50b1-4e54-af26-96f1e6576926"),
                column: "Ngaytao",
                value: new DateTime(2022, 7, 6, 2, 27, 38, 693, DateTimeKind.Utc).AddTicks(8556));

            migrationBuilder.UpdateData(
                table: "Soquanlykenh",
                keyColumn: "Id",
                keyValue: new Guid("46988f74-1475-4283-a128-dda4f4b16094"),
                columns: new[] { "Ngaysua", "Ngaytao", "Ngayvaoso" },
                values: new object[] { new DateTime(2022, 7, 6, 2, 27, 38, 694, DateTimeKind.Utc).AddTicks(1856), new DateTime(2022, 7, 6, 2, 27, 38, 694, DateTimeKind.Utc).AddTicks(1854), new DateTime(2022, 7, 6, 2, 27, 38, 694, DateTimeKind.Utc).AddTicks(1857) });

            migrationBuilder.UpdateData(
                table: "Soquanlykenh",
                keyColumn: "Id",
                keyValue: new Guid("565b84a8-792f-4bcc-a701-1c7aae1930f0"),
                columns: new[] { "Ngaysua", "Ngaytao", "Ngayvaoso" },
                values: new object[] { new DateTime(2022, 7, 6, 2, 27, 38, 694, DateTimeKind.Utc).AddTicks(1210), new DateTime(2022, 7, 6, 2, 27, 38, 694, DateTimeKind.Utc).AddTicks(985), new DateTime(2022, 7, 6, 2, 27, 38, 694, DateTimeKind.Utc).AddTicks(1429) });

            migrationBuilder.UpdateData(
                table: "ThongsoHethong",
                keyColumn: "Id",
                keyValue: new Guid("9645cf84-11af-485f-8b90-fd34f3d7f26a"),
                columns: new[] { "CreateDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 7, 6, 2, 27, 38, 696, DateTimeKind.Utc).AddTicks(2786), new DateTime(2022, 7, 6, 2, 27, 38, 696, DateTimeKind.Utc).AddTicks(3020) });
        }
    }
}
