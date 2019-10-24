using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TreinaWeb.Musica.Web.ViewModels.Album;
using TreinaWeb.Musica.Web.ViewModels.Musica;

namespace TreinaWeb.Musica.Web.Controllers
{
    public class BaseController : Controller
    {
        public string MontaResultadoPesquisaAlbum(List<AlbumExibicaoIndexViewModel> albuns)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var album in albuns)
            {
                sb.Append("<tr>");
                sb.Append("<td>");
                sb.Append(album.Nome);
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append(album.Ano);
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append(album.Obeservacoes);
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append(album.Email);
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append("<div class='form-group'>");
                
                sb.Append("<a href='/Albuns/Edit/" + album.Id + "' class='btn btn-success'>");
                sb.Append("<span>Editar</span>");
                sb.Append("</a> ");

                sb.Append("<a href='/Albuns/Details/" + album.Id + "' class='btn btn-warning'>");
                sb.Append("<span>Detalhes</span>");
                sb.Append("</a> ");

                sb.Append("<a href='/Albuns/Delete/" + album.Id + "' class='btn btn-danger'>");
                sb.Append("<span>Deletar</span>");
                sb.Append("</a>");
                
                sb.Append("</div>");
                sb.Append("</td>");
                sb.Append("</tr>");
            }
            return sb.ToString();
        }

        public string MontaResultadoPesquisaMusicas(List<MusicaExibicaoViewModel> musicas)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var musica in musicas)
            {
                sb.Append("<tr>");
                sb.Append("<td>");
                sb.Append(musica.Nome);
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append(musica.NomeAlbum);
                sb.Append("</td>");
                sb.Append("<td>");
                sb.Append("<div class='form-group'>");

                sb.Append("<a href='/Musicas/Edit/" + musica.Id + "' class='btn btn-success'>");
                sb.Append("<span>Editar</span>");
                sb.Append("</a> ");

                sb.Append("<a href='/Musicas/Details/" + musica.Id + "' class='btn btn-warning'>");
                sb.Append("<span>Detalhes</span>");
                sb.Append("</a> ");

                sb.Append("<a href='/Musicas/Delete/" + musica.Id + "' class='btn btn-danger'>");
                sb.Append("<span>Deletar</span>");
                sb.Append("</a>");

                sb.Append("</div>");
                sb.Append("</td>");
                sb.Append("</tr>");
            }
            return sb.ToString();
        }

    }
}