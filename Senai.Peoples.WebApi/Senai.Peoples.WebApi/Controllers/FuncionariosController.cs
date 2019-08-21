using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Repositories;

namespace Senai.Peoples.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {

        FuncionariosRepository funcionariosRepository = new FuncionariosRepository();

        [HttpGet]

        public IEnumerable<FuncionariosDomain> ListarTodos()
        {
            return funcionariosRepository.Listar();
        }

        // /api/funcionarios/1
        [HttpGet("{id}")]

        public IActionResult BuscarPorId(int id)
        {
           FuncionariosDomain funcionario = funcionariosRepository.BuscarPorId(id);

                if (id == null)
                {
                    return NotFound();
                }
                return Ok(funcionario);
        }

        [HttpPost]
        public IActionResult Cadastrar(FuncionariosDomain funcionario)
        {
            funcionariosRepository.Cadastrar(funcionario);
            return Ok(funcionario);
        }

        [HttpDelete("{id}")]
        
        public IActionResult Deletar(int id)
        {
            funcionariosRepository.Deletar(id);
            return Ok();
        }

        [HttpPut]

        public IActionResult Atualizar(FuncionariosDomain funcionario)
        {
            funcionariosRepository.Atualizar(funcionario);
            return Ok();
        }

        // /api/funcionarios/buscar/helena
        [HttpGet("buscar/{Nome}")]

        public IActionResult BuscarPorNome(string Nome)
        {
            FuncionariosDomain funcionario = funcionariosRepository.BuscarPorNome(Nome);

            if (Nome == null)
            {
                return NotFound();
            }
            return Ok(funcionario);
        }

        [HttpGet("NomeCompleto")]

        public IEnumerable<FuncionariosDomain> ListarNomeCompleto()
        {
            return funcionariosRepository.ListarNomeCompleto();
        }
    }
}