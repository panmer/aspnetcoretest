using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gcsharpRPC.Migrations
{
    public partial class AddStartEndTimeToPoll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EndTime",
                table: "PollOptions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StartTime",
                table: "PollOptions",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "PollOptions");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "PollOptions");
        }
    }
}
