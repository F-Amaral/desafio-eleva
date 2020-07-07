using SistemaPrefeitura.APP.DTOs;
using SistemaPrefeitura.APP.Mappers.ProfessorMappers;
using SistemaPrefeitura.APP.Mappers.Shared;
using SistemaPrefeitura.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPrefeitura.APP.Mappers.TurmaDisciplinaMappers
{
    public class TurmaDisciplinaToDisciplinaDTOMapper : BaseMapper<TurmaDisciplina, DisciplinaDTO>
    {
        private readonly ProfessorToProfessorDTOMapper _professorToProfessorDTOMapper;

        public TurmaDisciplinaToDisciplinaDTOMapper(ProfessorToProfessorDTOMapper professorToProfessorDTOMapper)
        {
            _professorToProfessorDTOMapper = professorToProfessorDTOMapper;
        }

        public override DisciplinaDTO Map(TurmaDisciplina entry)
        {
            return new DisciplinaDTO()
            {
                Id = entry.DisciplinaId,
                Nome = entry.Disciplina.Nome,
                EscolaId = entry.Disciplina.EscolaId,
                ProfessorId = entry.Disciplina.ProfessorId,
                Professor = _professorToProfessorDTOMapper.Map(entry.Disciplina.Professor)
            };
        }
    }
}
