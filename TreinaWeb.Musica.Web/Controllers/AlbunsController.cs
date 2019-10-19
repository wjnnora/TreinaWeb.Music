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
using TreinaWeb.Musica.Repositorios.Entity;
using TreinaWeb.Musica.Servicos.Entity.Context;
using TreinaWeb.Musica.Web.Filtros;
using TreinaWeb.Musica.Web.ViewModels.Album;
using TreinaWeb.Repositorios.Comum;

namespace TreinaWeb.Musica.Web.Controllers
{
    [Authorize]
    public class AlbunsController : BaseController
    {
        private readonly IRepositorioGenerico<Album, int> repositorioAlbuns = new AlbumRepositorio(new IdentityMusicasDbContext());

        // GET: Albuns
        [LogActionFilter]
        public ActionResult Index()
        {
            var album = Mapper.Map<List<Album>, List<AlbumExibicaoIndexViewModel>>(repositorioAlbuns.Selecionar()).OrderBy(x => x.Nome); 
            return View(album);
        }

        public ContentResult FiltrarPorNome(string pesquisa)
        {
            List<Album> albuns = repositorioAlbuns.Selecionar().Where(p => p.Nome.Contains(pesquisa)).OrderBy(x => x.Nome).ToList();
            List<AlbumExibicaoIndexViewModel> viewModel = Mapper.Map<List<Album>, List<AlbumExibicaoIndexViewModel>>(albuns);

            string conteudo = MontaResultadoPesquisaAlbum(viewModel);

            return Content(conteudo);
        }

        // GET: Albuns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = repositorioAlbuns.SelecionarPorId(id.Value);   
            if (album == null)
            {
                return HttpNotFound();
            }
            var albumMapper = Mapper.Map<Album, AlbumExibicaoIndexViewModel>(album);
            return View(albumMapper);
        }

        // GET: Albuns/Create
        [Authorize(Roles = "ADMINISTRADOR")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Albuns/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ADMINISTRADOR")]
        public ActionResult Create([Bind(Include = "Id,Nome,Ano,Obeservacoes,Email")] AlbumViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var album = Mapper.Map<AlbumViewModel, Album>(viewModel);
                repositorioAlbuns.Inserir(album);
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
            Album album = repositorioAlbuns.SelecionarPorId(id.Value);
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
                repositorioAlbuns.Alterar(album);
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
            Album album = repositorioAlbuns.SelecionarPorId(id.Value);
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
            repositorioAlbuns.ExcluirPorId(id);
            return RedirectToAction("Index");
        }
    }
}
