using Microsoft.EntityFrameworkCore.Migrations;

namespace UserCatalogService.Migrations
{
    public partial class changedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserCatalog",
                keyColumn: "Id",
                keyValue: "20");

            migrationBuilder.UpdateData(
                table: "UserCatalog",
                keyColumn: "Id",
                keyValue: "1",
                column: "ShareIds",
                value: "123456,162535");

            migrationBuilder.UpdateData(
                table: "UserCatalog",
                keyColumn: "Id",
                keyValue: "2",
                column: "ShareIds",
                value: "123457,162536");

            migrationBuilder.UpdateData(
                table: "UserCatalog",
                keyColumn: "Id",
                keyValue: "3",
                column: "ShareIds",
                value: "123458,162537");

            migrationBuilder.InsertData(
                table: "UserCatalog",
                columns: new[] { "Id", "Capital", "Name", "ShareIds" },
                values: new object[,]
                {
                    { "4", 100.09999999999999, "Alexander", "123459,615243" },
                    { "5", 50.100000000000001, "Jonas", "123460,615244" },
                    { "6", 700.60000000000002, "Thanh", "654321,615245" },
                    { "7", 1000.8, "Nikolaj", "654322,615246" },
                    { "8", 109.8, "Frank", "654323" },
                    { "9", 1650.77, "Poul", "654324" },
                    { "10", 980.60000000000002, "Jenny", "162534" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserCatalog",
                keyColumn: "Id",
                keyValue: "10");

            migrationBuilder.DeleteData(
                table: "UserCatalog",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "UserCatalog",
                keyColumn: "Id",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "UserCatalog",
                keyColumn: "Id",
                keyValue: "6");

            migrationBuilder.DeleteData(
                table: "UserCatalog",
                keyColumn: "Id",
                keyValue: "7");

            migrationBuilder.DeleteData(
                table: "UserCatalog",
                keyColumn: "Id",
                keyValue: "8");

            migrationBuilder.DeleteData(
                table: "UserCatalog",
                keyColumn: "Id",
                keyValue: "9");

            migrationBuilder.UpdateData(
                table: "UserCatalog",
                keyColumn: "Id",
                keyValue: "1",
                column: "ShareIds",
                value: "12226,12227");

            migrationBuilder.UpdateData(
                table: "UserCatalog",
                keyColumn: "Id",
                keyValue: "2",
                column: "ShareIds",
                value: "12228");

            migrationBuilder.UpdateData(
                table: "UserCatalog",
                keyColumn: "Id",
                keyValue: "3",
                column: "ShareIds",
                value: "12229");

            migrationBuilder.InsertData(
                table: "UserCatalog",
                columns: new[] { "Id", "Capital", "Name", "ShareIds" },
                values: new object[] { "20", 100.09999999999999, "Ida Hansen", "12224,12225" });
        }
    }
}
