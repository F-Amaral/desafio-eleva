using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPrefeitura.APP.DTOs
{
    public class AlunoDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public Guid EscolaId { get; set; }
        public Guid? TurmaId { get; set; }
    }
}
