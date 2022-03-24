using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.domain.Dtos
{
    public class MunicipioCompletoDto
    {
         public Guid Id  { get; set; }

        public string Nome { get; set; }

        public int CodIBGE { get; set; }
        public Guid UfId  { get; set; }
        public UfDto Uf { get; set; }
        
        
    }
}