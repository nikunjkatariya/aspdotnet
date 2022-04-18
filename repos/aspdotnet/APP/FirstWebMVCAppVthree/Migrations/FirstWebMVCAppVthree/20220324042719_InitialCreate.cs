using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstWebMVCAppVthree.Migrations.FirstWebMVCAppVthree
{
    public partial class InitialCreate : Migration
    {
        //MEthod which create movie table configure id as primary key
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    Genre = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });
        }
        //Reverse the schema changes made by the upmigration
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
