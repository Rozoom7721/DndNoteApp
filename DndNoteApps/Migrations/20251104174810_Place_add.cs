using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DndNoteApps.Migrations
{
    /// <inheritdoc />
    public partial class Place_add : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlaceId",
                table: "Quests",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlaceId",
                table: "Npcs",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Places",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Fraction = table.Column<string>(type: "TEXT", nullable: true),
                    PlayerNote = table.Column<string>(type: "TEXT", nullable: true),
                    DmNote = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CampaignId = table.Column<int>(type: "INTEGER", nullable: false),
                    QuestId = table.Column<int>(type: "INTEGER", nullable: false),
                    NpcId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Places_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quests_PlaceId",
                table: "Quests",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Npcs_PlaceId",
                table: "Npcs",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Places_CampaignId",
                table: "Places",
                column: "CampaignId");

            migrationBuilder.AddForeignKey(
                name: "FK_Npcs_Places_PlaceId",
                table: "Npcs",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Quests_Places_PlaceId",
                table: "Quests",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Npcs_Places_PlaceId",
                table: "Npcs");

            migrationBuilder.DropForeignKey(
                name: "FK_Quests_Places_PlaceId",
                table: "Quests");

            migrationBuilder.DropTable(
                name: "Places");

            migrationBuilder.DropIndex(
                name: "IX_Quests_PlaceId",
                table: "Quests");

            migrationBuilder.DropIndex(
                name: "IX_Npcs_PlaceId",
                table: "Npcs");

            migrationBuilder.DropColumn(
                name: "PlaceId",
                table: "Quests");

            migrationBuilder.DropColumn(
                name: "PlaceId",
                table: "Npcs");
        }
    }
}
