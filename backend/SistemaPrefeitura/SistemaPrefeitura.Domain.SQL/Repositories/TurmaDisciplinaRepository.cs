using Microsoft.EntityFrameworkCore;
using SistemaPrefeitura.Domain.DataContracts;
using SistemaPrefeitura.Domain.Models;
using SistemaPrefeitura.Domain.SQL.DataContext;
using SistemaPrefeitura.Domain.SQL.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPrefeitura.Domain.SQL.Repositories
{
    public class TurmaDisciplinaRepository : BaseRepository<TurmaDisciplina>, ITurmaDisciplinaRepository
    {
        public TurmaDisciplinaRepository(DefaultContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<TurmaDisciplina>> GetAllAsync(Guid turmaId)
        {
            return await DbSet.Where(x => x.TurmaId == turmaId).ToListAsync();
        }

        public Task RemoveByIdAsync(Guid turmaId, Guid disciplinaId)
        {
            var disciplina = DbSet.Where(x => x.DisciplinaId == disciplinaId && x.TurmaId == turmaId).FirstOrDefault();
            DbSet.Remove(disciplina);
            return Task.CompletedTask;
        }
    }
}
