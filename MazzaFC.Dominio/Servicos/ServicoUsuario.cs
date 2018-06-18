using MazzaFC.Dominio.Entidades;
using MazzaFC.Dominio.Interfaces.Repositorios;
using MazzaFC.Dominio.Interfaces.Servicos;
using MazzaFC.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazzaFC.Dominio.Servicos
{
    public class ServicoUsuario : ServicoBase<Usuario>, IServicoUsuario
    {
        #region Variáveis privadas somente leitura
        private readonly IRepositorioUsuario _repositorioUsuario;
        #endregion


        public ServicoUsuario(IRepositorioUsuario repositorioUsuario)
            : base(repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public UsuarioDTO ObterAutenticacao(string email, string senha)
        {
            return _repositorioUsuario.ObterAutenticacao(email, senha);
        }

        public UsuarioDTO ObterPorId(Guid id)
        {
            return _repositorioUsuario.ObterPorId(id);
        }

        public List<UsuarioDTO> Listar()
        {
            return _repositorioUsuario.Listar();
        }
    }
}
