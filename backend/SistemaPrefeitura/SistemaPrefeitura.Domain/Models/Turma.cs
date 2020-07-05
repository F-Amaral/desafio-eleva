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
        public Guid EscolaId { get; set; }
        public virtual Escola Escola { get; set; }
        public virtual IEnumerable<TurmaDisciplina> TurmasDisciplinas { get; set; }
        public virtual IEnumerable<Aluno> Alunos { get; set; }
    }
}
