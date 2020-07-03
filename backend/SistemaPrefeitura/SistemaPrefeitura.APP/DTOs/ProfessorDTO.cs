using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SistemaPrefeitura.APP.DTOs
{
    public class ProfessorDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public Guid EscolaId { get; set; }
    }
}
