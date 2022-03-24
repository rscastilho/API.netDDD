using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.domain.Dtos;
using api.domain.Repository;
using api.domain.Services;
using AutoMapper;

namespace api.service.Services
{
    public class UfService : IUfService
    {

        private readonly IUfRepository _repository;
        private readonly IMapper _mapper;

        public UfService(IUfRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UfDto> Get(Guid Id)
        {
            var resultado =  await _repository.SelectAsync(Id);
            return _mapper.Map<UfDto>(resultado);

        }

        public async Task<IEnumerable<UfDto>> GetAll()
        {
            var resultado = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<UfDto>>(resultado);

        }
    }
}