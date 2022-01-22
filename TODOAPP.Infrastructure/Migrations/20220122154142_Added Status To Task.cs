using Microsoft.EntityFrameworkCore.Migrations;

namespace TODOAPP.Infrastructure.Migrations
{
    public partial class AddedStatusToTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "TodoTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "TodoTasks");
        }
    }
}
