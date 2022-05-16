using Microsoft.EntityFrameworkCore.Migrations;

namespace todoonboard_api.Migrations
{
    public partial class changingBoardName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Boards",
                newName: "name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "Boards",
                newName: "Name");
        }
    }
}
