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
    public class UfImplementations : BaseRepository<UfEntity>, IUfRepository
    {
        private DbSet<UfEntity> _dataSet;
        public UfImplementations(AppDbContext context) : base(context)
        {
            _dataSet = context.Set<UfEntity>();
        }

        
    }
}