using SistemaPrefeitura.Application.Interfaces;
using SistemaPrefeitura.Domain.DataContracts;
using SistemaPrefeitura.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPrefeitura.Application.Services
{
    public class EscolaService : IEscolaService
    {
        private readonly IEscolaRepository _escolaRepository;

        public EscolaService(IEscolaRepository escolaRepository)
        {
            _escolaRepository = escolaRepository;
        }

        public async Task<Escola> AddAsync(Escola escola)
        {
            escola.Id = Guid.NewGuid();
            await _escolaRepository.AddAsync(escola);
            await _escolaRepository.SaveChangesAsync();
            return escola;
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            await _escolaRepository.RemoveByIdAsync(id);
            await _escolaRepository.SaveChangesAsync();

        }

        public async Task<IEnumerable<Escola>> GetAllAsync()
        {
            return await _escolaRepository.GetAllAsync();
        }

        public async Task<Escola> GetByIdAsync(Guid id)
        {
            return await _escolaRepository.GetByIdAsync(id);
        }

        public async Task<Escola> UpdateAsync(Escola escola)
        {
            await _escolaRepository.UpdateAsync(escola);
            await _escolaRepository.SaveChangesAsync();
            return escola;
        }
    }
}
