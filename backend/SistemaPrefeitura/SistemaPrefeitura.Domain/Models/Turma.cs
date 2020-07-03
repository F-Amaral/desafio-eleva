using SistemaPrefeitura.Domain.Models.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaPrefeitura.Domain.Models
{
    public class Turma : Entity
    {
        public string Nome { get; set; }
        public string Ano { get; set; }
        public virtual Guid EscolaId { get; set; }
        public virtual IEnumerable<Disciplina> Disciplinas { get; set; }
        public virtual IEnumerable<Aluno> Alunos { get; set; }
    }
}
