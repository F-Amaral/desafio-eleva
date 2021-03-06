﻿using Microsoft.EntityFrameworkCore;
using SistemaPrefeitura.Domain.DataContracts;
using SistemaPrefeitura.Domain.Models;
using SistemaPrefeitura.Domain.SQL.DataContext;
using SistemaPrefeitura.Domain.SQL.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPrefeitura.Domain.SQL.Repositories
{
    public class DisciplinaRepository : BaseRepository<Disciplina>, IDisciplinaRepository
    {
        public DisciplinaRepository(DefaultContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Disciplina>> GetAllAsync(Guid escolaId)
        {
            return await DbSet.Where(x => x.EscolaId == escolaId).ToListAsync();
        }
    }
}
