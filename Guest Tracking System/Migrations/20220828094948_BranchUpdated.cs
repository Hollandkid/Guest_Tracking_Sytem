using Microsoft.EntityFrameworkCore.Migrations;

namespace Guest_Tracking_System.Migrations
{
    public partial class BranchUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "Branches");

            migrationBuilder.AddColumn<string>(
                name: "StaffEmail",
                table: "Branches",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StaffEmail",
                table: "Branches");

            migrationBuilder.AddColumn<int>(
                name: "StaffId",
                table: "Branches",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
