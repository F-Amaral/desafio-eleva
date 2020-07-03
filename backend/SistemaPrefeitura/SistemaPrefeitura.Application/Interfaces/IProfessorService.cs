using SistemaPrefeitura.Application.Interfaces.Shared;
using SistemaPrefeitura.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPrefeitura.Application.Interfaces
{
    public interface IProfessorService : IBaseService<Professor>
    {
        Task<IEnumerable<Professor>> GetAllAsync(Guid escolaId);
        Task<Professor> AddAsync(Professor professor, Guid escolaId);
    }
}
