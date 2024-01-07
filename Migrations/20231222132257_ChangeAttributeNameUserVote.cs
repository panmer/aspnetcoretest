using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gcsharpRPC.Migrations
{
    public partial class ChangeAttributeNameUserVote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PollOption_Polls_PollId",
                table: "PollOption");

            migrationBuilder.DropForeignKey(
                name: "FK_PollOptionUserVote_PollOption_OptionsId",
                table: "PollOptionUserVote");

            migrationBuilder.DropForeignKey(
                name: "FK_PollOptionUserVote_UserVote_UserVotesId",
                table: "PollOptionUserVote");

            migrationBuilder.DropForeignKey(
                name: "FK_UserVote_Polls_PollId",
                table: "UserVote");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserVote",
                table: "UserVote");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PollOption",
                table: "PollOption");

            migrationBuilder.RenameTable(
                name: "UserVote",
                newName: "UserVotes");

            migrationBuilder.RenameTable(
                name: "PollOption",
                newName: "PollOptions");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "UserVotes",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_UserVote_PollId",
                table: "UserVotes",
                newName: "IX_UserVotes_PollId");

            migrationBuilder.RenameIndex(
                name: "IX_PollOption_PollId",
                table: "PollOptions",
                newName: "IX_PollOptions_PollId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserVotes",
                table: "UserVotes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PollOptions",
                table: "PollOptions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PollOptions_Polls_PollId",
                table: "PollOptions",
                column: "PollId",
                principalTable: "Polls",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PollOptionUserVote_PollOptions_OptionsId",
                table: "PollOptionUserVote",
                column: "OptionsId",
                principalTable: "PollOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PollOptionUserVote_UserVotes_UserVotesId",
                table: "PollOptionUserVote",
                column: "UserVotesId",
                principalTable: "UserVotes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserVotes_Polls_PollId",
                table: "UserVotes",
                column: "PollId",
                principalTable: "Polls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PollOptions_Polls_PollId",
                table: "PollOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_PollOptionUserVote_PollOptions_OptionsId",
                table: "PollOptionUserVote");

            migrationBuilder.DropForeignKey(
                name: "FK_PollOptionUserVote_UserVotes_UserVotesId",
                table: "PollOptionUserVote");

            migrationBuilder.DropForeignKey(
                name: "FK_UserVotes_Polls_PollId",
                table: "UserVotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserVotes",
                table: "UserVotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PollOptions",
                table: "PollOptions");

            migrationBuilder.RenameTable(
                name: "UserVotes",
                newName: "UserVote");

            migrationBuilder.RenameTable(
                name: "PollOptions",
                newName: "PollOption");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "UserVote",
                newName: "Username");

            migrationBuilder.RenameIndex(
                name: "IX_UserVotes_PollId",
                table: "UserVote",
                newName: "IX_UserVote_PollId");

            migrationBuilder.RenameIndex(
                name: "IX_PollOptions_PollId",
                table: "PollOption",
                newName: "IX_PollOption_PollId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserVote",
                table: "UserVote",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PollOption",
                table: "PollOption",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BirthYear = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PollOption_Polls_PollId",
                table: "PollOption",
                column: "PollId",
                principalTable: "Polls",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PollOptionUserVote_PollOption_OptionsId",
                table: "PollOptionUserVote",
                column: "OptionsId",
                principalTable: "PollOption",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PollOptionUserVote_UserVote_UserVotesId",
                table: "PollOptionUserVote",
                column: "UserVotesId",
                principalTable: "UserVote",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserVote_Polls_PollId",
                table: "UserVote",
                column: "PollId",
                principalTable: "Polls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
