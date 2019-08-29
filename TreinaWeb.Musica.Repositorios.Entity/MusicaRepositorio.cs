using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreinaWeb.Musica.Dominio;
using TreinaWeb.Musica.Servicos.Entity.Context;
using TreinaWeb.Repositorios.Comum.Entity;
using System.Data.Entity;

namespace TreinaWeb.Musica.Repositorios.Entity
{
    public class MusicaRepositorio : RepositorioGenericoEntity<Dominio.Musica, long>
    {
        public MusicaRepositorio(MusicasDbContext contexto) : base(contexto) { }

        public override List<Dominio.Musica> Selecionar()
        {
            return _contexto.Set<Dominio.Musica>().Include(p => p.Album).ToList();
        }

        public override Dominio.Musica SelecionarPorId(long id)
        {
            return _contexto.Set<Dominio.Musica>().Include(p => p.Album).SingleOrDefault(p => p.Id == id);
        }

    }
}
