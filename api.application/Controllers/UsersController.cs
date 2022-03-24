using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    public class UsersController : ControllerBase
    {

        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize("Bearer")]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers(){
            try
            {
               if(!ModelState.IsValid){
                   return BadRequest(ModelState);
               }
               return Ok( await _userService.GetAll());
            }
            catch (ArgumentException e)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }

        // [Authorize("Bearer")]
        [HttpGet("{id}", Name ="GetId")]
        public async Task<IActionResult> GetUserById(Guid id){
            try
            {
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }
             return Ok(await _userService.Get(id));   
            }
            catch (ArgumentException e)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }

        // [Authorize("Bearer")]
        [HttpPost]
        public async Task<IActionResult> PostUser(UserDtoCreate user){
            try
            {
                if (!ModelState.IsValid){
                    return BadRequest(ModelState);
                }
                await _userService.Post(user);
                return Ok(user);
            }
            catch (ArgumentException e)
            {
                
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }

        // [Authorize("Bearer")]
        [HttpPut]
        public async Task<IActionResult> PutUser(UserDtoUpdate user){

            if(!ModelState.IsValid) return BadRequest ("Informações invalidas");
            try
            {
                var resultado = await _userService.Put(user);
                if(resultado != null){
                    return Ok(new {
                        resultado, 
                        mensagem = "Usuario atualizado com sucesso"});
                } else {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
                
        }

        // [Authorize("Bearer")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id){
        
        if (!ModelState.IsValid) return BadRequest("usuario nao encontrado!");
        try
        {
            await _userService.Delete(id); 
            return Ok( new {
                
                mensagem = $" usuario {id} deletado com sucesso!"
            });
        }
        catch (Exception ex)
        {
            
            throw ex;
        }
        }








    }
}