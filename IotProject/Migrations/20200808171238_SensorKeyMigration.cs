using Microsoft.EntityFrameworkCore.Migrations;

namespace IotProject.Migrations
{
    public partial class SensorKeyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Device_AspNetUsers_UserId",
                table: "Device");

            migrationBuilder.AddColumn<string>(
                name: "SensorKey",
                table: "Sensor",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Device",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255) CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Device_AspNetUsers_UserId",
                table: "Device",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Device_AspNetUsers_UserId",
                table: "Device");

            migrationBuilder.DropColumn(
                name: "SensorKey",
                table: "Sensor");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Device",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Device_AspNetUsers_UserId",
                table: "Device",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
