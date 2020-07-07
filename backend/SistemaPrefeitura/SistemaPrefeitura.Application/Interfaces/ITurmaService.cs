using SistemaPrefeitura.Application.Interfaces.Shared;
using SistemaPrefeitura.Application.Services.Shared;
using SistemaPrefeitura.Domain.DataContracts;
using SistemaPrefeitura.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPrefeitura.Application.Interfaces
{
    public interface ITurmaService : IBaseService<Turma>
    {
        Task<Turma> AddAsync(Turma turma, Guid escolaId);
        Task<IEnumerable<Turma>> GetAllAsync(Guid escolaId);
        Task<IEnumerable<Disciplina>> AddDisciplinasAsync(Guid turmaId, IEnumerable<Guid> disciplinasIds);
        Task<Turma> AddAlunosAsync(Guid turmaId, IEnumerable<Guid> alunosIds);
        Task<IEnumerable<Disciplina>> GetDisciplinas(Guid turmaId);
        Task<IEnumerable<Aluno>> GetAlunos(Guid turmaId);
        Task RemoveAluno(Guid turmaId, Guid alunoId);
        Task RemoveDisciplina(Guid turmaId, Guid disciplinaId);
    }
}
