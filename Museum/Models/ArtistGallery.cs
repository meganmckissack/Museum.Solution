namespace Museum.Models
{
  public class ArtistGallery
    {       
        public int ArtistGalleryId { get; set; }
        public int GalleryId { get; set; }
        public int ArtistId { get; set; }
        public virtual Artist Artist { get; set; }
        public virtual Gallery Gallery { get; set; }
    }
}