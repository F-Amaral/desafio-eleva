using SistemaPrefeitura.APP.DTOs;
using SistemaPrefeitura.APP.Mappers.ProfessorMappers;
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
        private readonly ProfessorToProfessorDTOMapper _professorToProfessorDTOMapper;

        public DisciplinaToDisciplinaDTOMapper(ProfessorToProfessorDTOMapper professorToProfessorDTOMapper)
        {
            _professorToProfessorDTOMapper = professorToProfessorDTOMapper;
        }

        public override DisciplinaDTO Map(Disciplina entry)
        {
            return new DisciplinaDTO()
            {
                Id = entry.Id,
                Nome = entry.Nome,
                ProfessorId = entry.ProfessorId,
                Professor = _professorToProfessorDTOMapper.Map(entry.Professor),
                EscolaId = entry.EscolaId
            };
        }
    }
}
