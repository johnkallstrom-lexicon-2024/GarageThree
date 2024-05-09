using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageThree.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Checkout : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisteredAt",
                table: "Vehicle",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 9, 10, 52, 21, 498, DateTimeKind.Local).AddTicks(4358),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 8, 15, 51, 35, 444, DateTimeKind.Local).AddTicks(8116));

            migrationBuilder.CreateTable(
                name: "Checkout",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParkedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalParkingCost = table.Column<decimal>(type: "decimal(14,2)", precision: 14, scale: 2, nullable: false),
                    Garage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HourlyRate = table.Column<int>(type: "int", nullable: false),
                    CheckoutAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 5, 9, 10, 52, 21, 498, DateTimeKind.Local).AddTicks(5422)),
                    MemberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checkout", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Checkout_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Checkout_MemberId",
                table: "Checkout",
                column: "MemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Checkout");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisteredAt",
                table: "Vehicle",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 8, 15, 51, 35, 444, DateTimeKind.Local).AddTicks(8116),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 9, 10, 52, 21, 498, DateTimeKind.Local).AddTicks(4358));
        }
    }
}
