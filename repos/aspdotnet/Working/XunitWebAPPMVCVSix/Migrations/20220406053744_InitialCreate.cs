using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XunitWebAPPMVCVSix.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "AccountNumber", "Age", "Name" },
                values: new object[,]
                {
                    { new Guid("5be02faa-34be-4055-acd8-ed52c3141bb0"), "7896622558855", 21, "Josh" },
                    { new Guid("cd372b99-806c-446b-b325-8813c292d4cc"), "4456622558855", 35, "Mosh" },
                    { new Guid("eb626d97-2d4d-4c9b-a531-6a742cd81b40"), "4456622554455", 31, "John" },
                    { new Guid("f761edb5-fe12-4d12-8dde-e6f1315d2508"), "4457788558855", 26, "James" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
