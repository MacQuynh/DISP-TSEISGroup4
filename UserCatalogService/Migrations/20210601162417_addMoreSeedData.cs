using Microsoft.EntityFrameworkCore.Migrations;

namespace UserCatalogService.Migrations
{
    public partial class addMoreSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Share",
                keyColumn: "Id",
                keyValue: "AAPL");

            migrationBuilder.InsertData(
                table: "Share",
                columns: new[] { "Id", "UserCatalogId" },
                values: new object[,]
                {
                    { "12224", "20" },
                    { "12226", "20" }
                });

            migrationBuilder.InsertData(
                table: "UserCatalog",
                columns: new[] { "Id", "Capital", "Name" },
                values: new object[,]
                {
                    { "1", 200.09999999999999, "Trang" },
                    { "2", 300.10000000000002, "Mads" },
                    { "3", 400.10000000000002, "Randi" }
                });

            migrationBuilder.InsertData(
                table: "Share",
                columns: new[] { "Id", "UserCatalogId" },
                values: new object[] { "12227", "1" });

            migrationBuilder.InsertData(
                table: "Share",
                columns: new[] { "Id", "UserCatalogId" },
                values: new object[] { "12228", "2" });

            migrationBuilder.InsertData(
                table: "Share",
                columns: new[] { "Id", "UserCatalogId" },
                values: new object[] { "12229", "3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Share",
                keyColumn: "Id",
                keyValue: "12224");

            migrationBuilder.DeleteData(
                table: "Share",
                keyColumn: "Id",
                keyValue: "12226");

            migrationBuilder.DeleteData(
                table: "Share",
                keyColumn: "Id",
                keyValue: "12227");

            migrationBuilder.DeleteData(
                table: "Share",
                keyColumn: "Id",
                keyValue: "12228");

            migrationBuilder.DeleteData(
                table: "Share",
                keyColumn: "Id",
                keyValue: "12229");

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

            migrationBuilder.InsertData(
                table: "Share",
                columns: new[] { "Id", "UserCatalogId" },
                values: new object[] { "AAPL", "20" });
        }
    }
}
