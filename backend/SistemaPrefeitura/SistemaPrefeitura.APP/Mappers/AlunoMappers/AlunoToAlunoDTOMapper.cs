using SistemaPrefeitura.APP.DTOs;
using SistemaPrefeitura.APP.Mappers.Shared;
using SistemaPrefeitura.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPrefeitura.APP.Mappers.AlunoMappers
{
    public class AlunoToAlunoDTOMapper : BaseMapper<Aluno, AlunoDTO>
    {
        public override AlunoDTO Map(Aluno entry)
        {
            return new AlunoDTO()
            {
                Id = entry.Id,
                Nome = entry.Nome,
                Sobrenome = entry.Sobrenome,
                DataNascimento = entry.DataNascimento.Date
            };
        }
    }
}
