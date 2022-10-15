using Microsoft.EntityFrameworkCore.Migrations;

namespace Guest_Tracking_System.Migrations
{
    public partial class BranchandapplicationTableUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StaffId",
                table: "Branches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "AspNetUsers");
        }
    }
}
