using Microsoft.EntityFrameworkCore.Migrations;

namespace N_WORD.Migrations
{
    public partial class examplesentence_in_word : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExampleSentance",
                table: "Words",
                newName: "ExampleSentence");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExampleSentence",
                table: "Words",
                newName: "ExampleSentance");
        }
    }
}
