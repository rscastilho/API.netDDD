using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.domain.Dtos;
using api.domain.Entities;
using api.domain.Interfaces;
using api.domain.Models;
using api.domain.Services;
using AutoMapper;

namespace api.service.Services
{
    public class UserService : IUserService
    {

        private readonly IRepository<UserEntity> _repository;
        private readonly IMapper _mapper;

        public UserService(IRepository<UserEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<UserDto> Get(Guid Id)
        {
            var resultado = await _repository.SelectAsync(Id);
            return _mapper.Map<UserDto>(resultado);

        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var resultado = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<UserDto>>(resultado);
        }

        public async Task<UserDtoCreateResult> Post(UserDtoCreate user)
        {
            var resultado = _mapper.Map<UserModel> (user);
            var entity = _mapper.Map<UserEntity>(resultado);
            var final = await _repository.InsertAsync(entity);

            return _mapper.Map<UserDtoCreateResult>(final);
        }

        public async Task<UserDtoUpdateResult> Put(UserDtoUpdate user)
        {
             var resultado = _mapper.Map<UserModel> (user);
            var entity = _mapper.Map<UserEntity>(resultado);
            var final = await _repository.UpdateAsync(entity);

            return _mapper.Map<UserDtoUpdateResult>(final);
        }
    }
}