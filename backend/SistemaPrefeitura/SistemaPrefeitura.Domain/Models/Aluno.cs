using SistemaPrefeitura.Domain.Models.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaPrefeitura.Domain.Models
{
    public class Aluno : Entity
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public Guid EscolaId { get; set; }
        public virtual Escola Escola { get; set; }
        public Guid? TurmaId { get; set; }
        public virtual Turma Turma { get; set; }
    }
}
