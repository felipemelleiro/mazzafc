﻿// <auto-generated />
using System;
using MazzaFC.Infraestrutura.Dados;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MazzaFC.Infraestrutura.Dados.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20180616225950_mazzafc")]
    partial class mazzafc
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MazzaFC.Dominio.Entidades.Agendamento", b =>
                {
                    b.Property<Guid>("AgendamentoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AgendamentoComentario");

                    b.Property<DateTime>("AgendamentoDataHora");

                    b.Property<bool>("Excluido");

                    b.Property<Guid>("MedicoId");

                    b.Property<Guid>("PacienteId");

                    b.HasKey("AgendamentoId");

                    b.HasIndex("MedicoId");

                    b.HasIndex("PacienteId");

                    b.ToTable("Agendamento");
                });

            modelBuilder.Entity("MazzaFC.Dominio.Entidades.Medico", b =>
                {
                    b.Property<Guid>("MedicoId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Excluido");

                    b.Property<string>("MedicoCRM")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("MedicoEspecialidade")
                        .HasColumnType("varchar(250)");

                    b.Property<Guid>("PessoaId");

                    b.HasKey("MedicoId");

                    b.HasIndex("PessoaId")
                        .IsUnique();

                    b.ToTable("Medico");
                });

            modelBuilder.Entity("MazzaFC.Dominio.Entidades.Paciente", b =>
                {
                    b.Property<Guid>("PacienteId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PacientePlanoSaude")
                        .HasColumnType("varchar(500)");

                    b.Property<Guid>("PessoaId");

                    b.HasKey("PacienteId");

                    b.HasIndex("PessoaId")
                        .IsUnique();

                    b.ToTable("Paciente");
                });

            modelBuilder.Entity("MazzaFC.Dominio.Entidades.Pessoa", b =>
                {
                    b.Property<Guid>("PessoaId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("PessoaDataNascimento");

                    b.Property<string>("PessoaDocumento")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PessoaNome")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("PessoaRG")
                        .HasColumnType("varchar(250)");

                    b.HasKey("PessoaId");

                    b.ToTable("Pessoa");
                });

            modelBuilder.Entity("MazzaFC.Dominio.Entidades.Usuario", b =>
                {
                    b.Property<Guid>("UsuarioId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Excluido");

                    b.Property<string>("UsuarioEmail")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("UsuarioNome")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("UsuarioSenha")
                        .HasColumnType("varchar(30)");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("MazzaFC.Dominio.Entidades.Agendamento", b =>
                {
                    b.HasOne("MazzaFC.Dominio.Entidades.Medico", "Medico")
                        .WithMany("Agendamentos")
                        .HasForeignKey("MedicoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MazzaFC.Dominio.Entidades.Paciente", "Paciente")
                        .WithMany("Agendamentos")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MazzaFC.Dominio.Entidades.Medico", b =>
                {
                    b.HasOne("MazzaFC.Dominio.Entidades.Pessoa", "Pessoa")
                        .WithOne("Medico")
                        .HasForeignKey("MazzaFC.Dominio.Entidades.Medico", "PessoaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MazzaFC.Dominio.Entidades.Paciente", b =>
                {
                    b.HasOne("MazzaFC.Dominio.Entidades.Pessoa", "Pessoa")
                        .WithOne("Paciente")
                        .HasForeignKey("MazzaFC.Dominio.Entidades.Paciente", "PessoaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
