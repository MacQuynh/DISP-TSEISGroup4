using Microsoft.EntityFrameworkCore.Migrations;

namespace UserCatalogService.Migrations
{
    public partial class updateToListOfStrings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Share");

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

            migrationBuilder.AddColumn<string>(
                name: "ShareIds",
                table: "UserCatalog",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "UserCatalog",
                keyColumn: "Id",
                keyValue: "20",
                column: "ShareIds",
                value: "12224,12225");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShareIds",
                table: "UserCatalog");

            migrationBuilder.CreateTable(
                name: "Share",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserCatalogId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Share", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Share_UserCatalog_UserCatalogId",
                        column: x => x.UserCatalogId,
                        principalTable: "UserCatalog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Share_UserCatalogId",
                table: "Share",
                column: "UserCatalogId");
        }
    }
}
