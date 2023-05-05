using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace M133BlazorServerApp.Migrations
{
    /// <inheritdoc />
    public partial class AddHiddenChampionField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Head_GameChampions_GameChampionId",
                table: "Head");

            migrationBuilder.DropIndex(
                name: "IX_Head_GameChampionId",
                table: "Head");

            migrationBuilder.AlterColumn<int>(
                name: "GameChampionId",
                table: "Head",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Hidden",
                table: "GameChampions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Head_GameChampionId",
                table: "Head",
                column: "GameChampionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Head_GameChampions_GameChampionId",
                table: "Head",
                column: "GameChampionId",
                principalTable: "GameChampions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Head_GameChampions_GameChampionId",
                table: "Head");

            migrationBuilder.DropIndex(
                name: "IX_Head_GameChampionId",
                table: "Head");

            migrationBuilder.DropColumn(
                name: "Hidden",
                table: "GameChampions");

            migrationBuilder.AlterColumn<int>(
                name: "GameChampionId",
                table: "Head",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Head_GameChampionId",
                table: "Head",
                column: "GameChampionId",
                unique: true,
                filter: "[GameChampionId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Head_GameChampions_GameChampionId",
                table: "Head",
                column: "GameChampionId",
                principalTable: "GameChampions",
                principalColumn: "Id");
        }
    }
}
