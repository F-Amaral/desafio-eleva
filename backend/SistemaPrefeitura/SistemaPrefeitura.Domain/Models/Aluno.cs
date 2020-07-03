using SistemaPrefeitura.Domain.Models.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaPrefeitura.Domain.Models
{
    public class Aluno : Entity
    {
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
