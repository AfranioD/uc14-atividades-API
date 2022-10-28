using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoExoApi.Models;
using ProjetoExoApi.Repositories;
using System.Data;

namespace ProjetoExoApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProjetoController : ControllerBase
    {
        private readonly ProjetoRepository _projetoRepository;

        public ProjetoController(ProjetoRepository projetoRepository)
        {
            _projetoRepository = projetoRepository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_projetoRepository.Listar());
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
                Projeto projetoBuscado = _projetoRepository.BuscarPorId(id);

                if (projetoBuscado == null)
                {
                    return NotFound();
                }

                return Ok(projetoBuscado);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }



        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Projeto l)
        {
            try
            {
                _projetoRepository.Cadastrar(l);

                return StatusCode(201);
                //return Ok("Projeto Cadastrado com sucesso");
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
                _projetoRepository.Deletar(id);

                return Ok("Projeto removido com sucesso");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        [HttpPut("{id}")]
        public IActionResult Alterar(int id, Projeto l)
        {
            try
            {
                _projetoRepository.Alterar(id, l);

                return StatusCode(204);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
