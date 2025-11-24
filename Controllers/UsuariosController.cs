using Exo.WebApi.Models;
using Exo.WebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Exo.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuariosController(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_usuarioRepository.Listar());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao cadastrar o usuário.", erro = ex.Message });
            }
        }
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                var usuario = _usuarioRepository.BuscarPorId(id);
                if (usuario == null)
                {
                    return NotFound();
                }
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao buscar o usuário.", erro = ex.Message });
            }
        }
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Usuario usuario)
        {
            try
            {
                _usuarioRepository.Atualizar(id, usuario);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao atualizar o usuário.", erro = ex.Message });
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _usuarioRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao deletar o usuário.", erro = ex.Message });
            }
        }
        
    }
}