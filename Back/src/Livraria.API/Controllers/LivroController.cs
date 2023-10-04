using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Livraria.Domain.model;
using Livraria.Service;
using Livraria.Service.Contratos;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivroController : ControllerBase
    {
        private readonly ILivroService _livroService;

        public LivroController(ILivroService livroService)
        {
            _livroService = livroService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var livros = await _livroService.GetAllLivrosAsync();
                if (livros == null) return NotFound("Nenhum livro encontrado");
                return Ok(livros);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar livros. Erro: {e.Message}");
            }
        }
        [HttpGet("genero/{genero}")]
        public async Task<IActionResult> Get(string genero)
        {
            try
            {
                var livros = await _livroService.GetLivroByGeneroAsync(genero);
                if (livros == null) return NotFound("Nenhum livro encontrado");
                return Ok(livros);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar livros. Erro: {e.Message}");
            }
        }
        [HttpGet("titulo/{titulo}")]
        public async Task<IActionResult> GetTitulo(string titulo)
        {
            try
            {
                var livros = await _livroService.GetLivroByNameAsync(titulo);
                if (livros == null) return NotFound("Nenhum livro encontrado");
                return Ok(livros);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar livros. Erro: {e.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var livros = await _livroService.GetLivroByIdAsync(id);
                if (livros == null) return NotFound("Nenhum livro encontrado");
                return Ok(livros);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar livros. Erro: {e.Message}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(Livro model)
        {
            try
            {
                var livro = await _livroService.AddLivros(model);
                if (livro == null) return BadRequest("Nenhum livro encontrado");
                return Ok(livro);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar livros. Erro: {e.Message}");
            }
        }
        [HttpPut]
        public async Task<IActionResult> Put(int id, Livro model)
        {
            try
            {
                var livro = await _livroService.UpdateLivros(id, model);
                if (livro == null) return BadRequest("Nenhum livro encontrado");
                return Ok(livro);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar livros. Erro: {e.Message}");
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return await _livroService.DeleteLivro(id) ? Ok("Deletado") : BadRequest("Livro nao encontrado");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar livros. Erro: {e.Message}");
            }
        }
    }
}