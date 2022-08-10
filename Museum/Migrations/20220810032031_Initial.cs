using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Museum.Solution.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ArtistName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.ArtistId);
                });

            migrationBuilder.CreateTable(
                name: "Galleries",
                columns: table => new
                {
                    GalleryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    GalleryName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Galleries", x => x.GalleryId);
                });

            migrationBuilder.CreateTable(
                name: "ArtistGallery",
                columns: table => new
                {
                    ArtistGalleryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    GalleryId = table.Column<int>(type: "int", nullable: false),
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistGallery", x => x.ArtistGalleryId);
                    table.ForeignKey(
                        name: "FK_ArtistGallery_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistGallery_Galleries_GalleryId",
                        column: x => x.GalleryId,
                        principalTable: "Galleries",
                        principalColumn: "GalleryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Artworks",
                columns: table => new
                {
                    ArtworkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    GalleryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artworks", x => x.ArtworkId);
                    table.ForeignKey(
                        name: "FK_Artworks_Galleries_GalleryId",
                        column: x => x.GalleryId,
                        principalTable: "Galleries",
                        principalColumn: "GalleryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtistArtwork",
                columns: table => new
                {
                    ArtistArtworkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    ArtworkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistArtwork", x => x.ArtistArtworkId);
                    table.ForeignKey(
                        name: "FK_ArtistArtwork_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistArtwork_Artworks_ArtworkId",
                        column: x => x.ArtworkId,
                        principalTable: "Artworks",
                        principalColumn: "ArtworkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistArtwork_ArtistId",
                table: "ArtistArtwork",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistArtwork_ArtworkId",
                table: "ArtistArtwork",
                column: "ArtworkId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistGallery_ArtistId",
                table: "ArtistGallery",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistGallery_GalleryId",
                table: "ArtistGallery",
                column: "GalleryId");

            migrationBuilder.CreateIndex(
                name: "IX_Artworks_GalleryId",
                table: "Artworks",
                column: "GalleryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistArtwork");

            migrationBuilder.DropTable(
                name: "ArtistGallery");

            migrationBuilder.DropTable(
                name: "Artworks");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Galleries");
        }
    }
}
