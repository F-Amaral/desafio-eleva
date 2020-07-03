using SistemaPrefeitura.Application.Interfaces;
using SistemaPrefeitura.Application.Services.Shared;
using SistemaPrefeitura.Domain.DataContracts;
using SistemaPrefeitura.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPrefeitura.Application.Services
{
    public class EscolaService : BaseService<Escola, IEscolaRepository>, IEscolaService
    {
        public EscolaService(IEscolaRepository escolaRepository) : base(escolaRepository)
        {
        }   
    }
}
