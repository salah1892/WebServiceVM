using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebServiceVM.Infrastructure.Migrations
{
    public partial class AddAttributParametre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DescriptionPayement",
                table: "Parametre",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescriptionPayement",
                table: "Parametre");
        }
    }
}
