using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HCAPatientPortalPOC.Migrations
{
    /// <inheritdoc />
    public partial class AddScheduleSlotAvailable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "ScheduleSlots");

            migrationBuilder.AddColumn<bool>(
                name: "Available",
                table: "ScheduleSlots",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Available",
                table: "ScheduleSlots");

            migrationBuilder.AddColumn<int>(
                name: "AppointmentId",
                table: "ScheduleSlots",
                type: "INTEGER",
                nullable: true);
        }
    }
}
