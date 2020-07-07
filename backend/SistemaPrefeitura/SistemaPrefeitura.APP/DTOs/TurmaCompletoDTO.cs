using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPrefeitura.APP.DTOs
{
    public class TurmaCompletoDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Ano { get; set; }
        public Guid EscolaId { get; set; }
        public EscolaDTO Escola { get; set; }
        public IEnumerable<DisciplinaDTO> Disciplinas { get; set; }
        public IEnumerable<AlunoDTO> Alunos { get; set; }
    }
}
