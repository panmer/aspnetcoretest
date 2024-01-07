using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gcsharpRPC.Migrations
{
    public partial class RemoveDescriptionAndAddSoftDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Polls");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Polls",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Polls");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Polls",
                type: "TEXT",
                nullable: true);
        }
    }
}
