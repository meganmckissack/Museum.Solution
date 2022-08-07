namespace Museum.Models
{
  public class ArtistArtwork
    {       
        public int ArtistArtworkId { get; set; }
        public int ArtistId { get; set; }
        public int ArtworkId { get; set; }
        public virtual Artist Artist { get; set; }
        public virtual Artwork Artwork { get; set; }
    }
}