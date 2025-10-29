using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DndNoteApps.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Npcs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Race = table.Column<string>(type: "TEXT", nullable: true),
                    PlaceFound = table.Column<string>(type: "TEXT", nullable: true),
                    AttitudeTowardsPlayers = table.Column<string>(type: "TEXT", nullable: true),
                    PlayerNote = table.Column<string>(type: "TEXT", nullable: true),
                    DmNote = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CampaignId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Npcs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Npcs_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SesionNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CampaignId = table.Column<int>(type: "INTEGER", nullable: false),
                    SessionDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    NoteContent = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SesionNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SesionNotes_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Npcs_CampaignId",
                table: "Npcs",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_SesionNotes_CampaignId",
                table: "SesionNotes",
                column: "CampaignId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Npcs");

            migrationBuilder.DropTable(
                name: "SesionNotes");

            migrationBuilder.DropTable(
                name: "Campaigns");
        }
    }
}
