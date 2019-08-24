using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TreinaWeb.Musica.Web.ViewModels.Album
{
    public class AlbumExibicaoIndexViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Nome do Album")]
        public string Nome { get; set; }
        [Display(Name = "Ano do Album")]
        public int Ano { get; set; }
        [Display(Name = "Observações")]
        public string Obeservacoes { get; set; }
        [Display(Name = "E-mail de contato")]
        [DataType(DataType.EmailAddress, ErrorMessage ="E-mail Invalido")]
        public string Email { get; set; }
    }
}