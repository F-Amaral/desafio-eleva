using SistemaPrefeitura.Domain.Models.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaPrefeitura.Domain.Models
{
    public class Disciplina : Entity
    {
        public string Nome { get; set; }
        public Guid ProfessorId { get; set; }
        //public Professor Professor { get; set; }
        public Guid EscolaId { get; set; }
        //public Escola Escola { get; set; }
        public IEnumerable<TurmaDisciplina> TurmasDisciplinas { get; set; }
    }
}
