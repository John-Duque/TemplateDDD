﻿using System.ComponentModel.DataAnnotations;

namespace TemplateDDD.Domain.Views
{
    public class UserView
	{
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Nome é um campo obrigatório")]
        [StringLength(60, ErrorMessage = "Nome deve ter no máximo {1} caracteres")]
		public string? Name { get; set; }

        [Required(ErrorMessage = "Email é um campo obrigatório")]
        [EmailAddress(ErrorMessage = "Email em formato inválido")]
        [StringLength(100, ErrorMessage = "Nome deve ter no máximo {1} caracteres")]
        public string? Email { get; set; }
    }
}

