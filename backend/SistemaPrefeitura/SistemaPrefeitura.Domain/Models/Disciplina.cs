﻿using SistemaPrefeitura.Domain.Models.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaPrefeitura.Domain.Models
{
    public class Disciplina : Entity
    {
        public string Nome { get; set; }
        public Guid ProfessorId { get; set; }
        public Guid EscolaId { get; set; }
    }
}
