using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinimalApiContainer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PortLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContainerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContainerType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContainerDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ports", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ports");
        }
    }
}
