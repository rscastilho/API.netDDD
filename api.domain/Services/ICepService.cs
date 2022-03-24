using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.domain.Dtos;

namespace api.domain.Services
{
    public interface ICepService
    {
        Task<CepDto> Get (Guid id);
        Task<CepDto> Get(string cep);
        Task<CepDtoCreateResult> Post(CepDtoCreate cep);
        Task<CepDtoUpdateResult> Put(CepDtoUpdate cep);
        Task<bool> Delete (Guid id);
        
    }
}