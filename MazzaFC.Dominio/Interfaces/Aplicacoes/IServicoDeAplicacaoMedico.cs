using MazzaFC.Dominio.Entidades;
using MazzaFC.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazzaFC.Dominio.Interfaces.Aplicacoes
{
    public interface IServicoDeAplicacaoMedico : IServicoDeAplicacaoBase<Medico>
    {
        List<MedicoDTO> Listar();

        MedicoDTO ObterPorId(Guid id);
    }
}
