using MazzaFC.Dominio.Entidades;
using MazzaFC.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazzaFC.Dominio.Interfaces.Aplicacoes
{
    public interface IServicoDeAplicacaoAgendamento : IServicoDeAplicacaoBase<Agendamento>
    {
        List<AgendamentoDTO> Listar();

        AgendamentoDTO ObterPorId(Guid id);
    }
}
