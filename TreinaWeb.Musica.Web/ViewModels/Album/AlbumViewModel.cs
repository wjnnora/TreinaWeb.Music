using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TreinaWeb.Musica.Web.ViewModels.Album
{
    public class AlbumViewModel
    {
        [Required(ErrorMessage = "O ID é obrigatório")]
        public int Id { get; set; }

        [Display(Name = "Nome do Album")]
        [Required(ErrorMessage = "O nome é obrigatório")]
        [MaxLength(100, ErrorMessage = "O nome do album pode ter no máximo 100 caracteres") ]
        public string Nome { get; set; }

        [Display(Name = "Ano do Album")]
        [Required(ErrorMessage = "O ano do album é obrigatório")]
        public int Ano { get; set; }

        [Display(Name = "Observações")]
        [MaxLength(1000, ErrorMessage = "A observação do album pode ter no máximo 1000 caracteres")]
        public string Obeservacoes { get; set; }

        [Display(Name = "E-mail de contato")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "O E-mail é obrigatório")]
        [MaxLength(50, ErrorMessage = "O E-mail pode ter no máximo 50 caracteres")]
        public string Email { get; set; }
    }
}