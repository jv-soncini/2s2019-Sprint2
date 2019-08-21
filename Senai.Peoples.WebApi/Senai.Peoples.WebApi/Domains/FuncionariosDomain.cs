using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Domains
{
    public class FuncionariosDomain
    {
        public int IdFuncionario { get; set; }

        public string Nome { get; set; }
        [Required(ErrorMessage ="Por favor insira o nome")]

        public string Sobrenome { get; set; }

        public DateTime DataNascimento { get; set; }
    }
}
