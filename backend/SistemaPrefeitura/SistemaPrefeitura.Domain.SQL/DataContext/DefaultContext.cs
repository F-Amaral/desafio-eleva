using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SistemaPrefeitura.Domain.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace SistemaPrefeitura.Domain.SQL.DataContext
{
    public class DefaultContext : DbContext
    {
        public DbSet<Escola> Escolas { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }

        public DefaultContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }
    
    }
}
