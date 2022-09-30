using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uc14ER1.Models;
using Uc14ER1.Repositories;

namespace Uc14ER1.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class LivroController : ControllerBase
    {
        private readonly LivroRepository _livroRepository;

        public Livro LivroBuscado { get; private set; }

        public LivroController(LivroRepository livroRepository)
        {
            _livroRepository = livroRepository;     
        }


        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_livroRepository.Listar());

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
               Livro LivroBuscado = _livroRepository.BuscarPorId(id);

                if (LivroBuscado == null)
                {
                    return NotFound();
                }

                return Ok(LivroBuscado);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }



        [HttpPost]
        public IActionResult Cadastrar(Livro l) 
        {
            try
            {
                _livroRepository.Cadastrar(l);

                return StatusCode(201);
                //return Ok("Livro cadastrado com suceso");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }


        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _livroRepository.Deletar(id);

                return Ok("Livro removido com sucesso");
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }



        [HttpPut("{id}")]

        public IActionResult Alterar(int id, Livro l)
            {
            try
            {
                _livroRepository.Alterar(id, l);

                return StatusCode(204);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }

        }

    }
}
