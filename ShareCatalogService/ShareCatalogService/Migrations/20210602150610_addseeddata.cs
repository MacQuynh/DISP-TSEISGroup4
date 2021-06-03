using Microsoft.EntityFrameworkCore.Migrations;

namespace ShareCatalogService.Migrations
{
    public partial class addseeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Shares",
                keyColumn: "Id",
                keyValue: "123456",
                column: "UserId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "Shares",
                keyColumn: "Id",
                keyValue: "123457",
                columns: new[] { "ForSale", "Name", "Tax", "UserId", "Value" },
                values: new object[] { false, "AP. Møller", 0f, "2", 1000f });

            migrationBuilder.InsertData(
                table: "Shares",
                columns: new[] { "Id", "ForSale", "Name", "Tax", "UserId", "Value" },
                values: new object[,]
                {
                    { "615246", false, "Norwegian", 0f, "7", 7f },
                    { "615245", false, "Norwegian", 0f, "6", 7f },
                    { "615244", false, "Norwegian", 0f, "5", 7f },
                    { "615243", false, "Norwegian", 0f, "4", 7f },
                    { "162537", false, "Salling Group", 0f, "3", 340f },
                    { "162536", false, "Salling Group", 0f, "2", 340f },
                    { "162535", false, "Salling Group", 0f, "1", 340f },
                    { "654324", false, "Carlsberg", 0f, "9", 100f },
                    { "654323", false, "Carlsberg", 0f, "8", 100f },
                    { "654322", false, "Carlsberg", 0f, "7", 100f },
                    { "654321", false, "Carlsberg", 0f, "6", 100f },
                    { "123460", false, "AP. Møller", 0f, "5", 1000f },
                    { "123459", false, "AP. Møller", 0f, "4", 1000f },
                    { "162534", false, "Salling Group", 0f, "10", 340f },
                    { "123458", false, "AP. Møller", 0f, "3", 1000f }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Shares",
                keyColumn: "Id",
                keyValue: "123458");

            migrationBuilder.DeleteData(
                table: "Shares",
                keyColumn: "Id",
                keyValue: "123459");

            migrationBuilder.DeleteData(
                table: "Shares",
                keyColumn: "Id",
                keyValue: "123460");

            migrationBuilder.DeleteData(
                table: "Shares",
                keyColumn: "Id",
                keyValue: "162534");

            migrationBuilder.DeleteData(
                table: "Shares",
                keyColumn: "Id",
                keyValue: "162535");

            migrationBuilder.DeleteData(
                table: "Shares",
                keyColumn: "Id",
                keyValue: "162536");

            migrationBuilder.DeleteData(
                table: "Shares",
                keyColumn: "Id",
                keyValue: "162537");

            migrationBuilder.DeleteData(
                table: "Shares",
                keyColumn: "Id",
                keyValue: "615243");

            migrationBuilder.DeleteData(
                table: "Shares",
                keyColumn: "Id",
                keyValue: "615244");

            migrationBuilder.DeleteData(
                table: "Shares",
                keyColumn: "Id",
                keyValue: "615245");

            migrationBuilder.DeleteData(
                table: "Shares",
                keyColumn: "Id",
                keyValue: "615246");

            migrationBuilder.DeleteData(
                table: "Shares",
                keyColumn: "Id",
                keyValue: "654321");

            migrationBuilder.DeleteData(
                table: "Shares",
                keyColumn: "Id",
                keyValue: "654322");

            migrationBuilder.DeleteData(
                table: "Shares",
                keyColumn: "Id",
                keyValue: "654323");

            migrationBuilder.DeleteData(
                table: "Shares",
                keyColumn: "Id",
                keyValue: "654324");

            migrationBuilder.UpdateData(
                table: "Shares",
                keyColumn: "Id",
                keyValue: "123456",
                column: "UserId",
                value: "Mads Mikkelsen");

            migrationBuilder.UpdateData(
                table: "Shares",
                keyColumn: "Id",
                keyValue: "123457",
                columns: new[] { "ForSale", "Name", "Tax", "UserId", "Value" },
                values: new object[] { true, "Carlsberg", 1f, "Mads Mikkelsen", 100f });

            migrationBuilder.InsertData(
                table: "Shares",
                columns: new[] { "Id", "ForSale", "Name", "Tax", "UserId", "Value" },
                values: new object[,]
                {
                    { "123357", true, "AP. Møller", 10f, "Randi", 1000f },
                    { "122257", true, "AP. Møller", 10f, "Trang", 1000f },
                    { "123227", false, "Carlsberg", 0f, "Trang", 100f }
                });
        }
    }
}
