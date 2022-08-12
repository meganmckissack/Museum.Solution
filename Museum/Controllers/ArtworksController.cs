using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using Museum.Models;

namespace Museum.Controllers
{
  public class ArtworksController : Controller
  {
    private readonly MuseumContext _db;

    public ArtworksController(MuseumContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
    return View(_db.Artworks.ToList());
    }

    // [HttpPost]
    // public async Task<IActionResult> Index(IList<IFormFile> files)
    // {
    //   foreach (var file in files)
    //   {
    //     var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');// FileName returns "fileName.ext"
    //     if(fileName.EndsWith(".txt"))
    //     {
    //       var filePath = _db.Artworks.Museum + "\\wwwroot\\" + fileName; 
    //       await file.SaveAsAsync(filePath);
    //     }
    //   }
    //   return RedirectToAction("Index");
    // }
    
    // public ActionResult insert()
    // {
    //   return View();
    // }

    // [HttpPost]
    // public ActionResult insert(Artwork artwork)
    // {
    //   //create path to store in database
    //   artwork.artwork_image = "~/images/" + artwork.artwork_image_data.FileName;

    //   //store image in folder
    //   artwork.artwork_image_data.SaveAs(Server.MapPath("images") + "/" + artwork.artwork_image_data.FileName);

    //   _db.GetTable<Artworrks>().InsertOnSubmit(artwork);
    //   _db.SubmitChanges();

    //   return View();

    // }
  
    public ActionResult Create()
    {
      ViewBag.ArtistId = new SelectList(_db.Artists, "ArtistId", "ArtistName");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Artwork artwork, int ArtistId)
    {
      _db.Artworks.Add(artwork);
      _db.SaveChanges();
      if (ArtistId !=0)
      {
        _db.ArtistArtwork.Add(new ArtistArtwork() {
          ArtistId = ArtistId, ArtworkId = artwork.ArtworkId
        });
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisArtwork = _db.Artworks
        .Include(artwork => artwork.JoinArtistArtwork)
        .ThenInclude(join => join.Artist)
        .FirstOrDefault(artwork => artwork.
        ArtworkId == id);
      return View(thisArtwork);
    }

    public ActionResult Edit(int id)
    {
      var thisArtwork = _db.Artworks.FirstOrDefault(artwork => artwork.ArtworkId == id);
      ViewBag.ArtistId = new SelectList(_db.Artists, "ArtistId", "ArtistName");
      return View(thisArtwork);
    }

    [HttpPost]
    public ActionResult Edit(Artwork artwork, int ArtistId)
    {
      if (ArtistId != 0)
        {
          _db.ArtistArtwork.Add(new ArtistArtwork() { ArtistId = ArtistId, ArtworkId = artwork.ArtworkId });
        }
        _db.Entry(artwork).State = EntityState.Modified;
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult AddArtist(int id)
    { 
      var thisArtwork = _db.Artworks.FirstOrDefault(artwork => artwork.ArtworkId == id);
      ViewBag.ArtistId = new SelectList(_db.Artists, "ArtistId", "Name");
      return View(thisArtwork);
    }

    [HttpPost]
    public ActionResult AddArtist(Artwork artwork, int ArtistId)
    {
      if (ArtistId != 0)
      {
        _db.ArtistArtwork.Add(new ArtistArtwork() { ArtistId = ArtistId, ArtworkId = artwork.ArtworkId });
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }


    public ActionResult Delete(int id)
    {
      var thisArtwork = _db.Artworks.FirstOrDefault(artwork => artwork.ArtworkId == id);
      return View(thisArtwork);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisArtwork = _db.Artworks.FirstOrDefault(artwork => artwork.ArtworkId == id);
      _db.Artworks.Remove(thisArtwork);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteArtist(int joinId)
    {
      var joinEntry = _db.ArtistArtwork.FirstOrDefault(entry => entry.ArtistArtworkId == joinId);
      _db.ArtistArtwork.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}

