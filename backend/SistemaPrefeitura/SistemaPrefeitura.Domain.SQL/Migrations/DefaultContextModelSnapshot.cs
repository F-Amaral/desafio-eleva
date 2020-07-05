﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaPrefeitura.Domain.SQL.DataContext;

namespace SistemaPrefeitura.Domain.SQL.Migrations
{
    [DbContext(typeof(DefaultContext))]
    partial class DefaultContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SistemaPrefeitura.Domain.Models.Aluno", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EscolaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TurmaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EscolaId");

                    b.HasIndex("TurmaId");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("SistemaPrefeitura.Domain.Models.Disciplina", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EscolaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProfessorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EscolaId");

                    b.ToTable("Disciplinas");
                });

            modelBuilder.Entity("SistemaPrefeitura.Domain.Models.Escola", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Escolas");
                });

            modelBuilder.Entity("SistemaPrefeitura.Domain.Models.Professor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EscolaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EscolaId");

                    b.ToTable("Professores");
                });

            modelBuilder.Entity("SistemaPrefeitura.Domain.Models.Turma", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Ano")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("EscolaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EscolaId");

                    b.ToTable("Turmas");
                });

            modelBuilder.Entity("SistemaPrefeitura.Domain.Models.TurmaDisciplina", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DisciplinaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TurmaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DisciplinaId");

                    b.HasIndex("TurmaId");

                    b.ToTable("TurmasDisciplinas");
                });

            modelBuilder.Entity("SistemaPrefeitura.Domain.Models.Aluno", b =>
                {
                    b.HasOne("SistemaPrefeitura.Domain.Models.Escola", null)
                        .WithMany("Alunos")
                        .HasForeignKey("EscolaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaPrefeitura.Domain.Models.Turma", null)
                        .WithMany("Alunos")
                        .HasForeignKey("TurmaId");
                });

            modelBuilder.Entity("SistemaPrefeitura.Domain.Models.Disciplina", b =>
                {
                    b.HasOne("SistemaPrefeitura.Domain.Models.Escola", null)
                        .WithMany("Disciplinas")
                        .HasForeignKey("EscolaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SistemaPrefeitura.Domain.Models.Professor", b =>
                {
                    b.HasOne("SistemaPrefeitura.Domain.Models.Escola", null)
                        .WithMany("Professores")
                        .HasForeignKey("EscolaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SistemaPrefeitura.Domain.Models.Turma", b =>
                {
                    b.HasOne("SistemaPrefeitura.Domain.Models.Escola", null)
                        .WithMany("Turmas")
                        .HasForeignKey("EscolaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SistemaPrefeitura.Domain.Models.TurmaDisciplina", b =>
                {
                    b.HasOne("SistemaPrefeitura.Domain.Models.Disciplina", "Disciplina")
                        .WithMany("TurmasDisciplinas")
                        .HasForeignKey("DisciplinaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SistemaPrefeitura.Domain.Models.Turma", "Turma")
                        .WithMany("TurmasDisciplinas")
                        .HasForeignKey("TurmaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
