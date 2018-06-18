using MazzaFC.Dominio.Entidades;
using MazzaFC.Dominio.Interfaces.Repositorios;
using MazzaFC.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazzaFC.Dominio.Servicos
{
    public class ServicoPessoa : ServicoBase<Pessoa>, IServicoPessoa
    {
        #region Variáveis privadas somente leitura
        private readonly IRepositorioPessoa _repositorioPessoa;
        #endregion


        public ServicoPessoa(IRepositorioPessoa repositorioPessoa)
            : base(repositorioPessoa)
        {
            _repositorioPessoa = repositorioPessoa;
        }

    }
}
