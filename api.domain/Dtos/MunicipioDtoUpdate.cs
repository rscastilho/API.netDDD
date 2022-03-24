using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.domain.Dtos
{
    public class MunicipioDtoUpdate
    {
        [Required]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="Campo {0} obrigatório")]
       [StringLength(60, ErrorMessage ="Use menos caracteres. maximo {1} caracteres")]
       public string Nome { get; set; }
       [Range(0,int.MaxValue, ErrorMessage ="Codigo invalido")]
        public int CodIBGE { get; set; }
        
        [Required(ErrorMessage ="Campo {0} obrigatório")]
        public Guid UfId  { get; set; }
    }
}