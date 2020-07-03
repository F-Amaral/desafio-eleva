using SistemaPrefeitura.Application.Interfaces.Shared;
using SistemaPrefeitura.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPrefeitura.Application.Interfaces
{
    public interface IAlunoService : IBaseService<Aluno>
    {
        Task<Aluno> AddAsync(Aluno aluno, Guid escolaId);
        Task<IEnumerable<Aluno>> GetAllAsync(Guid escolaId);

    }
}
