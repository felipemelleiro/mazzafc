using MazzaFC.Dominio.Entidades;
using MazzaFC.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazzaFC.Dominio.Interfaces.Aplicacoes
{
    public interface IServicoDeAplicacaoPaciente : IServicoDeAplicacaoBase<Paciente>
    {
        List<PacienteDTO> Listar();

        PacienteDTO ObterPorId(Guid id);
    }
}
