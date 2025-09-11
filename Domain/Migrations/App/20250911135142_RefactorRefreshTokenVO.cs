using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Worklyn_backend.Domain.Migrations.App
{
    /// <inheritdoc />
    public partial class RefactorRefreshTokenVO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalDays",
                table: "LeaveRequests");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "EmployeeProfiles",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Companies",
                newName: "Street");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Street",
                table: "EmployeeProfiles",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Companies",
                newName: "Address");

            migrationBuilder.AddColumn<int>(
                name: "TotalDays",
                table: "LeaveRequests",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
