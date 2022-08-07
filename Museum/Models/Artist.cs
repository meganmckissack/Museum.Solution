using System.Collections.Generic;

namespace Museum.Models
{
    public class Artist
    {
        public Artist()
        {
            this.JoinArtistArtWork = new HashSet<ArtistArtwork>();

            this.JoinArtistGallery = new HashSet<ArtistGallery>();
        }

        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public virtual ICollection<ArtistArtwork> JoinArtistArtWork { get; set; }
        public virtual ICollection<ArtistGallery> JoinArtistGallery { get; set; }
    }
}