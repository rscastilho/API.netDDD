using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.domain.Dtos;
using api.domain.Entities;
using api.domain.Models;
using api.domain.Repository;
using api.domain.Services;
using AutoMapper;

namespace api.service.Services
{
    public class MunicipioService : IMunicipioService
    {
        private readonly IMunicipioRepository _repository;
        private readonly IMapper _mapper;

        public MunicipioService(IMunicipioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }



        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<MunicipioDto> Get(Guid id)
        {
            var resultado = await _repository.SelectAsync(id);
            return _mapper.Map<MunicipioDto>(resultado);
        }

        public async Task<IEnumerable<MunicipioDto>> GetAll()
        {
            var resultado = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<MunicipioDto>>(resultado);
        }

        public async Task<MunicipioCompletoDto> GetCompleteByIBGE(int codIBGE)
        {
            var resultado = await _repository.GetCompleteByIBGe(codIBGE);
            return _mapper.Map<MunicipioCompletoDto>(resultado);
        }

        public async Task<MunicipioCompletoDto> GetCompleteById(Guid id)
        {
            var resultado = await _repository.SelectAsync(id);
            return _mapper.Map<MunicipioCompletoDto>(resultado);
        }

        public async Task<MunicipioCreateResultDto> Post(MunicipioDtoCreate municipio)
        {
            var model = _mapper.Map<MunicipioModel>(municipio);
            var entity = _mapper.Map<MunicipioEntity>(model);
            var resultado = await _repository.InsertAsync(entity);
            return _mapper.Map<MunicipioCreateResultDto>(resultado);
        }

        public async Task<MunicipioDtoUpdateResult> Put(MunicipioDtoUpdate municipio)
        {
            var model = _mapper.Map<MunicipioModel>(municipio);
            var entity = _mapper.Map<MunicipioEntity>(model);
            var resultado = await _repository.UpdateAsync(entity);
            return _mapper.Map<MunicipioDtoUpdateResult>(resultado);
        }
    }
}