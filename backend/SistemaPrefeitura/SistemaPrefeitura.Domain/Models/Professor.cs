using SistemaPrefeitura.Domain.Models.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaPrefeitura.Domain.Models
{
    public class Professor : Entity
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public virtual Guid EscolaId { get; set; }
    }
}
