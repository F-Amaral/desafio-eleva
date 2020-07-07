using SistemaPrefeitura.APP.DTOs;
using SistemaPrefeitura.APP.Mappers.Shared;
using SistemaPrefeitura.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPrefeitura.APP.Mappers.ProfessorMappers
{
    public class ProfessorDTOToProfessorMapper : BaseMapper<ProfessorDTO,Professor>
    {
        public override Professor Map(ProfessorDTO entry)
        {
            return new Professor()
            {
                Nome = entry.Nome,
                Sobrenome = entry.Sobrenome,
                EscolaId = entry.EscolaId
            };
        }

        public Professor Map(ProfessorDTO entry, Guid id)
        {
            var professor = Map(entry);
            professor.Id = id;
            return professor;
        }
    }
}
