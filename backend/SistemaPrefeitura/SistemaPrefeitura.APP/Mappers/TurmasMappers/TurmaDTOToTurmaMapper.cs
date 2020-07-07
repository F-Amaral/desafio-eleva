using SistemaPrefeitura.APP.DTOs;
using SistemaPrefeitura.APP.Mappers.Shared;
using SistemaPrefeitura.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPrefeitura.APP.Mappers.TurmaMappers
{
    public class TurmaDTOToTurmaMapper : BaseMapper<TurmaDTO,Turma>
    {
        public override Turma Map(TurmaDTO entry)
        {
            return new Turma()
            {
                Nome = entry.Nome,
                Ano = entry.Ano,
                EscolaId = entry.EscolaId
            };
        }

        public Turma Map(TurmaDTO entry, Guid id)
        {
            var turma = Map(entry);
            turma.Id = id;
            return turma;
        }
    }
}
