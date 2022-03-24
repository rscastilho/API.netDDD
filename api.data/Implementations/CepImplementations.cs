using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.data.Context;
using api.data.Repository;
using api.domain.Entities;
using api.domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace api.data.Implementations
{
    public class CepImplementations : BaseRepository<CepEntity>, ICepRepository
    {
        private DbSet<CepEntity> _dataSet;
        public CepImplementations(AppDbContext context) : base(context)
        {
            _dataSet = context.Set<CepEntity>();
        }

        public async Task<CepEntity> SelectAsynct(string cep)
        {
            return await _dataSet.Include(x => x.Municipio).ThenInclude(x => x.UF).FirstOrDefaultAsync(x => x.CEP.Equals(cep));
        }
    }
}