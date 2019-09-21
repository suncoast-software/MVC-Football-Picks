using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Football_Picks.Data.Migrations
{
    public partial class addweekandyear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Week",
                table: "PlayerPicks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Year",
                table: "PlayerPicks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Week",
                table: "PlayerPicks");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "PlayerPicks");
        }
    }
}
