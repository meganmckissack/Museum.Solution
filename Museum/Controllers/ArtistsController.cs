using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Museum.Models;

namespace Museum.Controllers
{
  public class ArtistsController : Controller
  {
    private readonly MuseumContext _db;

    public ArtistsController(MuseumContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Artist> model = _db.Artists.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Artist artist)
    {
      _db.Artists.Add(artist);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Artist thisArtist = _db.Artists.FirstOrDefault(artist => artist.ArtistId == id);
      return View(thisArtist);
    }

    public ActionResult Edit(int id)
    {
      var thisArtist = _db.Artists.FirstOrDefault(artist => artist.ArtistId == id);
      return View(thisArtist);
    }

    [HttpPost]
    public ActionResult Edit(Artist artist)
    {
      _db.Entry(artist).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisArtist = _db.Artists.FirstOrDefault(artist => artist.ArtistId == id);
      return View(thisArtist);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisArtist = _db.Artists.FirstOrDefault(artist => artist.ArtistId == id);
      _db.Artists.Remove(thisArtist);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
