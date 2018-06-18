using MazzaFC.Dominio.Entidades;
using MazzaFC.Infraestrutura.Dados.ConfiguracaoEntity;
using Microsoft.EntityFrameworkCore;

namespace MazzaFC.Infraestrutura.Dados
{
    public class Contexto : DbContext
    {

        /// <summary>
        /// Construtor
        /// </summary>
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        #region .: Coleções :.

        public DbSet<Pessoa> Pessoa { get; set; }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Medico> Medico { get; set; }

        public DbSet<Paciente> Paciente { get; set; }

        public DbSet<Agendamento> Agendamento { get; set; }

        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            #region :: Configuracao ::

            modelBuilder.ApplyConfiguration(new ConfiguracaoPessoa());
            modelBuilder.ApplyConfiguration(new ConfiguracaoUsuario());
            modelBuilder.ApplyConfiguration(new ConfiguracaoMedico());
            modelBuilder.ApplyConfiguration(new ConfiguracaoPaciente());
            modelBuilder.ApplyConfiguration(new ConfiguracaoAgendamento());

            #endregion

            #region :: Seed ::

            //modelBuilder.Entity<Usuario>().HasData(
            //    new Usuario("admin", "123456", "admin@teste.com.br")
            //);

            #endregion
        }

    }
}
