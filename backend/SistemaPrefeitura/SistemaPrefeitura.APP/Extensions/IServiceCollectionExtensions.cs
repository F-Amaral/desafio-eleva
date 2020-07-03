﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaPrefeitura.APP.Mappers.EscolaMappers;
using SistemaPrefeitura.Application.Interfaces;
using SistemaPrefeitura.Application.Services;
using SistemaPrefeitura.Domain.DataContracts;
using SistemaPrefeitura.Domain.SQL.DataContext;
using SistemaPrefeitura.Domain.SQL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPrefeitura.APP.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddConfigurations(this IServiceCollection services, IConfiguration configuration)
        {


            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IEscolaService, EscolaService>();
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IEscolaRepository, EscolaRepository>();
            return services;
        }

        public static IServiceCollection AddMappers(this IServiceCollection services)
        {
            services.AddScoped<EscolaDTOToEscolaMapper>();
            services.AddScoped<EscolaToEscolaDTOMapper>();
            return services;
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DefaultContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            return services;
        }

    }
}