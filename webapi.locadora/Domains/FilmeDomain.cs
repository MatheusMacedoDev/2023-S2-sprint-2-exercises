﻿using System.ComponentModel.DataAnnotations;

namespace webapi.locadora.Domains
{
    /// <summary>
    /// Classe que representa a entidade Filme
    /// </summary>
    public class FilmeDomain
    {
        public int IdFilme { get; set; }
        public int IdGenero { get; set; }

        [Required(ErrorMessage = "O título do filme é obrigatório!")]
        public string? Titulo { get; set; }

        public GeneroDomain? Genero { get; set; }
    }
}
