using Microsoft.EntityFrameworkCore.Migrations;

namespace calendar.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProjectCards",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    LaunchDate = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    BlockChain = table.Column<string>(nullable: true),
                    Supply = table.Column<int>(nullable: false),
                    WhiteListSpots = table.Column<int>(nullable: false),
                    WebSite = table.Column<string>(nullable: true),
                    Discord = table.Column<string>(nullable: true),
                    Twitter = table.Column<string>(nullable: true),
                    Inst = table.Column<string>(nullable: true),
                    Listed = table.Column<bool>(nullable: false),
                    Promoted = table.Column<bool>(nullable: false),
                    UserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectCards", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProjectCards_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectCards_UserID",
                table: "ProjectCards",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectCards");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
