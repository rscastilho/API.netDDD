using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using api.domain.Dtos;
using api.domain.Entities;
using api.domain.Repository;
using api.domain.Security;
using api.domain.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace api.service.Services
{
    public class LoginService : ILoginService
    {

        private readonly IUserRepository _repository;
        private SigningConfigurations _signingConfigurations;
        private TokenConfiguration _tokenConfiguration;
        private IConfiguration _configuration;


        public LoginService(IUserRepository repository, SigningConfigurations signingConfigurations, TokenConfiguration tokenConfiguration, IConfiguration configuration)
        {
            _repository = repository;
            _signingConfigurations = signingConfigurations;
            _tokenConfiguration = tokenConfiguration;
            _configuration = configuration;
        }
        public async Task<object> FindByLogin(LoginDto user)
        {
            
            if (user != null && !string.IsNullOrWhiteSpace(user.Email))
            {
               var baseUser = await _repository.FindByLogin(user.Email);
                if (baseUser == null)
                {
                    return new
                    {
                        authenticated = false,
                        mensagem = $"Falha ao autenticar {user.Email}"
                    };
                }
                else
                {
                    var identity = new ClaimsIdentity(
                        new GenericIdentity(baseUser.Email),
                        new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.UniqueName, baseUser.Email),
                        }
                    );
                    DateTime createDate = DateTime.Now;
                    DateTime expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfiguration.Seconds);

                    var handler = new JwtSecurityTokenHandler();
                    var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                    {
                        Issuer = _tokenConfiguration.Issuer,
                        Audience = _tokenConfiguration.Audience,
                        SigningCredentials = _signingConfigurations.SigingCredentials,
                        Subject = identity,
                        NotBefore = createDate,
                        Expires = expirationDate,
                    });
                    var token = handler.WriteToken(securityToken);
                return new
                    {
                        authenticated = true,
                        created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                        expiration = expirationDate.ToString("yyy-MM-dd HH:mm:ss"),
                        acessToken = token,
                        userName = user.Email,
                        message = "USuario logado com sucesso!"
                    };
                }
            }
            else
            {
                return new
                    {
                        authenticated = false,
                        mensagem = $"Falha ao autenticar"
                    };
            }
        }
  
    }
}