using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Politick.Api.Migrations
{
    /// <inheritdoc />
    public partial class MyStringRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyString");

            migrationBuilder.AddColumn<string>(
                name: "UnlockedAvatars",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UnlockedTitleFirstWords",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UnlockedTitleSecondWords",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnlockedAvatars",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UnlockedTitleFirstWords",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UnlockedTitleSecondWords",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "MyString",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PlayerId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PlayerId2 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyString", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MyString_AspNetUsers_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MyString_AspNetUsers_PlayerId1",
                        column: x => x.PlayerId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MyString_AspNetUsers_PlayerId2",
                        column: x => x.PlayerId2,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MyString_PlayerId",
                table: "MyString",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_MyString_PlayerId1",
                table: "MyString",
                column: "PlayerId1");

            migrationBuilder.CreateIndex(
                name: "IX_MyString_PlayerId2",
                table: "MyString",
                column: "PlayerId2");
        }
    }
}
