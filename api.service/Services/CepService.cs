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
    public class CepService : ICepService
    {

        private readonly ICepRepository _repostory;
        private readonly IMapper _mapper;

        public CepService(ICepRepository repostory, IMapper mapper)
        {
            _repostory = repostory;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repostory.DeleteAsync(id);
        }

        public async Task<CepDto> Get(Guid id)
        {
            var resultado = await _repostory.SelectAsync(id);
            return _mapper.Map<CepDto>(resultado);
        }

        public async Task<CepDto> Get(string cep)
        {
            var resultado = await _repostory.SelectAsync();
            return _mapper.Map<CepDto>(resultado);
        }

        public async Task<CepDtoCreateResult> Post(CepDtoCreate cep)
        {
            var model = _mapper.Map<CepModel>(cep);
            var entity = _mapper.Map<CepEntity>(model);
            var resultado = await _repostory.InsertAsync(entity);
            return _mapper.Map<CepDtoCreateResult>(resultado);
        }

        public async Task<CepDtoUpdateResult> Put(CepDtoUpdate cep)
        {
            var model = _mapper.Map<CepModel>(cep);
            var entity = _mapper.Map<CepEntity>(model);
            var resultado = await _repostory.InsertAsync(entity);
            return _mapper.Map<CepDtoUpdateResult>(resultado);
        }
    }
}