using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.domain.Dtos
{
    public class LoginDto
    {
        [Required (ErrorMessage ="Campo {0} de preenchimento obrigatório")]
        [EmailAddress(ErrorMessage ="Formato inválido")]
        [StringLength(100, ErrorMessage ="Tamanho maximo de caracteres {1}")]
        public string Email { get; set; }
    }
}