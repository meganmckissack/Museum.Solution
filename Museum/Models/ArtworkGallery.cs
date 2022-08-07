namespace Museum.Models
{
  public class ArtworkGallery
    {       
        public int ArtworkGalleryId { get; set; }
        public int GalleryId { get; set; }
        public int ArtworkId { get; set; }
        public virtual Gallery Gallery { get; set; }
        public virtual Artwork Artwork { get; set; }
    }
}