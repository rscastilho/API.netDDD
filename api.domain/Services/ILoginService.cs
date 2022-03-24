using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.domain.Dtos;
using api.domain.Entities;

namespace api.domain.Services
{
    public interface ILoginService
    {
        Task<Object> FindByLogin(LoginDto user);
        
    }
}