using SistemaPrefeitura.Domain.Models.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaPrefeitura.Domain.Models
{
    public class Escola : Entity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public IEnumerable<Turma> Turmas { get; set; }
        public virtual IEnumerable<Professor> Professores { get; set; }
        public virtual IEnumerable<Aluno> Alunos { get; set; }
        public virtual IEnumerable<Disciplina> Disciplinas { get; set; }
    }
}
