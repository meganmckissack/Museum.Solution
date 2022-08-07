using System.Collections.Generic;
using System;

namespace Museum.Models
{
  public class Artwork
  {

    public Artwork()
      {
          this.JoinArtistArtwork = new HashSet<ArtistArtwork>();
          this.JoinArtworkGallery = new HashSet<ArtworkGallery>();
      }
      
    // auto implemented properties
    public string Title { get; set; }
    public int ArtworkId { get; set; }
    public virtual ICollection<ArtistArtwork> JoinArtistArtwork { get; }
    public virtual ICollection<ArtworkGallery> JoinArtworkGallery { get; }
  }
}