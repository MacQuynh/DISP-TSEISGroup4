using Microsoft.EntityFrameworkCore.Migrations;

namespace UserCatalogService.Migrations
{
    public partial class addSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserCatalog",
                columns: new[] { "Id", "Capital", "Name", "ShareIds" },
                values: new object[] { "1", 200.09999999999999, "Trang", "12226,12227" });

            migrationBuilder.InsertData(
                table: "UserCatalog",
                columns: new[] { "Id", "Capital", "Name", "ShareIds" },
                values: new object[] { "2", 300.10000000000002, "Mads", "12228" });

            migrationBuilder.InsertData(
                table: "UserCatalog",
                columns: new[] { "Id", "Capital", "Name", "ShareIds" },
                values: new object[] { "3", 400.10000000000002, "Randi", "12229" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserCatalog",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "UserCatalog",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "UserCatalog",
                keyColumn: "Id",
                keyValue: "3");
        }
    }
}
