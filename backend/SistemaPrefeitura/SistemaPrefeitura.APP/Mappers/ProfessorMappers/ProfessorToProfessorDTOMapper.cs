using SistemaPrefeitura.APP.DTOs;
using SistemaPrefeitura.APP.Mappers.Shared;
using SistemaPrefeitura.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPrefeitura.APP.Mappers.ProfessorMappers
{
    public class ProfessorToProfessorDTOMapper : BaseMapper<Professor, ProfessorDTO>
    {
        public override ProfessorDTO Map(Professor entry)
        {
            return new ProfessorDTO()
            {
                Id = entry.Id,
                Nome = entry.Nome,
                Sobrenome = entry.Sobrenome,
                EscolaId = entry.EscolaId
            };
        }
    }
}
