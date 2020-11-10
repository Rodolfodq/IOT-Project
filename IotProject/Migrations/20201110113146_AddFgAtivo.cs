using Microsoft.EntityFrameworkCore.Migrations;

namespace IotProject.Migrations
{
    public partial class AddFgAtivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Device_AspNetUsers_UserId",
                table: "Device");

            migrationBuilder.DropIndex(
                name: "IX_Device_UserId",
                table: "Device");

            migrationBuilder.AddColumn<int>(
                name: "FgAtivo",
                table: "Sensor",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Device",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255) CHARACTER SET utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "FgAtivo",
                table: "Device",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FgAtivo",
                table: "Sensor");

            migrationBuilder.DropColumn(
                name: "FgAtivo",
                table: "Device");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Device",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(string));

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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
