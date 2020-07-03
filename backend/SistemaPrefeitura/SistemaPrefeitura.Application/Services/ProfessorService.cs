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
    public class ProfessorService : BaseService<Professor, IProfessorRepository>, IProfessorService
    {
        public ProfessorService(IProfessorRepository repository) : base(repository)
        {
        }

        public async Task<Professor> AddAsync(Professor professor, Guid escolaId)
        {
            professor.EscolaId = escolaId;
            await AddAsync(professor);
            return professor;
        }

        public async Task<IEnumerable<Professor>> GetAllAsync(Guid escolaId)
        {
            return await _repository.GetAllAsync(escolaId);
        }
    }
}
