using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TreinaWeb.Musica.Web.ViewModels.Album;

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
                sb.Append("<button class='btn btn-success' value='Editar'>");
                sb.Append("<span class='glyphicon glyphicon-edit'></span>");
                sb.Append("<a href='/Albuns/Edit/" + album.Id + "'>Editar</a>");
                sb.Append("</button> ");
                sb.Append("<button class='btn btn-warning' value='Detalhes'>");
                sb.Append("<span class='glyphicon glyphicon-eye-open'></span>");
                sb.Append("<a href='/Albuns/Details/" + album.Id + "'>Detalhes</a>");
                sb.Append("</button> ");
                sb.Append("<button class='btn btn-danger' value='Deletar'>");
                sb.Append("<span class='glyphicon glyphicon-trash'></span>");
                sb.Append("<a href='/Albuns/Delete/" + album.Id + "'>Deletar</a>");
                sb.Append("</button>");
                sb.Append("</div>");
                sb.Append("</td>");
                sb.Append("</tr>");
            }
            return sb.ToString();
        }
        
    }
}