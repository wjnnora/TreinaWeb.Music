using System;
using System.Collections.Generic;
using System.Text;
using TreinaWeb.Musica.Dominio;
using TreinaWeb.Musica.Servicos.Entity.Context;
using TreinaWeb.Repositorios.Comum.Entity;
using System.Data.Entity;
using System.Linq;

namespace TreinaWeb.Musica.Repositorios.Entity
{
    public class AlbumRepositorio : RepositorioGenericoEntity<Album, int>
    {
        public AlbumRepositorio(MusicasDbContext context) : base(context) { }

        public override List<Album> Selecionar()
        {
            return _contexto.Set<Album>().Include(p => p.Musicas).ToList();
        }

        public override Album SelecionarPorId(int id)
        {
            return _contexto.Set<Album>().Include(p => p.Musicas).SingleOrDefault(album => album.Id == id);
        }
    }

}