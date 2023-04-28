using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace M133BlazorServerApp.Migrations
{
    /// <inheritdoc />
    public partial class GameChampionFixesAndAddHeadClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kopf",
                table: "GameChampions");

            migrationBuilder.CreateTable(
                name: "Head",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Haaresfarbe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kopfbedeckung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Anderes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameChampionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Head", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Head_GameChampions_GameChampionId",
                        column: x => x.GameChampionId,
                        principalTable: "GameChampions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Head_GameChampionId",
                table: "Head",
                column: "GameChampionId",
                unique: true,
                filter: "[GameChampionId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Head");

            migrationBuilder.AddColumn<string>(
                name: "Kopf",
                table: "GameChampions",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
