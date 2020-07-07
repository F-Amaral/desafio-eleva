using SistemaPrefeitura.Domain.DataContracts.Shared;
using SistemaPrefeitura.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPrefeitura.Domain.DataContracts
{
    public interface ITurmaDisciplinaRepository : IBaseRepository<TurmaDisciplina>
    {
        Task<IEnumerable<TurmaDisciplina>> GetAllAsync(Guid turmaId);
        Task RemoveByIdAsync(Guid turmaId, Guid disciplinaId);
    }
}
