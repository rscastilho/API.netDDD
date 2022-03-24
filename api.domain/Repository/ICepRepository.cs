using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.domain.Entities;
using api.domain.Interfaces;

namespace api.domain.Repository
{
    public interface ICepRepository: IRepository<CepEntity>
    {
        Task<CepEntity> SelectAsynct(string cep);
    }
}