using SistemaPrefeitura.APP.DTOs;
using SistemaPrefeitura.APP.Mappers.AlunoMappers;
using SistemaPrefeitura.APP.Mappers.DisciplinaMappers;
using SistemaPrefeitura.APP.Mappers.EscolaMappers;
using SistemaPrefeitura.APP.Mappers.Shared;
using SistemaPrefeitura.APP.Mappers.TurmaDisciplinaMappers;
using SistemaPrefeitura.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPrefeitura.APP.Mappers.TurmasMappers
{
    public class TurmaToTurmaCompletoDTOMapper : BaseMapper<Turma, TurmaCompletoDTO>
    {
        private readonly EscolaToEscolaDTOMapper _escolaToEscolaDTOMapper;
        private readonly AlunoToAlunoDTOMapper _alunoToAlunoDTOMapper;
        private readonly DisciplinaToDisciplinaDTOMapper _disciplinaToDisciplinaDTOMapper;

        public TurmaToTurmaCompletoDTOMapper(EscolaToEscolaDTOMapper escolaToEscolaDTOMapper,
                                             AlunoToAlunoDTOMapper alunoToAlunoDTOMapper,
                                             DisciplinaToDisciplinaDTOMapper disciplinaToDisciplinaDTOMapper)
        {
            _escolaToEscolaDTOMapper = escolaToEscolaDTOMapper;
            _alunoToAlunoDTOMapper = alunoToAlunoDTOMapper;
            _disciplinaToDisciplinaDTOMapper = disciplinaToDisciplinaDTOMapper;
        }

        public override TurmaCompletoDTO Map(Turma entry)
        {
            return new TurmaCompletoDTO
            {
                Id = entry.Id,
                Nome = entry.Nome,
                Ano = entry.Ano,
                EscolaId = entry.EscolaId,
                Escola = _escolaToEscolaDTOMapper.Map(entry.Escola),
                Alunos = _alunoToAlunoDTOMapper.Map(entry.Alunos)
            };
        }

        public TurmaCompletoDTO Map(Turma turma, IEnumerable<Disciplina> disciplinas)
        {
            TurmaCompletoDTO turmaCompletoDTO = Map(turma);
            turmaCompletoDTO.Disciplinas = _disciplinaToDisciplinaDTOMapper.Map(disciplinas);
            return turmaCompletoDTO;
        }
    }
}
