using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.domain.Models
{
    public class CepModel: BaseModel
    {
        private string _cep;
        public string Cep
        {
            get { return _cep; }
            set { _cep = value; }
        }

        private string _logradouro;
        public string Logradouro
        {
            get { return _logradouro; }
            set { _logradouro = value; }
        }

        private string _numero;
        public string Nume
        {
            get { return _numero; }
            set { _numero = string.IsNullOrEmpty(value) ? "s/n":value; }
        }
        private Guid _municipioId;
        public Guid MunicipioId
        {
            get { return _municipioId; }
            set { _municipioId = value; }
        }
        
                
        
    }
}