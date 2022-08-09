using Microsoft.EntityFrameworkCore.Migrations;

namespace Museum.Solution.Migrations
{
    public partial class updateJoinArtworkGallery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GalleryId",
                table: "Artworks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Artworks_GalleryId",
                table: "Artworks",
                column: "GalleryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artworks_Galleries_GalleryId",
                table: "Artworks",
                column: "GalleryId",
                principalTable: "Galleries",
                principalColumn: "GalleryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artworks_Galleries_GalleryId",
                table: "Artworks");

            migrationBuilder.DropIndex(
                name: "IX_Artworks_GalleryId",
                table: "Artworks");

            migrationBuilder.DropColumn(
                name: "GalleryId",
                table: "Artworks");
        }
    }
}
