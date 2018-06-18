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
    public class ServicoDeAplicacaoUsuario : ServicoDeAplicacaoBase<Usuario>, IServicoDeAplicacaoUsuario
    {
        private readonly IServicoUsuario _servicoUsuario;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="servicoUsuario">Serviço Usuario, deve ser passado via Injection</param>
        /// <param name="unidadeDeTrabalho">Unidade de trabalho, deve ser passado via Injection</param>
        public ServicoDeAplicacaoUsuario(IServicoUsuario servicoUsuario, IUnidadeDeTrabalho unidadeDeTrabalho)
            : base(servicoUsuario, unidadeDeTrabalho)
        {
            _servicoUsuario = servicoUsuario;
        }


        public UsuarioDTO ObterAutenticacao(string email, string senha)
        {
            return _servicoUsuario.ObterAutenticacao(email, senha);
        }

        public UsuarioDTO ObterPorId(Guid id)
        {
            return _servicoUsuario.ObterPorId(id);
        }

        public List<UsuarioDTO> Listar()
        {
            return _servicoUsuario.Listar();
        }
    }
}
