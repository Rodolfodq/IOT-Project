using Microsoft.EntityFrameworkCore.Migrations;

namespace IotProject.Migrations
{
    public partial class SensorTokenMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SensorKey",
                table: "Sensor");

            migrationBuilder.AddColumn<string>(
                name: "SensorToken",
                table: "Sensor",
                maxLength: 8,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SensorToken",
                table: "Sensor");

            migrationBuilder.AddColumn<string>(
                name: "SensorKey",
                table: "Sensor",
                type: "varchar(8) CHARACTER SET utf8mb4",
                maxLength: 8,
                nullable: true);
        }
    }
}
