using Microsoft.EntityFrameworkCore.Migrations;

namespace IotProject.Migrations
{
    public partial class AlterIdUserDeviceMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Device",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Device_UserId",
                table: "Device",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Device_AspNetUsers_UserId",
                table: "Device",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Device_AspNetUsers_UserId",
                table: "Device");

            migrationBuilder.DropIndex(
                name: "IX_Device_UserId",
                table: "Device");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Device");

            migrationBuilder.AddColumn<string>(
                name: "IdUserId",
                table: "Device",
                type: "varchar(255) CHARACTER SET utf8mb4",
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
    }
}
