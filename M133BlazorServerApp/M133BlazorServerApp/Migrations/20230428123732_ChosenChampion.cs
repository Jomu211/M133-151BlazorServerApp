using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace M133BlazorServerApp.Migrations
{
    /// <inheritdoc />
    public partial class ChosenChampion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ChosenChampion",
                table: "GameChampions",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChosenChampion",
                table: "GameChampions");
        }
    }
}
