using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.domain.Dtos;

namespace api.domain.Services
{
    public interface IMunicipioService
    {
        Task<MunicipioDto> Get (Guid id);
        Task<MunicipioCompletoDto> GetCompleteById(Guid id);
        Task<MunicipioCompletoDto> GetCompleteByIBGE(int codIBGE);
        Task<IEnumerable<MunicipioDto>> GetAll();
        Task<MunicipioCreateResultDto> Post (MunicipioDtoCreate municipio);
        Task<MunicipioDtoUpdateResult> Put  (MunicipioDtoUpdate municipio);
        Task<bool> Delete(Guid id);
    }
}