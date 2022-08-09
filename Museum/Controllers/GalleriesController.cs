using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Museum.Models;

namespace Museum.Controllers
{
  public class GalleriesController : Controller
  {
    private readonly MuseumContext _db;

    public GalleriesController(MuseumContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Gallery> model = _db.Galleries.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Gallery gallery)
    {
      _db.Galleries.Add(gallery);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Gallery thisGallery = _db.Galleries.FirstOrDefault(gallery => gallery.GalleryId == id);
      return View(thisGallery);
    }

    public ActionResult Edit(int id)
    {
      var thisGallery = _db.Galleries.FirstOrDefault(gallery => gallery.GalleryId == id);
      return View(thisGallery);
    }

    [HttpPost]
    public ActionResult Edit(Gallery gallery)
    {
      _db.Entry(gallery).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddArtist(int id)
    {
      var thisGallery = _db.Galleries.FirstOrDefault(gallery => gallery.GalleryId == id);
      ViewBag.ArtistId = new SelectList(_db.Artists, "ArtistId", "ArtistName");
      return View(thisGallery);
    }

    [HttpPost]
    public ActionResult AddArtist(Gallery Gallery, int ArtistId)
    {
      if (ArtistId != 0)
      {
        _db.ArtistGallery.Add(new ArtistGallery() { ArtistId = ArtistId, GalleryId = Gallery.GalleryId });
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }
  }
}