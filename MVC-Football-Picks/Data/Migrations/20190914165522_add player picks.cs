using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_Football_Picks.Data.Migrations
{
    public partial class addplayerpicks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Players",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Players",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Players",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Players",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "PlayerPicks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlayerId = table.Column<int>(nullable: false),
                    Pick1 = table.Column<string>(nullable: true),
                    Pick2 = table.Column<string>(nullable: true),
                    Pick3 = table.Column<string>(nullable: true),
                    Pick4 = table.Column<string>(nullable: true),
                    Pick5 = table.Column<string>(nullable: true),
                    Pick6 = table.Column<string>(nullable: true),
                    Pick7 = table.Column<string>(nullable: true),
                    Pick8 = table.Column<string>(nullable: true),
                    Pick9 = table.Column<string>(nullable: true),
                    Pick10 = table.Column<string>(nullable: true),
                    Pick11 = table.Column<string>(nullable: true),
                    Pick12 = table.Column<string>(nullable: true),
                    Pick13 = table.Column<string>(nullable: true),
                    Pick14 = table.Column<string>(nullable: true),
                    Pick15 = table.Column<string>(nullable: true),
                    Pick16 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerPicks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerPicks_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerPicks_PlayerId",
                table: "PlayerPicks",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerPicks");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Players",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Players",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Players",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Players",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
