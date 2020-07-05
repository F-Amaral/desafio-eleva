using SistemaPrefeitura.Application.Interfaces;
using SistemaPrefeitura.Application.Services.Shared;
using SistemaPrefeitura.Domain.DataContracts;
using SistemaPrefeitura.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaPrefeitura.Application.Services
{
    public class TurmaDisciplinaService : BaseService<TurmaDisciplina, ITurmaDisciplinaRepository>, ITurmaDisciplinaService
    {
        public TurmaDisciplinaService(ITurmaDisciplinaRepository repository) : base(repository)
        {
        }
    }
}
