using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TreinaWeb.Musica.Dominio;
using TreinaWeb.Musica.Servicos.Entity.Context;
using TreinaWeb.Musica.Web.ViewModels.Album;

namespace TreinaWeb.Musica.Web.Controllers
{
    public class AlbunsController : Controller
    {
        private MusicasDbContext db = new MusicasDbContext();

        // GET: Albuns
        public ActionResult Index()
        {
            var album = Mapper.Map<List<Album>, List<AlbumExibicaoIndexViewModel>>(db.Albuns.ToList()); 
            return View(album);
        }

        // GET: Albuns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albuns.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            var albumMapper = Mapper.Map<Album, AlbumExibicaoIndexViewModel>(album);
            return View(albumMapper);
        }

        // GET: Albuns/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Albuns/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Ano,Obeservacoes,Email")] AlbumViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var album = Mapper.Map<AlbumViewModel, Album>(viewModel);
                db.Albuns.Add(album);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // GET: Albuns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albuns.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            var albumMapper = Mapper.Map<Album, AlbumViewModel>(album);
            return View(albumMapper);
        }

        // POST: Albuns/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Ano,Obeservacoes,Email")] AlbumViewModel viewAlbum)
        {
            if (ModelState.IsValid)
            {
                var album = Mapper.Map<AlbumViewModel, Album>(viewAlbum);
                db.Entry(album).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewAlbum);
        }

        // GET: Albuns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Albuns.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            var albumMapper = Mapper.Map<Album, AlbumExibicaoIndexViewModel>(album);
            return View(albumMapper);
        }

        // POST: Albuns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Album album = db.Albuns.Find(id);
            db.Albuns.Remove(album);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
