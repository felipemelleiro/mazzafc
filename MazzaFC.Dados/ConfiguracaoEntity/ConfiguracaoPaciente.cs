using MazzaFC.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazzaFC.Infraestrutura.Dados.ConfiguracaoEntity
{
    public class ConfiguracaoPaciente : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.ToTable("Paciente");

            builder.Property(c => c.PacientePlanoSaude)
                .HasColumnType("varchar(500)");
        }
    }
}
