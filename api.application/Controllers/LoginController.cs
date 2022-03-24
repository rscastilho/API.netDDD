using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.domain.Dtos;
using api.domain.Entities;
using api.domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _login;

        public LoginController(ILoginService login)
        {
            _login = login;
        }
        
        [AllowAnonymous]
        [HttpPost]
        public async Task<object> Login (LoginDto login){

            if(!ModelState.IsValid || login == null) return BadRequest ("Erro ao processar informações");
            try
            {
             var resultado = await _login.FindByLogin(login);
             if(resultado == null) return BadRequest("Registro nao encontrado");
             return Ok(resultado);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            

        }


    }
}