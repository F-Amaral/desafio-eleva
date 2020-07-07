using SistemaPrefeitura.Domain.DataContracts.Shared;
using SistemaPrefeitura.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPrefeitura.Domain.DataContracts
{
    public interface IAlunoRepository : IBaseRepository<Aluno>
    {
        Task<IEnumerable<Aluno>> GetAllAsync(Guid escolaId);
        Task<IEnumerable<Aluno>> GetAllByTurmaIdAsync(Guid turmaId);
    }
}