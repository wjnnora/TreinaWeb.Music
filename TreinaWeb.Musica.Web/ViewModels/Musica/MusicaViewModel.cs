﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TreinaWeb.Musica.Web.ViewModels.Musica
{
    public class MusicaViewModel
    {
        [Required(ErrorMessage = "O ID é obrigatório.")]
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome da música é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O nome da música pode ter no máximo 50 caracteres.")]
        [Display(Name = "Nome da música")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Selecione um Album válido")]
        [Display(Name = "Selecione o Album")]
        public int IdAlbum { get; set; }

    }
}