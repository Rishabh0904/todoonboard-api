using Microsoft.EntityFrameworkCore.Migrations;

namespace todoonboard_api.Migrations
{
    public partial class addingBoardIdForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "updatedAt",
                table: "Todos",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "done",
                table: "Todos",
                newName: "Done");

            migrationBuilder.RenameColumn(
                name: "createdAt",
                table: "Todos",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "boardId",
                table: "Todos",
                newName: "BoardId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Boards",
                newName: "Name");

            migrationBuilder.AlterColumn<int>(
                name: "BoardId",
                table: "Todos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Todos_BoardId",
                table: "Todos",
                column: "BoardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_Boards_BoardId",
                table: "Todos",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_Boards_BoardId",
                table: "Todos");

            migrationBuilder.DropIndex(
                name: "IX_Todos_BoardId",
                table: "Todos");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Todos",
                newName: "updatedAt");

            migrationBuilder.RenameColumn(
                name: "Done",
                table: "Todos",
                newName: "done");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Todos",
                newName: "createdAt");

            migrationBuilder.RenameColumn(
                name: "BoardId",
                table: "Todos",
                newName: "boardId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Boards",
                newName: "name");

            migrationBuilder.AlterColumn<int>(
                name: "boardId",
                table: "Todos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
