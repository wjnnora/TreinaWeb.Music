using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TreinaWeb.Musica.Web.ViewModels.Musica
{
    public class MusicaExibicaoViewModel
    {
        public long Id { get; set; }
        [Display(Name = "Nome da Música")]
        public string Nome { get; set; }
        [Display(Name = "Nome do Album")]
        public string NomeAlbum { get; set; }
    }
}