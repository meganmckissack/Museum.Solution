using Microsoft.EntityFrameworkCore;

namespace Museum.Models
{
  public class MuseumContext : DbContext 
  {
    public DbSet<Artist> Artists { get; set; }
    public DbSet<ArtistArtwork> ArtistArtwork { get; set; }
    public DbSet<ArtistGallery> ArtistGallery { get; set; }
    public DbSet<Artwork> Artworks { get; set; }
    public DbSet<Gallery> Galleries { get; set; }

    public MuseumContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}