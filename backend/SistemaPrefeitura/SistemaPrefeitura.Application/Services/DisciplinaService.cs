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
    public class DisciplinaService : BaseService<Disciplina, IDisciplinaRepository>, IDisciplinaService
    {
        public DisciplinaService(IDisciplinaRepository repository) : base(repository)
        {
        }

        public async Task<Disciplina> AddAsync(Disciplina disciplina, Guid escolaId)
        {
            disciplina.EscolaId = escolaId;
            await AddAsync(disciplina);
            return disciplina;
        }

        public Task<IEnumerable<Disciplina>> GetAllAsync(Guid escolaId)
        {
            return _repository.GetAllAsync(escolaId);
        }
    }
}
