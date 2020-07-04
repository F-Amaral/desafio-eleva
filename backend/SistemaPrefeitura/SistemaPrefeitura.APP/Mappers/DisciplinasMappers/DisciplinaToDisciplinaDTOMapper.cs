using SistemaPrefeitura.APP.DTOs;
using SistemaPrefeitura.APP.Mappers.Shared;
using SistemaPrefeitura.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPrefeitura.APP.Mappers.DisciplinaMappers
{
    public class DisciplinaToDisciplinaDTOMapper : BaseMapper<Disciplina, DisciplinaDTO>
    {
        public override DisciplinaDTO Map(Disciplina entry)
        {
            return new DisciplinaDTO()
            {
                Id = entry.Id,
                Nome = entry.Nome,
                ProfessorId = entry.ProfessorId,
                EscolaId = entry.EscolaId
            };
        }
    }
}
