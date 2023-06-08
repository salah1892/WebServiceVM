using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebServiceVM.Infrastructure.Migrations
{
    public partial class AddClassParametre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parametre",
                columns: table => new
                {
                    IdParametre = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TypePayement = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametre", x => x.IdParametre);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parametre");
        }
    }
}
