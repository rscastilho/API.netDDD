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

    public class UserImplementation : BaseRepository<UserEntity>, IUserRepository
    {
    private DbSet<UserEntity> _dataset;

        public UserImplementation(AppDbContext context) : base(context)
        {
            _dataset = context.Set<UserEntity>();
        }

        public async Task<UserEntity> FindByLogin(string email)
        {
            return await _dataset.FirstOrDefaultAsync(u => u.Email.Equals(email));
        }
    }
}