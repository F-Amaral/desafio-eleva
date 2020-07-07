using SistemaPrefeitura.APP.DTOs;
using SistemaPrefeitura.APP.Mappers.Shared;
using SistemaPrefeitura.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPrefeitura.APP.Mappers.AlunoMappers
{
    public class AlunoDTOToAlunoMapper : BaseMapper<AlunoDTO,Aluno>
    {
        public override Aluno Map(AlunoDTO entry)
        {
            return new Aluno()
            {
                Nome = entry.Nome,
                Sobrenome = entry.Sobrenome,
                DataNascimento = entry.DataNascimento,
                TurmaId = entry.TurmaId
            };
        }

        public Aluno Map(AlunoDTO entry, Guid id)
        {
            var aluno = Map(entry);
            aluno.Id = id;
            return aluno;
        }
    }
}
