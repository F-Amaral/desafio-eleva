
using SistemaPrefeitura.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPrefeitura.Application.Interfaces
{
    public interface IEscolaService
    {
        Task<IEnumerable<Escola>> GetAllAsync();
        Task<Escola> GetByIdAsync(Guid id);
        Task<Escola> AddAsync(Escola escola);
        Task<Escola> UpdateAsync(Escola escola);
        Task DeleteByIdAsync(Guid id);

    }
}
