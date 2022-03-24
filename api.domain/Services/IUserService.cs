using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.domain.Dtos;
using api.domain.Entities;

namespace api.domain.Services
{
    public interface IUserService
    {
        Task<UserDto> Get (Guid Id);
        Task<IEnumerable<UserDto>> GetAll();
        Task<UserDtoCreateResult> Post (UserDtoCreate user);
        Task<UserDtoUpdateResult> Put (UserDtoUpdate user);
        Task<bool> Delete (Guid id);
    }
}