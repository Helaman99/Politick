using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Politick.Api.Migrations
{
    /// <inheritdoc />
    public partial class SuspensionStuff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Suspended",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TimesSuspended",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnsuspendDay",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Suspended",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TimesSuspended",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UnsuspendDay",
                table: "AspNetUsers");
        }
    }
}
