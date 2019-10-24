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
using TreinaWeb.Musica.Web.ViewModels.Album;
using TreinaWeb.Musica.Web.ViewModels.Musica;
using TreinaWeb.Repositorios.Comum;

namespace TreinaWeb.Musica.Web.Controllers
{
    [Authorize]
    public class MusicasController : BaseController
    {
        private readonly IRepositorioGenerico<Dominio.Musica, long> repositorioMusicas = new MusicaRepositorio(new IdentityMusicasDbContext());
        private readonly IRepositorioGenerico<Album, int> repositorioAlbuns = new AlbumRepositorio(new IdentityMusicasDbContext());


        // GET: Musicas
        public ActionResult Index()
        {
            var musicas = Mapper.Map<List<Dominio.Musica>, List<MusicaExibicaoViewModel>>(repositorioMusicas.Selecionar());
            return View(musicas);
        }

        public ContentResult FiltrarPorNome(string pesquisa)
        {
            List<Dominio.Musica> musicas = repositorioMusicas.Selecionar().Where(p => p.Nome.Contains(pesquisa)).ToList();
            List<MusicaExibicaoViewModel> viewMusica = Mapper.Map<List<Dominio.Musica>, List<MusicaExibicaoViewModel>>(musicas);

            string conteudo = MontaResultadoPesquisaMusicas(viewMusica);

            return Content(conteudo);
        }

        // GET: Musicas/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dominio.Musica musica = repositorioMusicas.SelecionarPorId(id.Value);
            if (musica == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Dominio.Musica, MusicaExibicaoViewModel>(musica));
        }

        // GET: Musicas/Create
        [Authorize(Roles = "ADMINISTRADOR")]
        public ActionResult Create()
        {
            List<AlbumExibicaoIndexViewModel> albuns = Mapper.Map<List<Album>, List<AlbumExibicaoIndexViewModel>>(repositorioAlbuns.Selecionar());
            ViewBag.DropDownAlbuns = new SelectList(albuns, "Id", "Nome");
            return View();
        }

        // POST: Musicas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ADMINISTRADOR")]
        public ActionResult Create([Bind(Include = "Id,Nome,IdAlbum")] MusicaViewModel viewMusicas)
        {
            if (ModelState.IsValid)
            {
                var musica = Mapper.Map<MusicaViewModel, Dominio.Musica>(viewMusicas);
                repositorioMusicas.Inserir(musica);
                return RedirectToAction("Index");
            }

            return View(viewMusicas);
        }

        // GET: Musicas/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dominio.Musica musica = repositorioMusicas.SelecionarPorId(id.Value);
            if (musica == null)
            {
                return HttpNotFound();
            }
            List<AlbumExibicaoIndexViewModel> albuns = Mapper.Map<List<Album>, List<AlbumExibicaoIndexViewModel>>(repositorioAlbuns.Selecionar());
            ViewBag.DropDownAlbuns = new SelectList(albuns, "Id", "Nome");
            return View(Mapper.Map<Dominio.Musica, MusicaViewModel>(musica));
        }

        // POST: Musicas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,IdAlbum")] MusicaViewModel viewMusica)
        {
            if (ModelState.IsValid)
            {
                var musica = Mapper.Map<MusicaViewModel, Dominio.Musica>(viewMusica);
                repositorioMusicas.Alterar(musica);
                return RedirectToAction("Index");
            }
            return View(viewMusica);
        }

        // GET: Musicas/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var musica = repositorioMusicas.SelecionarPorId(id.Value);
            if (musica == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Dominio.Musica, MusicaExibicaoViewModel>(musica));
        }

        // POST: Musicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            var musica = repositorioMusicas.SelecionarPorId(id);
            repositorioMusicas.Excluir(musica);
            return RedirectToAction("Index");
        }
    }
}
