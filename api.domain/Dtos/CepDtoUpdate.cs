using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.domain.Dtos
{
    public class CepDtoUpdate
    {
        [Required]
        public Guid Id { get; set; }  
        [Required]
        public string Cep { get; set; }
        [Required]
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        [Required]
        public Guid MunicipioId { get; set; }
    }
}