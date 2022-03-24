using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.domain.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
         [Required(ErrorMessage ="Campo {0 }obrigatório")]
        [StringLength(60, ErrorMessage ="Nome de ter no maximo {1} caracteres")]

        public string Name { get; set; }

        [Required(ErrorMessage ="Campo {0 }obrigatório")]
        [StringLength(100, ErrorMessage ="Nome de ter no maximo {1} caracteres")]
        [EmailAddress(ErrorMessage ="Formato invalido")]
        public string Email { get; set; }   
    }
}