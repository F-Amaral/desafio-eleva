using SistemaPrefeitura.APP.DTOs;
using SistemaPrefeitura.APP.Mappers.Shared;
using SistemaPrefeitura.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPrefeitura.APP.Mappers.DisciplinaMappers
{
    public class DisciplinaDTOToDisciplinaMapper : BaseMapper<DisciplinaDTO,Disciplina>
    {
        public override Disciplina Map(DisciplinaDTO entry)
        {
            return new Disciplina()
            {
                Nome = entry.Nome,
                ProfessorId = entry.ProfessorId
            };
        }

        public Disciplina Map(DisciplinaDTO entry, Guid id)
        {
            var disciplina = Map(entry);
            disciplina.Id = id;
            return disciplina;
        }
    }
}
