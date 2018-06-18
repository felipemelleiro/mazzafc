using MazzaFC.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazzaFC.Infraestrutura.Dados.ConfiguracaoEntity
{
    public class ConfiguracaoAgendamento : IEntityTypeConfiguration<Agendamento>
    {
        public void Configure(EntityTypeBuilder<Agendamento> builder)
        {
            builder.ToTable("Agendamento");

            builder.HasKey(c => c.AgendamentoId);

            builder.HasOne(c => c.Paciente)
                .WithMany(c => c.Agendamentos)
                .HasForeignKey(fk => fk.PacienteId);

            builder.HasOne(c => c.Medico)
                .WithMany(c => c.Agendamentos)
                .HasForeignKey(fk => fk.MedicoId);

            builder.Property(c => c.AgendamentoDataHora);

            builder.Property(c => c.AgendamentoComentario)
                .HasColumnType("varchar(2000)");
        }
    }
}
