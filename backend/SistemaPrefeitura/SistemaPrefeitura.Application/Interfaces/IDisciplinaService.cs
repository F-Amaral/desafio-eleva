using SistemaPrefeitura.Application.Interfaces.Shared;
using SistemaPrefeitura.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPrefeitura.Application.Interfaces
{
    public interface IDisciplinaService : IBaseService<Disciplina>
    {
        Task<Disciplina> AddAsync(Disciplina disciplina, Guid escolaId);
        Task<IEnumerable<Disciplina>> GetAllAsync(Guid escolaId);
    }
}
