using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.domain.Entities
{
    public class CepEntity : BaseEntity
    {
        [Required]
        [MaxLength(10)]
        public string CEP { get; set; }

        [Required]
        [MaxLength(10)]
        public string Logradouro { get; set; }

        [MaxLength(10)]
        public string Numero { get; set; }
        [Required]
        public Guid MunicipioId { get; set; }
        public MunicipioEntity Municipio { get; set; }

    }
}