using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DomainLL.Migrations
{
    /// <inheritdoc />
    public partial class updatedVehicleColorMapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VehicleName",
                table: "VehicleColorMapping");

            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "VehicleColorMapping",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "VehicleColorMapping");

            migrationBuilder.AddColumn<string>(
                name: "VehicleName",
                table: "VehicleColorMapping",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
