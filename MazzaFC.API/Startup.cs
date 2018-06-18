using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using MazzaFC.Infraestrutura.Dados;
using MazzaFC.Aplicacao;
using MazzaFC.Dominio.Interfaces.Aplicacoes;
using MazzaFC.Dominio.Interfaces.Servicos;
using MazzaFC.Dominio.Servicos;
using MazzaFC.Dominio.Interfaces.Repositorios;
using MazzaFC.Infraestrutura.Dados.Repositorios;
using MazzaFC.Dominio.Interfaces.UnidadeDeTrabalho;
using MazzaFC.Infraestrutura.Dados.UnidadeDeTrabalho;

namespace MazzaFC.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Contexto>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MazzaFCConn"))
            );

            services.AddScoped<IUnidadeDeTrabalho, UnidadeDeTrabalho>();

            services.AddScoped<IServicoDeAplicacaoPessoa, ServicoDeAplicacaoPessoa>();
            services.AddScoped<IServicoPessoa, ServicoPessoa>();
            services.AddScoped<IRepositorioPessoa, RepositorioPessoa>();

            services.AddScoped<IServicoDeAplicacaoUsuario, ServicoDeAplicacaoUsuario>();
            services.AddScoped<IServicoUsuario, ServicoUsuario>();
            services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();

            services.AddScoped<IServicoDeAplicacaoPaciente, ServicoDeAplicacaoPaciente>();
            services.AddScoped<IServicoPaciente, ServicoPaciente>();
            services.AddScoped<IRepositorioPaciente, RepositorioPaciente>();

            services.AddScoped<IServicoDeAplicacaoMedico, ServicoDeAplicacaoMedico>();
            services.AddScoped<IServicoMedico, ServicoMedico>();
            services.AddScoped<IRepositorioMedico, RepositorioMedico>();

            services.AddScoped<IServicoDeAplicacaoAgendamento, ServicoDeAplicacaoAgendamento>();
            services.AddScoped<IServicoAgendamento, ServicoAgendamento>();
            services.AddScoped<IRepositorioAgendamento, RepositorioAgendamento>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
