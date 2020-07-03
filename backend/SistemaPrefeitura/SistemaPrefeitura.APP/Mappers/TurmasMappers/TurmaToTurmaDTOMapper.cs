using SistemaPrefeitura.APP.DTOs;
using SistemaPrefeitura.APP.Mappers.Shared;
using SistemaPrefeitura.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPrefeitura.APP.Mappers.ProfessorMappers
{
    public class TurmaToTurmaDTOMapper : BaseMapper<Turma, TurmaDTO>
    {
        public override TurmaDTO Map(Turma entry)
        {
            return new TurmaDTO()
            {
                Id = entry.Id,
                Nome = entry.Nome,
                Ano = entry.Ano,
                EscolaId = entry.EscolaId,
            };
        }
    }
}
