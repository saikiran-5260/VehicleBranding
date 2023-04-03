using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DomainLL.Migrations
{
    /// <inheritdoc />
    public partial class updatedVehicleColorMappinglatest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
