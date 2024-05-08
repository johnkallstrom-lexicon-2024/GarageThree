using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageThree.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddHourlyRateAndRegisteredAtDefaultValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisteredAt",
                table: "Vehicle",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 8, 15, 51, 35, 444, DateTimeKind.Local).AddTicks(8116),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "HourlyRate",
                table: "Garage",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HourlyRate",
                table: "Garage");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisteredAt",
                table: "Vehicle",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 8, 15, 51, 35, 444, DateTimeKind.Local).AddTicks(8116));
        }
    }
}
