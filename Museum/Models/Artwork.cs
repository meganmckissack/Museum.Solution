using System.Collections.Generic;
using System;
using System.Web;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Linq;


namespace Museum.Models
{
  public class Artwork
  {

    public Artwork()
      {
          this.JoinArtistArtwork = new HashSet<ArtistArtwork>();
          // this.JoinArtworkGallery = new HashSet<ArtworkGallery>();
      }
      
    // auto implemented properties
    public string Title { get; set; }
    public int ArtworkId { get; set; }
    public string ArtworkImg { get; set; }
    public int GalleryId { get; set; }
    public virtual Gallery Gallery { get; set; }
    public virtual ICollection<ArtistArtwork> JoinArtistArtwork { get; }
    // public virtual ICollection<ArtworkGallery> JoinArtworkGallery { get; }

    public HttpPostedFileBase artwork_image_data { get; set; }
  }
}