using MazzaFC.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazzaFC.Dominio.Interfaces.Aplicacoes
{
    public interface IServicoDeAplicacaoPessoa : IServicoDeAplicacaoBase<Pessoa>
    {
        Guid Salvar(String pessoadocumento, String pessoanome, Nullable<DateTime> pessoadatanascimento, String pessoarg);
    }
}
