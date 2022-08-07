using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
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

