using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.data.Context;
using api.data.Implementations;
using api.data.Repository;
using api.domain.Interfaces;
using api.domain.Repository;
using api.domain.Services;
using api.service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace api.crosscutting.DependenceInjection
{
    public class ConfigureService
    {
            public static void ConfigureDependenceService(IServiceCollection serviceCollection){
            
            
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddScoped<IUserRepository, UserImplementation>();           
            
            serviceCollection.AddTransient<ILoginService, LoginService>();

            serviceCollection.AddTransient<IMunicipioService, MunicipioService>();
            serviceCollection.AddScoped<IMunicipioRepository, MunicipioImplementations>();           

            serviceCollection.AddTransient<IUfService, UfService>();
            serviceCollection.AddScoped<IUfRepository, UfImplementations>();           
            
            serviceCollection.AddTransient<ICepService, CepService>();
            serviceCollection.AddScoped<ICepRepository, CepImplementations>();           
            
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            
            serviceCollection.AddDbContext<AppDbContext>(options => options.UseMySql("server=localhost;user=developer;password=castilho;database=apiddd"));
        }
    }
}