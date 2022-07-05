using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AMGAPI.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Dangkykenh",
                keyColumn: "Id",
                keyValue: new Guid("37f70f55-7dcb-4ca5-b0c8-7466b9cedf3d"),
                columns: new[] { "Ngayduyet", "Ngaysua", "Ngaytao" },
                values: new object[] { new DateTime(2022, 6, 29, 7, 18, 41, 290, DateTimeKind.Utc).AddTicks(7657), new DateTime(2022, 6, 29, 7, 18, 41, 290, DateTimeKind.Utc).AddTicks(7654), new DateTime(2022, 6, 29, 7, 18, 41, 290, DateTimeKind.Utc).AddTicks(7649) });

            migrationBuilder.UpdateData(
                table: "Dangkykenh",
                keyColumn: "Id",
                keyValue: new Guid("e0f582de-420f-4902-8cee-cf85389cc6bf"),
                columns: new[] { "Ngayduyet", "Ngaysua", "Ngaytao" },
                values: new object[] { new DateTime(2022, 6, 29, 7, 18, 41, 290, DateTimeKind.Utc).AddTicks(6401), new DateTime(2022, 6, 29, 7, 18, 41, 290, DateTimeKind.Utc).AddTicks(5362), new DateTime(2022, 6, 29, 7, 18, 41, 290, DateTimeKind.Utc).AddTicks(4796) });

            migrationBuilder.UpdateData(
                table: "Dangkykenh_Duyet",
                keyColumn: "Id",
                keyValue: new Guid("6746de28-4d95-4a77-96de-c75a8eb80bc4"),
                columns: new[] { "NgayTao", "Ngaysua" },
                values: new object[] { new DateTime(2022, 6, 29, 7, 18, 41, 291, DateTimeKind.Utc).AddTicks(2801), new DateTime(2022, 6, 29, 7, 18, 41, 291, DateTimeKind.Utc).AddTicks(3302) });

            migrationBuilder.UpdateData(
                table: "Dangkykenh_Duyet",
                keyColumn: "Id",
                keyValue: new Guid("97c3636d-cff0-4b80-b426-dc299e373053"),
                columns: new[] { "NgayTao", "Ngaysua" },
                values: new object[] { new DateTime(2022, 6, 29, 7, 18, 41, 291, DateTimeKind.Utc).AddTicks(4763), new DateTime(2022, 6, 29, 7, 18, 41, 291, DateTimeKind.Utc).AddTicks(4766) });

            migrationBuilder.InsertData(
                table: "DmRole_Feature",
                columns: new[] { "Id", "AllowAdd", "AllowDelete", "AllowDuyet", "AllowEdit", "AllowView", "FeatureId", "RoleId", "is_Delete" },
                values: new object[,]
                {
                    { new Guid("b5b9fcc6-1bb8-4576-982b-530d3429861c"), true, true, true, true, true, new Guid("3e062997-8d32-454b-8f56-874ca6fc0b82"), new Guid("830da2e4-c293-4026-b2e6-29ad8c935def"), false },
                    { new Guid("cf82e238-aef6-4145-8674-73fa21be5c1d"), true, true, true, true, true, new Guid("f42719ed-dd92-4c46-9ac3-c85ffd192c69"), new Guid("830da2e4-c293-4026-b2e6-29ad8c935def"), false },
                    { new Guid("6e7cc4c4-a3c6-42cc-9772-2e83abdc18b3"), true, true, true, true, true, new Guid("90937fa7-9ac9-44e6-8aad-1cb9f73aa4c7"), new Guid("830da2e4-c293-4026-b2e6-29ad8c935def"), false },
                    { new Guid("9e87e047-2c57-4e40-8b69-ae478861f07a"), true, true, true, true, true, new Guid("b41759f2-2d93-419b-b527-095269951534"), new Guid("830da2e4-c293-4026-b2e6-29ad8c935def"), false },
                    { new Guid("17f71279-793d-4b2a-a12c-a9f4013bb779"), true, true, true, true, true, new Guid("de976e05-5749-44c2-ba10-057e2aff7881"), new Guid("830da2e4-c293-4026-b2e6-29ad8c935def"), false }
                });

            migrationBuilder.UpdateData(
                table: "DmThongbao",
                keyColumn: "Id",
                keyValue: new Guid("9b773e21-4ee4-4e50-adc7-1edb42dbcfb1"),
                column: "Ngaytao",
                value: new DateTime(2022, 6, 29, 7, 18, 41, 291, DateTimeKind.Utc).AddTicks(8169));

            migrationBuilder.UpdateData(
                table: "DmThongbao",
                keyColumn: "Id",
                keyValue: new Guid("b079a0b9-50b1-4e54-af26-96f1e6576926"),
                column: "Ngaytao",
                value: new DateTime(2022, 6, 29, 7, 18, 41, 291, DateTimeKind.Utc).AddTicks(7566));

            migrationBuilder.UpdateData(
                table: "Soquanlykenh",
                keyColumn: "Id",
                keyValue: new Guid("46988f74-1475-4283-a128-dda4f4b16094"),
                columns: new[] { "Ngaysua", "Ngaytao", "Ngayvaoso" },
                values: new object[] { new DateTime(2022, 6, 29, 7, 18, 41, 292, DateTimeKind.Utc).AddTicks(4779), new DateTime(2022, 6, 29, 7, 18, 41, 292, DateTimeKind.Utc).AddTicks(4775), new DateTime(2022, 6, 29, 7, 18, 41, 292, DateTimeKind.Utc).AddTicks(4781) });

            migrationBuilder.UpdateData(
                table: "Soquanlykenh",
                keyColumn: "Id",
                keyValue: new Guid("565b84a8-792f-4bcc-a701-1c7aae1930f0"),
                columns: new[] { "Ngaysua", "Ngaytao", "Ngayvaoso" },
                values: new object[] { new DateTime(2022, 6, 29, 7, 18, 41, 292, DateTimeKind.Utc).AddTicks(3555), new DateTime(2022, 6, 29, 7, 18, 41, 292, DateTimeKind.Utc).AddTicks(3119), new DateTime(2022, 6, 29, 7, 18, 41, 292, DateTimeKind.Utc).AddTicks(3965) });

            migrationBuilder.UpdateData(
                table: "ThongsoHethong",
                keyColumn: "Id",
                keyValue: new Guid("9645cf84-11af-485f-8b90-fd34f3d7f26a"),
                columns: new[] { "CreateDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 6, 29, 7, 18, 41, 295, DateTimeKind.Utc).AddTicks(4830), new DateTime(2022, 6, 29, 7, 18, 41, 295, DateTimeKind.Utc).AddTicks(5110) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DmRole_Feature",
                keyColumn: "Id",
                keyValue: new Guid("17f71279-793d-4b2a-a12c-a9f4013bb779"));

            migrationBuilder.DeleteData(
                table: "DmRole_Feature",
                keyColumn: "Id",
                keyValue: new Guid("6e7cc4c4-a3c6-42cc-9772-2e83abdc18b3"));

            migrationBuilder.DeleteData(
                table: "DmRole_Feature",
                keyColumn: "Id",
                keyValue: new Guid("9e87e047-2c57-4e40-8b69-ae478861f07a"));

            migrationBuilder.DeleteData(
                table: "DmRole_Feature",
                keyColumn: "Id",
                keyValue: new Guid("b5b9fcc6-1bb8-4576-982b-530d3429861c"));

            migrationBuilder.DeleteData(
                table: "DmRole_Feature",
                keyColumn: "Id",
                keyValue: new Guid("cf82e238-aef6-4145-8674-73fa21be5c1d"));

            migrationBuilder.UpdateData(
                table: "Dangkykenh",
                keyColumn: "Id",
                keyValue: new Guid("37f70f55-7dcb-4ca5-b0c8-7466b9cedf3d"),
                columns: new[] { "Ngayduyet", "Ngaysua", "Ngaytao" },
                values: new object[] { new DateTime(2022, 6, 28, 3, 4, 57, 687, DateTimeKind.Utc).AddTicks(1594), new DateTime(2022, 6, 28, 3, 4, 57, 687, DateTimeKind.Utc).AddTicks(1592), new DateTime(2022, 6, 28, 3, 4, 57, 687, DateTimeKind.Utc).AddTicks(1590) });

            migrationBuilder.UpdateData(
                table: "Dangkykenh",
                keyColumn: "Id",
                keyValue: new Guid("e0f582de-420f-4902-8cee-cf85389cc6bf"),
                columns: new[] { "Ngayduyet", "Ngaysua", "Ngaytao" },
                values: new object[] { new DateTime(2022, 6, 28, 3, 4, 57, 687, DateTimeKind.Utc).AddTicks(979), new DateTime(2022, 6, 28, 3, 4, 57, 687, DateTimeKind.Utc).AddTicks(473), new DateTime(2022, 6, 28, 3, 4, 57, 687, DateTimeKind.Utc).AddTicks(211) });

            migrationBuilder.UpdateData(
                table: "Dangkykenh_Duyet",
                keyColumn: "Id",
                keyValue: new Guid("6746de28-4d95-4a77-96de-c75a8eb80bc4"),
                columns: new[] { "NgayTao", "Ngaysua" },
                values: new object[] { new DateTime(2022, 6, 28, 3, 4, 57, 687, DateTimeKind.Utc).AddTicks(3949), new DateTime(2022, 6, 28, 3, 4, 57, 687, DateTimeKind.Utc).AddTicks(4207) });

            migrationBuilder.UpdateData(
                table: "Dangkykenh_Duyet",
                keyColumn: "Id",
                keyValue: new Guid("97c3636d-cff0-4b80-b426-dc299e373053"),
                columns: new[] { "NgayTao", "Ngaysua" },
                values: new object[] { new DateTime(2022, 6, 28, 3, 4, 57, 687, DateTimeKind.Utc).AddTicks(5161), new DateTime(2022, 6, 28, 3, 4, 57, 687, DateTimeKind.Utc).AddTicks(5164) });

            migrationBuilder.UpdateData(
                table: "DmThongbao",
                keyColumn: "Id",
                keyValue: new Guid("9b773e21-4ee4-4e50-adc7-1edb42dbcfb1"),
                column: "Ngaytao",
                value: new DateTime(2022, 6, 28, 3, 4, 57, 687, DateTimeKind.Utc).AddTicks(7312));

            migrationBuilder.UpdateData(
                table: "DmThongbao",
                keyColumn: "Id",
                keyValue: new Guid("b079a0b9-50b1-4e54-af26-96f1e6576926"),
                column: "Ngaytao",
                value: new DateTime(2022, 6, 28, 3, 4, 57, 687, DateTimeKind.Utc).AddTicks(7015));

            migrationBuilder.UpdateData(
                table: "Soquanlykenh",
                keyColumn: "Id",
                keyValue: new Guid("46988f74-1475-4283-a128-dda4f4b16094"),
                columns: new[] { "Ngaysua", "Ngaytao", "Ngayvaoso" },
                values: new object[] { new DateTime(2022, 6, 28, 3, 4, 57, 688, DateTimeKind.Utc).AddTicks(1284), new DateTime(2022, 6, 28, 3, 4, 57, 688, DateTimeKind.Utc).AddTicks(1282), new DateTime(2022, 6, 28, 3, 4, 57, 688, DateTimeKind.Utc).AddTicks(1285) });

            migrationBuilder.UpdateData(
                table: "Soquanlykenh",
                keyColumn: "Id",
                keyValue: new Guid("565b84a8-792f-4bcc-a701-1c7aae1930f0"),
                columns: new[] { "Ngaysua", "Ngaytao", "Ngayvaoso" },
                values: new object[] { new DateTime(2022, 6, 28, 3, 4, 57, 688, DateTimeKind.Utc).AddTicks(419), new DateTime(2022, 6, 28, 3, 4, 57, 688, DateTimeKind.Utc).AddTicks(147), new DateTime(2022, 6, 28, 3, 4, 57, 688, DateTimeKind.Utc).AddTicks(683) });

            migrationBuilder.UpdateData(
                table: "ThongsoHethong",
                keyColumn: "Id",
                keyValue: new Guid("9645cf84-11af-485f-8b90-fd34f3d7f26a"),
                columns: new[] { "CreateDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 6, 28, 3, 4, 57, 690, DateTimeKind.Utc).AddTicks(8469), new DateTime(2022, 6, 28, 3, 4, 57, 690, DateTimeKind.Utc).AddTicks(8719) });
        }
    }
}
