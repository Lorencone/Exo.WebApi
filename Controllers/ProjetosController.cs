using Exo.WebApi.Models;
using Exo.WebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Exo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetosController : ControllerBase
    {
        private readonly ProjetoRepository _projetoRepository;

        public ProjetosController(ProjetoRepository projetoRepository)
        {
            _projetoRepository = projetoRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var projetos = _projetoRepository.Listar();
                return Ok(projetos);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao listar os projetos.", erro = ex.Message });
            }
        }
    }
}