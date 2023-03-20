using Chapter.Interfaces;
using Chapter.Models;
using Chapter.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlTypes;
using System.Security.Cryptography.X509Certificates;

namespace Chapter.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class LivroController : ControllerBase
    {
        private readonly ILivroRepository _iLivroRepository;

        public LivroController(ILivroRepository livroRepository)
        {
            _iLivroRepository = livroRepository;
        }
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_iLivroRepository.Ler());
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id) {
            try
            {
                Livro livro = _iLivroRepository.BuscarPorId(id);
                if (livro == null)
                {
                    return NotFound();
                }
                return Ok(livro);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        [Authorize(Roles = "1")]
        [HttpPost]

        public IActionResult Casdastrar(Livro livro) {

            try
            {
                _iLivroRepository.Cadastrar(livro);
                return Ok();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        [HttpPut]

        public IActionResult Atualizar(int id, Livro livro) {
            try
            {
                _iLivroRepository.Atualizar(id, livro);
                return StatusCode(204);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
                      
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _iLivroRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }
    }
}