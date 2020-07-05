using SistemaPrefeitura.Domain.Models.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaPrefeitura.Domain.Models
{
    public class TurmaDisciplina : Entity
    {
        public Guid TurmaId { get; set; }
        public virtual Turma Turma { get; set; }
        public Guid DisciplinaId { get; set; }
        public virtual Disciplina Disciplina { get; set; }
    }
}
