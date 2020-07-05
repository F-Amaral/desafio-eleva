using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPrefeitura.APP.DTOs
{
    public class DisciplinaDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Guid ProfessorId { get; set; }
        public ProfessorDTO Professor { get; set; }
        public Guid EscolaId { get; set; }
    }
}
