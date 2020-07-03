using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPrefeitura.APP.DTOs
{
    public class TurmaDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Ano { get; set; }
        public virtual Guid EscolaId { get; set; }
    }
}
