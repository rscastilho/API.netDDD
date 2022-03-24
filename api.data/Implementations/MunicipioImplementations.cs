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
    public class MunicipioImplementations : BaseRepository<MunicipioEntity>, IMunicipioRepository
    {
        private DbSet<MunicipioEntity> _dataSet;
        public MunicipioImplementations(AppDbContext context) : base(context)
        {
            _dataSet = context.Set<MunicipioEntity>();
        }

        public async Task<MunicipioEntity> GetCompleteByIBGe(int codIbge)
        {
            return await _dataSet.Include(x => x.UF).FirstOrDefaultAsync(x => x.CodIBGE.Equals(codIbge));
        }

        public async Task<MunicipioEntity> GetCompleteById(Guid Id)
        {
            return await _dataSet.Include(x => x.UF).FirstOrDefaultAsync(x => x.CodIBGE.Equals(Id));
        }
    }
}