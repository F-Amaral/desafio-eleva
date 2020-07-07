using SistemaPrefeitura.Application.Interfaces;
using SistemaPrefeitura.Application.Services.Shared;
using SistemaPrefeitura.Domain.DataContracts;
using SistemaPrefeitura.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPrefeitura.Application.Services
{
    public class AlunoService : BaseService<Aluno, IAlunoRepository>, IAlunoService
    {
        public AlunoService(IAlunoRepository repository) : base(repository)
        {
        }

        public async Task<IEnumerable<Aluno>> GetAllAsync(Guid escolaId)
        {
            return await _repository.GetAllAsync(escolaId);
        }

        public async Task<Aluno> AddAsync(Aluno aluno, Guid escolaId)
        {
            aluno.EscolaId = escolaId;
            return await AddAsync(aluno);
        }

        public Task<IEnumerable<Aluno>> GetAllByTurmaIdAsync(Guid turmaId)
        {
            return _repository.GetAllByTurmaIdAsync(turmaId);
        }
    }
}
