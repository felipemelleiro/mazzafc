using MazzaFC.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazzaFC.Infraestrutura.Dados.ConfiguracaoEntity
{
    public class ConfiguracaoUsuario : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(c => c.UsuarioId);

            builder.Property(c => c.UsuarioNome)
                .HasColumnType("varchar(200)");

            builder.Property(c => c.UsuarioSenha)
                .HasColumnType("varchar(30)");

            builder.Property(c => c.UsuarioEmail)
                .HasColumnType("varchar(200)");
        }
    }
}
