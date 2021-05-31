using Microsoft.EntityFrameworkCore.Migrations;

namespace ShareCatalogService.Migrations
{
    public partial class somethingNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shares_User_OwnerId",
                table: "Shares");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_Shares_OwnerId",
                table: "Shares");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Shares");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Shares",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Shares",
                columns: new[] { "Id", "ForSale", "Name", "Tax", "UserId", "Value" },
                values: new object[] { "123456", false, "AP. Møller", 0f, "Mads Mikkelsen", 100f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Shares",
                keyColumn: "Id",
                keyValue: "123456");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Shares");

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Shares",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shares_OwnerId",
                table: "Shares",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shares_User_OwnerId",
                table: "Shares",
                column: "OwnerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
