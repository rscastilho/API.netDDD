using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.domain.Dtos;
using api.domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MunicipiosController : ControllerBase
    {
        private readonly IMunicipioService _municipio;

        public MunicipiosController(IMunicipioService municipio)
        {
            _municipio = municipio;
        }

        // [Authorize("Bearer")]
        [HttpGet]
        public async Task<IActionResult> GetAll(){
            if(!ModelState.IsValid) return BadRequest("Erro ao processar informações");
            try
            {
                var resultado = await _municipio.GetAll();
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        [HttpGet("GetByGuidId/{id}")]
        public async Task<IActionResult> Get(Guid id){
            if(!ModelState.IsValid) return BadRequest("Erro ao processar informações");
            try
            {
                var resultado = await _municipio.Get(id);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }


        [HttpGet("ibge/{codIbge}")]
        public async Task<IActionResult> getIbge(int codIbge){
            if(!ModelState.IsValid) return BadRequest("erro ao processar informações");
            
            try
            {
            var resultado =  await _municipio.GetCompleteByIBGE(codIbge);
            return Ok(resultado);
                
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

        }


[HttpPost]
    public async Task<IActionResult> Post (MunicipioDtoCreate municipio){
            if(!ModelState.IsValid) return BadRequest("erro ao processar informações");
            try
            {
                
                 await _municipio.Post(municipio);
                 return Ok(municipio);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
    }




    }
}