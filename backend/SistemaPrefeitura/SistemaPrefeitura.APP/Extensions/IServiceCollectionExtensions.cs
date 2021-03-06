﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Models;
using SistemaPrefeitura.APP.Mappers.AlunoMappers;
using SistemaPrefeitura.APP.Mappers.DisciplinaMappers;
using SistemaPrefeitura.APP.Mappers.EscolaMappers;
using SistemaPrefeitura.APP.Mappers.ProfessorMappers;
using SistemaPrefeitura.APP.Mappers.TurmaDisciplinaMappers;
using SistemaPrefeitura.APP.Mappers.TurmaMappers;
using SistemaPrefeitura.APP.Mappers.TurmasMappers;
using SistemaPrefeitura.Application.Interfaces;
using SistemaPrefeitura.Application.Services;
using SistemaPrefeitura.Domain.DataContracts;
using SistemaPrefeitura.Domain.SQL.DataContext;
using SistemaPrefeitura.Domain.SQL.Repositories;
using SistemaPrefeitura.Infra.Common.Configurations;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPrefeitura.APP.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IEscolaService, EscolaService>();
            services.AddScoped<IAlunoService, AlunoService>();
            services.AddScoped<IProfessorService, ProfessorService>();
            services.AddScoped<ITurmaService, TurmaService>();
            services.AddScoped<IDisciplinaService, DisciplinaService>();
            services.AddScoped<ITurmaDisciplinaService, TurmaDisciplinaService>();
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IEscolaRepository, EscolaRepository>();
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<IProfessorRepository, ProfessorRepository>();
            services.AddScoped<ITurmaRepository, TurmaRepository>();
            services.AddScoped<IDisciplinaRepository, DisciplinaRepository>();
            services.AddScoped<ITurmaDisciplinaRepository, TurmaDisciplinaRepository>();
            return services;
        }

        public static IServiceCollection AddMappers(this IServiceCollection services)
        {
            services.AddScoped<EscolaDTOToEscolaMapper>();
            services.AddScoped<EscolaToEscolaDTOMapper>();
            services.AddScoped<AlunoDTOToAlunoMapper>();
            services.AddScoped<AlunoToAlunoDTOMapper>();
            services.AddScoped<ProfessorDTOToProfessorMapper>();
            services.AddScoped<ProfessorToProfessorDTOMapper>();
            services.AddScoped<TurmaDTOToTurmaMapper>();
            services.AddScoped<TurmaToTurmaDTOMapper>();
            services.AddScoped<TurmaToTurmaCompletoDTOMapper>();
            services.AddScoped<DisciplinaDTOToDisciplinaMapper>();
            services.AddScoped<DisciplinaToDisciplinaDTOMapper>();
            services.AddScoped<TurmaDisciplinaToDisciplinaDTOMapper>();


            return services;
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DefaultContext>(options => 
                options
                .UseLazyLoadingProxies()
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Sistema Prefeitura API", Version = "v1" });
                options.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Scheme = "bearer"
                });
                options.OperationFilter<AuthenticationRequirementsOperationFilter>();
            });

            return services;
        }

        public static IServiceCollection AddOauthProvider(this IServiceCollection services, Auth0Configurations configurations)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = configurations.Authority;
                options.Audience = configurations.Audience;
            });

            return services;
        }
    }
}
