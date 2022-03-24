using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.domain.Dtos;

namespace api.domain.Services
{
    public interface IUfService
    {
        Task<UfDto> Get(Guid Id);
        Task<IEnumerable<UfDto>> GetAll();

    }
}