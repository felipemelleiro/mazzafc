using MazzaFC.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazzaFC.Infraestrutura.Dados.ConfiguracaoEntity
{
    public class ConfiguracaoPessoa : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("Pessoa");

            builder.HasKey(c => c.PessoaId);

            builder.Property(c => c.PessoaDocumento)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(c => c.PessoaNome)
                .HasColumnType("varchar(1000)")
                .IsRequired();

            builder.Property(c => c.PessoaDataNascimento);

            builder.Property(c => c.PessoaRG)
                .HasColumnType("varchar(250)");

            builder.HasOne(c => c.Medico)
                .WithOne(c => c.Pessoa)
                .HasForeignKey<Medico>(fk => fk.PessoaId);

            builder.HasOne(c => c.Paciente)
                .WithOne(c => c.Pessoa)
                .HasForeignKey<Paciente>(fk => fk.PessoaId);
        }
    }
}
