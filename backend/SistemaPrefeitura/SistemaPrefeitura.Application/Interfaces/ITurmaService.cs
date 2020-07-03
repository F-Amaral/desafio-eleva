using SistemaPrefeitura.Application.Interfaces.Shared;
using SistemaPrefeitura.Application.Services.Shared;
using SistemaPrefeitura.Domain.DataContracts;
using SistemaPrefeitura.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPrefeitura.Application.Interfaces
{
    public interface ITurmaService : IBaseService<Turma>
    {
        Task<Turma> AddAsync(Turma turma, Guid escolaId);
        Task<IEnumerable<Turma>> GetAllAsync(Guid escolaId);
    }
}
