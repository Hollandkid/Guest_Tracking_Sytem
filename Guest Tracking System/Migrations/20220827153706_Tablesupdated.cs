using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Guest_Tracking_System.Migrations
{
    public partial class Tablesupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "AspNetUsers",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "AspNetUsers",
                newName: "Image");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Guests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fullname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Fullname",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "AspNetUsers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "AspNetUsers",
                newName: "FirstName");
        }
    }
}
