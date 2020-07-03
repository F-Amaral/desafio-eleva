﻿using Microsoft.EntityFrameworkCore;
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
        public DefaultContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }
    
    }
}
