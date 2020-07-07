using SistemaPrefeitura.Application.Interfaces;
using SistemaPrefeitura.Application.Services.Shared;
using SistemaPrefeitura.Domain.DataContracts;
using SistemaPrefeitura.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPrefeitura.Application.Services
{
    public class TurmaService : BaseService<Turma, ITurmaRepository>, ITurmaService
    {
        private readonly ITurmaDisciplinaService _turmaDisciplinaService;
        private readonly IAlunoService _alunoService;
        private readonly IDisciplinaService _disciplinaService;

        public TurmaService(ITurmaRepository repository,
                            ITurmaDisciplinaService turmaDisciplinaService,
                            IAlunoService alunoService,
                            IDisciplinaService disciplinaService) : base(repository)
        {
            _turmaDisciplinaService = turmaDisciplinaService;
            _alunoService = alunoService;
            _disciplinaService = disciplinaService;
        }

        public async Task<Turma> AddAlunosAsync(Guid turmaId, IEnumerable<Guid> alunosIds)
        {
            var turma = await _repository.GetByIdAsync(turmaId);
            var alunosAux = (await _alunoService.GetAllAsync()).Where(x => alunosIds.Contains(x.Id)).ToList();
            foreach(var aluno in alunosAux)
            {
                aluno.TurmaId = turma.Id;
                turma.Alunos.Append(aluno);
            }
            await UpdateAsync(turma);
            await _alunoService.UpdateCollectionAsync(turma.Alunos);
            return turma;
        }

        public async Task<Turma> AddAsync(Turma turma, Guid escolaId)
        {
            turma.EscolaId = escolaId;
            await AddAsync(turma);
            return turma;
        }

        public async Task<IEnumerable<Disciplina>> AddDisciplinasAsync(Guid turmaId, IEnumerable<Guid> disciplinasIds)
        {
            var turmasDisciplinas = new List<TurmaDisciplina>();
            foreach(var disciplinaId in disciplinasIds)
            {
                turmasDisciplinas.Add(new TurmaDisciplina() { TurmaId = turmaId, DisciplinaId = disciplinaId });
            }

            await _turmaDisciplinaService.AddCollectionAsync(turmasDisciplinas);
            return (await _disciplinaService.GetAllAsync()).Where(x => disciplinasIds.Contains(x.Id));
        }

        public Task<IEnumerable<Turma>> GetAllAsync(Guid escolaId)
        {
            return _repository.GetAllAsync(escolaId);
        }

        public async Task<IEnumerable<Aluno>> GetAlunos(Guid turmaId)
        {
            return await _alunoService.GetAllByTurmaIdAsync(turmaId);
        }

        public async Task<IEnumerable<Disciplina>> GetDisciplinas(Guid turmaId)
        {
            return (await _turmaDisciplinaService.GetAllAsync(turmaId)).Select(x => x.Disciplina);
        }

        public async Task RemoveAluno(Guid turmaId, Guid alunoId)
        {
            var aluno = await _alunoService.GetByIdAsync(alunoId);
            var turma = await _repository.GetByIdAsync(turmaId);
            turma.Alunos.ToList().Remove(aluno);
            aluno.TurmaId = null;
            await _repository.UpdateAsync(turma);
            await _alunoService.UpdateAsync(aluno);
        }

        public async Task RemoveDisciplina(Guid turmaId, Guid disciplinaId)
        {
            await _turmaDisciplinaService.DeleteByIdAsync(turmaId, disciplinaId);
        }
    }
}
