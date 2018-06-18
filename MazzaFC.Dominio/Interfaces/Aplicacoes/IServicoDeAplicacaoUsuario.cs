using MazzaFC.Dominio.Entidades;
using MazzaFC.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazzaFC.Dominio.Interfaces.Aplicacoes
{
    public interface IServicoDeAplicacaoUsuario : IServicoDeAplicacaoBase<Usuario>
    {
        UsuarioDTO ObterAutenticacao(string email, string senha);

        UsuarioDTO ObterPorId(Guid id);

        List<UsuarioDTO> Listar();
    }
}
