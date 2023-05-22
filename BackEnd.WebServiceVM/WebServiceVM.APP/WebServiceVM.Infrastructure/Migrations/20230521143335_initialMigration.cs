using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebServiceVM.Infrastructure.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abonnee",
                columns: table => new
                {
                    IdAbonnee = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumCarte = table.Column<int>(type: "int", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abonnee", x => x.IdAbonnee);
                });

            migrationBuilder.CreateTable(
                name: "Parking",
                columns: table => new
                {
                    IdParking = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomParking = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeParking = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdressParking = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parking", x => x.IdParking);
                });

            migrationBuilder.CreateTable(
                name: "TariffAbonnement",
                columns: table => new
                {
                    IdTariffAbonnement = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeAbonnement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateDebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TariffAbonnement", x => x.IdTariffAbonnement);
                });

            migrationBuilder.CreateTable(
                name: "TariffTicket",
                columns: table => new
                {
                    IdTariffTicket = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateEntree = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateSortie = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TariffTicket", x => x.IdTariffTicket);
                });

            migrationBuilder.CreateTable(
                name: "WebClient",
                columns: table => new
                {
                    IdWebClient = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebClient", x => x.IdWebClient);
                });

            migrationBuilder.CreateTable(
                name: "Abonnement",
                columns: table => new
                {
                    IdAbonnement = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateActivation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateDesActivation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AbonneeIdAbonnee = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TariffAbonnementIdTariffAbonnement = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                        name: "FK_Abonnement_TariffAbonnement_TariffAbonnementIdTariffAbonnement",
                        column: x => x.TariffAbonnementIdTariffAbonnement,
                        principalTable: "TariffAbonnement",
                        principalColumn: "IdTariffAbonnement",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParkingTariffAbonnement",
                columns: table => new
                {
                    ListParkingsIdParking = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ListTariffAbonnementIdTariffAbonnement = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                        name: "FK_ParkingTariffAbonnement_TariffAbonnement_ListTariffAbonnementIdTariffAbonnement",
                        column: x => x.ListTariffAbonnementIdTariffAbonnement,
                        principalTable: "TariffAbonnement",
                        principalColumn: "IdTariffAbonnement",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    IdTicket = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Statut = table.Column<bool>(type: "bit", nullable: false),
                    DateEntree = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateSortie = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrixTicket = table.Column<float>(type: "real", nullable: false),
                    TariffTicketIdTariffTicket = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "Payement",
                columns: table => new
                {
                    IdPayement = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DatePayement = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AbonnementIdAbonnement = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TicketIdTicket = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                });

            migrationBuilder.CreateIndex(
                name: "IX_Abonnement_AbonneeIdAbonnee",
                table: "Abonnement",
                column: "AbonneeIdAbonnee");

            migrationBuilder.CreateIndex(
                name: "IX_Abonnement_TariffAbonnementIdTariffAbonnement",
                table: "Abonnement",
                column: "TariffAbonnementIdTariffAbonnement");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingTariffAbonnement_ListTariffAbonnementIdTariffAbonnement",
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
