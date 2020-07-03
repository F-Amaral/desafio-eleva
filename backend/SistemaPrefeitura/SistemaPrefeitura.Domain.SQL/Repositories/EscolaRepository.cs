using Microsoft.EntityFrameworkCore;
using SistemaPrefeitura.Domain.DataContracts;
using SistemaPrefeitura.Domain.Models;
using SistemaPrefeitura.Domain.SQL.DataContext;
using SistemaPrefeitura.Domain.SQL.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaPrefeitura.Domain.SQL.Repositories
{
    public class EscolaRepository : BaseRepository<Escola>, IEscolaRepository
    {
        public EscolaRepository(DefaultContext dbContext) : base(dbContext)
        {
        }
    }
}
