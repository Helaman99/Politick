using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Politick.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialPlayersCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoinsTotal = table.Column<int>(type: "int", nullable: false),
                    GudosTotal = table.Column<int>(type: "int", nullable: false),
                    GamesTotal = table.Column<int>(type: "int", nullable: false),
                    KudosOverall = table.Column<int>(type: "int", nullable: false),
                    Authoritarian = table.Column<int>(type: "int", nullable: false),
                    Left = table.Column<int>(type: "int", nullable: false),
                    Libertarian = table.Column<int>(type: "int", nullable: false),
                    Right = table.Column<int>(type: "int", nullable: false),
                    Strikes = table.Column<int>(type: "int", nullable: false),
                    Theme = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activation = table.Column<int>(type: "int", nullable: false),
                    ActualStanding = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MyString",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlayerId = table.Column<int>(type: "int", nullable: true),
                    PlayerId1 = table.Column<int>(type: "int", nullable: true),
                    PlayerId2 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyString", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MyString_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MyString_Players_PlayerId1",
                        column: x => x.PlayerId1,
                        principalTable: "Players",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MyString_Players_PlayerId2",
                        column: x => x.PlayerId2,
                        principalTable: "Players",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyString");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
