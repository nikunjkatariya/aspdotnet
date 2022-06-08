using Microsoft.EntityFrameworkCore.Migrations;

namespace EDIFileStoreWebApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Watchlist",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ISA = table.Column<string>(nullable: true),
                    GS = table.Column<string>(nullable: true),
                    ST = table.Column<string>(nullable: true),
                    B4 = table.Column<string>(nullable: true),
                    SE = table.Column<string>(nullable: true),
                    GE = table.Column<string>(nullable: true),
                    IEA = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Watchlist", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Watchlist");
        }
    }
}
