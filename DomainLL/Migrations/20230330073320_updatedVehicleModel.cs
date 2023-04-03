using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DomainLL.Migrations
{
    /// <inheritdoc />
    public partial class updatedVehicleModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransmissionId",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "VehicleTypeId",
                table: "Vehicle");

            migrationBuilder.AddColumn<string>(
                name: "TransmissionName",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VehicleTypeName",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransmissionName",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "VehicleTypeName",
                table: "Vehicle");

            migrationBuilder.AddColumn<byte>(
                name: "TransmissionId",
                table: "Vehicle",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "VehicleTypeId",
                table: "Vehicle",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
