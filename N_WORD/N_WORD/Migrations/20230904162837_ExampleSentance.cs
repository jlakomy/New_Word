using Microsoft.EntityFrameworkCore.Migrations;

namespace N_WORD.Migrations
{
    public partial class ExampleSentance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExampleSentance",
                table: "Words",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExampleSentance",
                table: "Words");
        }
    }
}
