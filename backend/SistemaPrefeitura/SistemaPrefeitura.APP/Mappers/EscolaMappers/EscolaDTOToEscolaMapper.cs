using SistemaPrefeitura.APP.DTOs;
using SistemaPrefeitura.APP.Mappers.Shared;
using SistemaPrefeitura.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPrefeitura.APP.Mappers.EscolaMappers
{
    public class EscolaDTOToEscolaMapper : BaseMapper<EscolaDTO, Escola>
    {
        public override Escola Map(EscolaDTO entry)
        {
            return new Escola()
            {
                Descricao = entry.Descricao,
                Nome = entry.Nome
            };
        }

        public Escola Map(EscolaDTO entry, Guid id)
        {
            var escola = Map(entry);
            escola.Id = id;
            return escola;
        }
    }
}
