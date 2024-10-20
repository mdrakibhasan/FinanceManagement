using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pos.Infrustructure.Migrations
{
    public partial class acctypeinreportseting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountsType",
                table: "AccountsReportSettingDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 12, 20, 12, 39, 22, 709, DateTimeKind.Unspecified).AddTicks(5168), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 12, 20, 12, 39, 22, 711, DateTimeKind.Unspecified).AddTicks(9740), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 12, 20, 12, 39, 22, 729, DateTimeKind.Unspecified).AddTicks(2175), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 12, 20, 12, 39, 22, 729, DateTimeKind.Unspecified).AddTicks(2965), new TimeSpan(0, 6, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountsType",
                table: "AccountsReportSettingDetails");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 12, 19, 15, 47, 5, 546, DateTimeKind.Unspecified).AddTicks(2616), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 12, 19, 15, 47, 5, 548, DateTimeKind.Unspecified).AddTicks(2212), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 12, 19, 15, 47, 5, 564, DateTimeKind.Unspecified).AddTicks(8018), new TimeSpan(0, 6, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 12, 19, 15, 47, 5, 564, DateTimeKind.Unspecified).AddTicks(8854), new TimeSpan(0, 6, 0, 0, 0)));
        }
    }
}
