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
    public class TurmaDisciplinaService : BaseService<TurmaDisciplina, ITurmaDisciplinaRepository>, ITurmaDisciplinaService
    {
        public TurmaDisciplinaService(ITurmaDisciplinaRepository repository) : base(repository)
        {
        }

        public async Task DeleteByIdAsync(Guid turmaId, Guid disciplinaId)
        {
            await _repository.RemoveByIdAsync(turmaId, disciplinaId);
            await _repository.SaveChangesAsync();
        }

        public Task<IEnumerable<TurmaDisciplina>> GetAllAsync(Guid turmaId)
        {
            return _repository.GetAllAsync(turmaId);
        }
    }
}
