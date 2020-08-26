using Microsoft.EntityFrameworkCore.Migrations;

namespace IotProject.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Record_Sensor_SensorId",
                table: "Record");

            migrationBuilder.DropForeignKey(
                name: "FK_Sensor_Device_DeviceId",
                table: "Sensor");

            migrationBuilder.DropIndex(
                name: "IX_Sensor_DeviceId",
                table: "Sensor");

            migrationBuilder.DropIndex(
                name: "IX_Record_SensorId",
                table: "Record");

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "Record",
                maxLength: 6,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Unit",
                table: "Record");

            migrationBuilder.CreateIndex(
                name: "IX_Sensor_DeviceId",
                table: "Sensor",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Record_SensorId",
                table: "Record",
                column: "SensorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Record_Sensor_SensorId",
                table: "Record",
                column: "SensorId",
                principalTable: "Sensor",
                principalColumn: "SensorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sensor_Device_DeviceId",
                table: "Sensor",
                column: "DeviceId",
                principalTable: "Device",
                principalColumn: "DeviceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
