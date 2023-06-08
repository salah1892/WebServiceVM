using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebServiceVM.Infrastructure.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Abonnee",
                columns: table => new
                {
                    IdAbonnee = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NumCarte = table.Column<int>(type: "int", nullable: false),
                    Nom = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Prenom = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abonnee", x => x.IdAbonnee);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Parking",
                columns: table => new
                {
                    IdParking = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NomParking = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TypeParking = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdressParking = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parking", x => x.IdParking);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TariffAbonnement",
                columns: table => new
                {
                    IdTariffAbonnement = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TypeAbonnement = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateDebut = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DateFin = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TariffAbonnement", x => x.IdTariffAbonnement);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TariffTicket",
                columns: table => new
                {
                    IdTariffTicket = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DateEntree = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateSortie = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TariffTicket", x => x.IdTariffTicket);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WebClient",
                columns: table => new
                {
                    IdWebClient = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FirstName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Mobile = table.Column<int>(type: "int", nullable: false),
                    Genre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebClient", x => x.IdWebClient);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Abonnement",
                columns: table => new
                {
                    IdAbonnement = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DateCreation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateActivation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateDesActivation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AbonneeIdAbonnee = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TariffAbonnementIdTariffAbonnement = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abonnement", x => x.IdAbonnement);
                    table.ForeignKey(
                        name: "FK_Abonnement_Abonnee_AbonneeIdAbonnee",
                        column: x => x.AbonneeIdAbonnee,
                        principalTable: "Abonnee",
                        principalColumn: "IdAbonnee",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Abonnement_TariffAbonnement_TariffAbonnementIdTariffAbonneme~",
                        column: x => x.TariffAbonnementIdTariffAbonnement,
                        principalTable: "TariffAbonnement",
                        principalColumn: "IdTariffAbonnement",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ParkingTariffAbonnement",
                columns: table => new
                {
                    ListParkingsIdParking = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ListTariffAbonnementIdTariffAbonnement = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingTariffAbonnement", x => new { x.ListParkingsIdParking, x.ListTariffAbonnementIdTariffAbonnement });
                    table.ForeignKey(
                        name: "FK_ParkingTariffAbonnement_Parking_ListParkingsIdParking",
                        column: x => x.ListParkingsIdParking,
                        principalTable: "Parking",
                        principalColumn: "IdParking",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParkingTariffAbonnement_TariffAbonnement_ListTariffAbonnemen~",
                        column: x => x.ListTariffAbonnementIdTariffAbonnement,
                        principalTable: "TariffAbonnement",
                        principalColumn: "IdTariffAbonnement",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    IdTicket = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Statut = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DateEntree = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateSortie = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PrixTicket = table.Column<float>(type: "float", nullable: false),
                    TariffTicketIdTariffTicket = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.IdTicket);
                    table.ForeignKey(
                        name: "FK_Ticket_TariffTicket_TariffTicketIdTariffTicket",
                        column: x => x.TariffTicketIdTariffTicket,
                        principalTable: "TariffTicket",
                        principalColumn: "IdTariffTicket",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Payement",
                columns: table => new
                {
                    IdPayement = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DatePayement = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AbonnementIdAbonnement = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TicketIdTicket = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payement", x => x.IdPayement);
                    table.ForeignKey(
                        name: "FK_Payement_Abonnement_AbonnementIdAbonnement",
                        column: x => x.AbonnementIdAbonnement,
                        principalTable: "Abonnement",
                        principalColumn: "IdAbonnement",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payement_Ticket_TicketIdTicket",
                        column: x => x.TicketIdTicket,
                        principalTable: "Ticket",
                        principalColumn: "IdTicket",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Abonnement_AbonneeIdAbonnee",
                table: "Abonnement",
                column: "AbonneeIdAbonnee");

            migrationBuilder.CreateIndex(
                name: "IX_Abonnement_TariffAbonnementIdTariffAbonnement",
                table: "Abonnement",
                column: "TariffAbonnementIdTariffAbonnement");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingTariffAbonnement_ListTariffAbonnementIdTariffAbonneme~",
                table: "ParkingTariffAbonnement",
                column: "ListTariffAbonnementIdTariffAbonnement");

            migrationBuilder.CreateIndex(
                name: "IX_Payement_AbonnementIdAbonnement",
                table: "Payement",
                column: "AbonnementIdAbonnement");

            migrationBuilder.CreateIndex(
                name: "IX_Payement_TicketIdTicket",
                table: "Payement",
                column: "TicketIdTicket");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_TariffTicketIdTariffTicket",
                table: "Ticket",
                column: "TariffTicketIdTariffTicket");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkingTariffAbonnement");

            migrationBuilder.DropTable(
                name: "Payement");

            migrationBuilder.DropTable(
                name: "WebClient");

            migrationBuilder.DropTable(
                name: "Parking");

            migrationBuilder.DropTable(
                name: "Abonnement");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Abonnee");

            migrationBuilder.DropTable(
                name: "TariffAbonnement");

            migrationBuilder.DropTable(
                name: "TariffTicket");
        }
    }
}
