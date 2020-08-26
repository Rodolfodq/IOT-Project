using Microsoft.EntityFrameworkCore.Migrations;

namespace IotProject.Migrations
{
    public partial class IdUserDeviceMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdUserId",
                table: "Device",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Device_IdUserId",
                table: "Device",
                column: "IdUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Device_AspNetUsers_IdUserId",
                table: "Device",
                column: "IdUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Device_AspNetUsers_IdUserId",
                table: "Device");

            migrationBuilder.DropIndex(
                name: "IX_Device_IdUserId",
                table: "Device");

            migrationBuilder.DropColumn(
                name: "IdUserId",
                table: "Device");
        }
    }
}
