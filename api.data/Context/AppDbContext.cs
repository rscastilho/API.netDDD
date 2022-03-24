using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.data.Mapping;
using api.domain.Entities;
using Api.Data.Seeds;
using Microsoft.EntityFrameworkCore;

namespace api.data.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)        {           }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<UfEntity> Ufs { get; set; }
        public DbSet<MunicipioEntity> Municipios { get; set; }
        public DbSet<CepEntity> Ceps { get; set; }
     protected override void OnModelCreating(ModelBuilder modelBuilder)   {
         base.OnModelCreating(modelBuilder);

         modelBuilder.Entity<UserEntity>(new UserMap().Configure);
         modelBuilder.Entity<UfEntity>(new UfMap().Configure);
         modelBuilder.Entity<CepEntity>(new CepMap().Configure);
         modelBuilder.Entity<MunicipioEntity>(new MunicipioMap().Configure);

         modelBuilder.Entity<UserEntity>().HasData(
             new UserEntity{
                 Id = Guid.NewGuid(),
                 Name = "Administrador",
                 Email = "email@email.com.br",
                 CreateAt = DateTime.Now,
                 UpdateAt = DateTime.Now
             }
         );
        
        UfSeeds.Ufs(modelBuilder);
     }
    }
    
}