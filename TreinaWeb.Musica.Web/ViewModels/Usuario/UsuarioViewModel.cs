using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TreinaWeb.Musica.Web.Annotations;

namespace TreinaWeb.Musica.Web.ViewModels.Usuario
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage = "O E-mail é obrigatório")]
        [MaxLength(30, ErrorMessage = "A quantidade máxima é de 30 caracteres")]
        //[Email(ErrorMessage = "O E-mail precisa ser um HOTMAIL")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

    }
}