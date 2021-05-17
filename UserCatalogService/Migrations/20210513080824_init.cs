using Microsoft.EntityFrameworkCore.Migrations;

namespace UserCatalogService.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserCatalog",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Capital = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCatalog", x => x.Id);
                });

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
                table: "UserCatalog",
                columns: new[] { "Id", "Capital", "Name" },
                values: new object[] { "20", 100.09999999999999, "Ida Hansen" });

            migrationBuilder.InsertData(
                table: "Share",
                columns: new[] { "Id", "UserCatalogId" },
                values: new object[] { "AAPL", "20" });

            migrationBuilder.CreateIndex(
                name: "IX_Share_UserCatalogId",
                table: "Share",
                column: "UserCatalogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Share");

            migrationBuilder.DropTable(
                name: "UserCatalog");
        }
    }
}
