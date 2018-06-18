using MazzaFC.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazzaFC.Infraestrutura.Dados.ConfiguracaoEntity
{
    public class ConfiguracaoMedico : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder.ToTable("Medico");

            builder.Property(c => c.MedicoEspecialidade)
                .HasColumnType("varchar(250)");

            builder.Property(c => c.MedicoCRM)
                .HasColumnType("varchar(50)");
        }
    }
}
