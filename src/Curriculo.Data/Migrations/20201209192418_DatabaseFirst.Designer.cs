﻿// <auto-generated />
using System;
using Curriculo.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Curriculo.Data.Migrations
{
    [DbContext(typeof(MeuDbContext))]
    [Migration("20201209192418_DatabaseFirst")]
    partial class DatabaseFirst
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Curriculo.Business.Models.Experiencia", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AnosExperiencia")
                        .HasColumnType("int");

                    b.Property<string>("DetalheExperiencia")
                        .HasColumnType("VARCHAR(500)");

                    b.Property<Guid>("PessoaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Tecnologia")
                        .HasColumnType("VARCHAR(80)");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId");

                    b.ToTable("Experiencias");
                });

            modelBuilder.Entity("Curriculo.Business.Models.ExperienciaTrabalho", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cargo")
                        .HasColumnType("VARCHAR(80)");

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("DetalheExperiencia")
                        .HasColumnType("VARCHAR(1000)");

                    b.Property<string>("Empresa")
                        .HasColumnType("VARCHAR(80)");

                    b.Property<Guid>("PessoaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId");

                    b.ToTable("ExperienciasTrabalho");
                });

            modelBuilder.Entity("Curriculo.Business.Models.Formacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Curso")
                        .HasColumnType("VARCHAR(60)");

                    b.Property<DateTime>("DataConclusao")
                        .HasColumnType("Date");

                    b.Property<Guid>("PessoaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId");

                    b.ToTable("Formacoes");
                });

            modelBuilder.Entity("Curriculo.Business.Models.Pessoa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AnosExperienciaTotal")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("Date");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(80)");

                    b.HasKey("Id");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("Curriculo.Business.Models.Experiencia", b =>
                {
                    b.HasOne("Curriculo.Business.Models.Pessoa", "Pessoa")
                        .WithMany("Experiencia")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("Curriculo.Business.Models.ExperienciaTrabalho", b =>
                {
                    b.HasOne("Curriculo.Business.Models.Pessoa", "Pessoa")
                        .WithMany("ExperienciaTrabalho")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("Curriculo.Business.Models.Formacao", b =>
                {
                    b.HasOne("Curriculo.Business.Models.Pessoa", "Pessoa")
                        .WithMany("Formacao")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("Curriculo.Business.Models.Pessoa", b =>
                {
                    b.Navigation("Experiencia");

                    b.Navigation("ExperienciaTrabalho");

                    b.Navigation("Formacao");
                });
#pragma warning restore 612, 618
        }
    }
}
