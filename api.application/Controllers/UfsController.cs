using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UfsController : ControllerBase
    {
        private readonly IUfService _service;

        public UfsController(IUfService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid) return BadRequest("erro ao processar informações");
            
            try
            {
                var resultado = await _service.GetAll();
                return Ok(resultado);
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }


    }
}