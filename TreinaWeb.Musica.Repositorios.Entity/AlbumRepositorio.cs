using System;
using System.Collections.Generic;
using System.Text;
using TreinaWeb.Musica.Dominio;
using TreinaWeb.Musica.Servicos.Entity.Context;
using TreinaWeb.Repositorios.Comum.Entity;

namespace TreinaWeb.Musica.Repositorios.Entity
{
    public class AlbumRepositorio : RepositorioGenericoEntity<Album, int>
    {
        public AlbumRepositorio(MusicasDbContext context) : base(context) { }
    }

}