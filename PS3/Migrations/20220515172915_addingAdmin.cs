using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PS3.Migrations
{
    public partial class addingAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "adminId",
                table: "User",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_User_adminId",
                table: "User",
                column: "adminId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_AspNetUsers_adminId",
                table: "User",
                column: "adminId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_AspNetUsers_adminId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_adminId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "adminId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
