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
    public class TurmaService : BaseService<Turma, ITurmaRepository>, ITurmaService
    {
        public TurmaService(ITurmaRepository repository) : base(repository)
        {
        }

        public async Task<Turma> AddAsync(Turma turma, Guid escolaId)
        {
            turma.EscolaId = escolaId;
            await AddAsync(turma);
            return turma;
        }

        public Task<IEnumerable<Turma>> GetAllAsync(Guid escolaId)
        {
            return _repository.GetAllAsync(escolaId);
        }
    }
}
