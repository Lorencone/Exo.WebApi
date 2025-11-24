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
        [HttpPost]
        public IActionResult Cadastrar(Projeto projeto)
        {
            try
            {
                _projetoRepository.Cadastrar(projeto);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao cadastrar o projeto.", erro = ex.Message });
            }
        }
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                var projeto = _projetoRepository.BuscarPorId(id);
                if (projeto == null)
                {
                    return NotFound();
                }
                return Ok(projeto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao buscar o projeto.", erro = ex.Message });
            }
        }
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Projeto projeto)
        {
            try
            {
                _projetoRepository.Atualizar(id, projeto);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao atualizar o projeto.", erro = ex.Message });
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _projetoRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao deletar o projeto.", erro = ex.Message });
            }
        }
    }
}