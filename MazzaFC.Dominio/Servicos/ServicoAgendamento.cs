using MazzaFC.Dominio.Entidades;
using MazzaFC.Dominio.Interfaces.Repositorios;
using MazzaFC.Dominio.Interfaces.Servicos;
using MazzaFC.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazzaFC.Dominio.Servicos
{
    public class ServicoAgendamento : ServicoBase<Agendamento>, IServicoAgendamento
    {
        #region Variáveis privadas somente leitura
        private readonly IRepositorioAgendamento _repositorioAgendamento;
        #endregion


        public ServicoAgendamento(IRepositorioAgendamento repositorioAgendamento)
            : base(repositorioAgendamento)
        {
            _repositorioAgendamento = repositorioAgendamento;
        }

        public List<AgendamentoDTO> Listar()
        {
            return _repositorioAgendamento.Listar();
        }

        public AgendamentoDTO ObterPorId(Guid id)
        {
            return _repositorioAgendamento.ObterPorId(id);
        }
    }
}
