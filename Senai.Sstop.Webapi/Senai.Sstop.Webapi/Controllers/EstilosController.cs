using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Sstop.Webapi.Domains;
using Senai.Sstop.Webapi.Repositories;

namespace Senai.Sstop.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstilosController : ControllerBase
    {
        List<EstiloDomain> estilos = new List<EstiloDomain>
            {
            new EstiloDomain { IdEstilo = 1, Nome = "Rock" },
            new EstiloDomain { IdEstilo = 2, Nome = "Pop" },
            new EstiloDomain { IdEstilo = 3, Nome = "Folk" }

            };
        //[HttpGet]
        //public IEnumerable<EstiloDomain> Get()
        //{

        //    return estilos;
        //}

        [Produces("Application/json")]
        [HttpGet("{id}")]

        public IActionResult BuscarPorId(int id)
        {
            EstiloDomain Estilo = estilos.Find(x => x.IdEstilo == id);
            if (Estilo == null)
            {
                return NotFound();
            }
            return Ok(Estilo);
        }

        [HttpPost]

        public IActionResult Cadastrar(EstiloDomain estiloDomain)
        {
            estilos.Add(
                new EstiloDomain
                {
                    IdEstilo = estilos.Count + 1,
                    Nome = estiloDomain.Nome
                }

                );
            return Ok(estilos);
        }
        EstiloRepository estilorepository = new EstiloRepository();

        [HttpGet]

        public IEnumerable<EstiloDomain> ListarTodos()
        {
            return estilorepository.Listar();
        }
    }
}