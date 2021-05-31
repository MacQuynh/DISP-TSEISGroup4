using Microsoft.EntityFrameworkCore.Migrations;

namespace ShareCatalogService.Migrations
{
    public partial class moreShares : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Shares",
                keyColumn: "Id",
                keyValue: "123456",
                column: "Value",
                value: 1000f);

            migrationBuilder.InsertData(
                table: "Shares",
                columns: new[] { "Id", "ForSale", "Name", "Tax", "UserId", "Value" },
                values: new object[,]
                {
                    { "123457", true, "Carlsberg", 1f, "Mads Mikkelsen", 100f },
                    { "123357", true, "AP. Møller", 10f, "Randi", 1000f },
                    { "122257", true, "AP. Møller", 10f, "Trang", 1000f },
                    { "123227", false, "Carlsberg", 0f, "Trang", 100f }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Shares",
                keyColumn: "Id",
                keyValue: "122257");

            migrationBuilder.DeleteData(
                table: "Shares",
                keyColumn: "Id",
                keyValue: "123227");

            migrationBuilder.DeleteData(
                table: "Shares",
                keyColumn: "Id",
                keyValue: "123357");

            migrationBuilder.DeleteData(
                table: "Shares",
                keyColumn: "Id",
                keyValue: "123457");

            migrationBuilder.UpdateData(
                table: "Shares",
                keyColumn: "Id",
                keyValue: "123456",
                column: "Value",
                value: 100f);
        }
    }
}
