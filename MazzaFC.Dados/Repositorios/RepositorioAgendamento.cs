using MazzaFC.Dominio.Entidades;
using MazzaFC.Dominio.Especificacoes.Agendamento;
using MazzaFC.Dominio.Interfaces.Repositorios;
using MazzaFC.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MazzaFC.Infraestrutura.Dados.Repositorios
{
    public class RepositorioAgendamento : RepositorioBase<Agendamento>, IRepositorioAgendamento
    {
        public RepositorioAgendamento(Contexto db)
            : base(db)
        {
            Db = db;
        }

        public List<AgendamentoDTO> Listar()
        {
            var filtro = new EspecificacaoNExcluido();
            var query = Db.Agendamento
                .Include(lazy => lazy.Medico)
                .Include(lazy => lazy.Medico.Pessoa)
                .Include(lazy => lazy.Paciente)
                .Include(lazy => lazy.Paciente.Pessoa)
                .Where(filtro.Atende());

            var retorno = (from model in query
                           select new AgendamentoDTO()
                           {
                               AgendamentoId = model.AgendamentoId,
                               AgendamentoDataHora = model.AgendamentoDataHora,
                               AgendamentoComentario = model.AgendamentoComentario,
                               
                               Paciente = new PacienteDTO()
                               {
                                   PacienteId = model.PacienteId,
                                   PacientePlanoSaude = model.Paciente.PacientePlanoSaude,
                                   Pessoa = new PessoaDTO()
                                   {
                                       PessoaId = model.Paciente.Pessoa.PessoaId,
                                       PessoaDocumento = model.Paciente.Pessoa.PessoaDocumento,
                                       PessoaNome = model.Paciente.Pessoa.PessoaNome
                                   }
                               },
                               Medico = new MedicoDTO()
                               {
                                   MedicoId = model.MedicoId,
                                   MedicoCRM = model.Medico.MedicoCRM,
                                   MedicoEspecialidade = model.Medico.MedicoEspecialidade,
                                   Pessoa = new PessoaDTO()
                                   {
                                       PessoaId = model.Medico.Pessoa.PessoaId,
                                       PessoaDocumento = model.Medico.Pessoa.PessoaDocumento,
                                       PessoaNome = model.Medico.Pessoa.PessoaNome
                                   }
                               }

                           }).ToList();

            return retorno;
        }

        public AgendamentoDTO ObterPorId(Guid id)
        {
            var filtro = new EspecificacaoNExcluido();
            var query = Db.Agendamento
                .Include(lazy => lazy.Medico)
                .Include(lazy => lazy.Medico.Pessoa)
                .Include(lazy => lazy.Paciente)
                .Include(lazy => lazy.Paciente.Pessoa)
                .Where(w => w.AgendamentoId == id);

            query = query.Where(filtro.Atende());

            var retorno = (from model in query
                           select new AgendamentoDTO()
                           {
                               AgendamentoId = model.AgendamentoId,
                               AgendamentoDataHora = model.AgendamentoDataHora,
                               AgendamentoComentario = model.AgendamentoComentario,
                               Paciente = new PacienteDTO()
                               {
                                   Pessoa = new PessoaDTO()
                                   {
                                       PessoaId = model.Paciente.Pessoa.PessoaId,
                                       PessoaDocumento = model.Paciente.Pessoa.PessoaDocumento,
                                       PessoaNome = model.Paciente.Pessoa.PessoaNome
                                   }
                               },
                               Medico = new MedicoDTO()
                               {
                                   Pessoa = new PessoaDTO()
                                   {
                                       PessoaId = model.Medico.Pessoa.PessoaId,
                                       PessoaDocumento = model.Medico.Pessoa.PessoaDocumento,
                                       PessoaNome = model.Medico.Pessoa.PessoaNome
                                   }
                               }

                           }).FirstOrDefault();

            return retorno;
        }
    }
}
