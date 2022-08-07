using System.Collections.Generic;

namespace Museum.Models
{
    public class Gallery
    {
        public Gallery()
        {
            this.JoinArtworkGallery = new HashSet<ArtworkGallery>();

            this.JoinArtistGallery = new HashSet<ArtistGallery>();
        }

        public int GalleryId { get; set; }
        public string GalleryName { get; set; }
        public virtual ICollection<ArtworkGallery> JoinArtworkGallery { get; set; }
        public virtual ICollection<ArtistGallery> JoinArtistGallery { get; set; }
    }
}