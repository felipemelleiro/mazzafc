using MazzaFC.Dominio.Entidades;
using MazzaFC.Dominio.Interfaces.Aplicacoes;
using MazzaFC.Dominio.Interfaces.Servicos;
using MazzaFC.Dominio.Interfaces.UnidadeDeTrabalho;
using MazzaFC.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazzaFC.Aplicacao
{
    public class ServicoDeAplicacaoAgendamento : ServicoDeAplicacaoBase<Agendamento>, IServicoDeAplicacaoAgendamento
    {
        private readonly IServicoAgendamento _servicoAgendamento;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="servicoAgendamento">Serviço Agendamento, deve ser passado via Injection</param>
        /// <param name="unidadeDeTrabalho">Unidade de trabalho, deve ser passado via Injection</param>
        public ServicoDeAplicacaoAgendamento(IServicoAgendamento servicoAgendamento, IUnidadeDeTrabalho unidadeDeTrabalho)
            : base(servicoAgendamento, unidadeDeTrabalho)
        {
            _servicoAgendamento = servicoAgendamento;
        }

        public List<AgendamentoDTO> Listar()
        {
            return _servicoAgendamento.Listar();
        }

        public AgendamentoDTO ObterPorId(Guid id)
        {
            return _servicoAgendamento.ObterPorId(id);
        }
    }
}
