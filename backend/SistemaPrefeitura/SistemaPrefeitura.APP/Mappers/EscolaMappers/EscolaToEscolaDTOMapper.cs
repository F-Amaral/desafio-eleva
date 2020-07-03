using SistemaPrefeitura.APP.DTOs;
using SistemaPrefeitura.APP.Mappers.Shared;
using SistemaPrefeitura.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPrefeitura.APP.Mappers.EscolaMappers
{
    public class EscolaToEscolaDTOMapper : BaseMapper<Escola, EscolaDTO>
    {
        public override EscolaDTO Map(Escola entry)
        {
            return new EscolaDTO()
            {
                Id = entry.Id,
                Descricao = entry.Descricao,
                Nome = entry.Nome
            };
        }
    }
}
