using Microsoft.EntityFrameworkCore.Migrations;

namespace todoonboard_api.Migrations
{
    public partial class addingBoardIdForeignKeyagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_Boards_BoardId",
                table: "Todos");

            migrationBuilder.RenameColumn(
                name: "BoardId",
                table: "Todos",
                newName: "boardId");

            migrationBuilder.RenameIndex(
                name: "IX_Todos_BoardId",
                table: "Todos",
                newName: "IX_Todos_boardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_Boards_boardId",
                table: "Todos",
                column: "boardId",
                principalTable: "Boards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_Boards_boardId",
                table: "Todos");

            migrationBuilder.RenameColumn(
                name: "boardId",
                table: "Todos",
                newName: "BoardId");

            migrationBuilder.RenameIndex(
                name: "IX_Todos_boardId",
                table: "Todos",
                newName: "IX_Todos_BoardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_Boards_BoardId",
                table: "Todos",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
