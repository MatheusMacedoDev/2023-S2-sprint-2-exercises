﻿using System.ComponentModel.DataAnnotations;

namespace webapi.locadora.Domains
{
    /// <summary>
    /// Classe que representa a entidade Genero
    /// </summary>
    public class GeneroDomain
    {
        public int IdGenero { get; set; }

        [Required(ErrorMessage = "O nome do gênero é obrigatório!")]
        public string? Nome { get; set; }
    }
}
