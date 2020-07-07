using SistemaPrefeitura.Application.Interfaces.Shared;
using SistemaPrefeitura.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPrefeitura.Application.Interfaces
{
    public interface ITurmaDisciplinaService : IBaseService<TurmaDisciplina>
    {
        Task<IEnumerable<TurmaDisciplina>> GetAllAsync(Guid turmaId);
        Task DeleteByIdAsync(Guid turmaId, Guid disciplinaId);
    }
}
