using Microsoft.EntityFrameworkCore.Migrations;

namespace LifinAPI.Migrations
{
    public partial class BdeOwnerMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Bdes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bdes_OwnerId",
                table: "Bdes",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bdes_Users_OwnerId",
                table: "Bdes",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bdes_Users_OwnerId",
                table: "Bdes");

            migrationBuilder.DropIndex(
                name: "IX_Bdes_OwnerId",
                table: "Bdes");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Bdes");
        }
    }
}
