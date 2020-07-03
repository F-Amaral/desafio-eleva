using SistemaPrefeitura.Domain.DataContracts.Shared;
using SistemaPrefeitura.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPrefeitura.Domain.DataContracts
{
    public interface ITurmaRepository : IBaseRepository<Turma>
    {
        Task<IEnumerable<Turma>> GetAllAsync(Guid escolaId);
    }
}
