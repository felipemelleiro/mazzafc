using MazzaFC.Dominio.Interfaces.Aplicacoes;
using MazzaFC.Dominio.Interfaces.Servicos;
using MazzaFC.Dominio.Interfaces.UnidadeDeTrabalho;
using MazzaFC.Infraestrutura.Dados.UnidadeDeTrabalho;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazzaFC.Aplicacao
{
    /// <summary>
    /// Implementação do serviço de aplicação BASE
    /// </summary>
    /// <typeparam name="TEntity">Entidade</typeparam>
    public class ServicoDeAplicacaoBase<TEntity> : IDisposable, IServicoDeAplicacaoBase<TEntity> where TEntity : class
    {
        #region Variáveis privadas somente leitura
        private readonly IServicoBase<TEntity> _servicoBase;
        private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;
        #endregion
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="servicoBase">Serviço Base</param>
        /// <param name="unidadeDeTrabalho">Unidade de Trabalho</param>
        public ServicoDeAplicacaoBase(IServicoBase<TEntity> servicoBase, IUnidadeDeTrabalho unidadeDeTrabalho)
        {
            _servicoBase = servicoBase;
            _unidadeDeTrabalho = unidadeDeTrabalho;
        }
        /// <summary>
        /// Adiciona uma entidade genérica.
        /// </summary>
        /// <param name="obj">Entidade</param>
        public void Adicionar(TEntity obj)
        {
            _servicoBase.Adicionar(obj);
            _unidadeDeTrabalho.Commit();
        }

        /// <summary>
        /// Edita uma entidade genérica.
        /// </summary>
        /// <param name="obj">Entidade</param>
        public void Editar(TEntity obj)
        {
            _servicoBase.Editar(obj);
            _unidadeDeTrabalho.Commit();
        }
        /// <summary>
        /// Obtém uma entidade genérica pelo seu ID
        /// </summary>
        /// <param name="obj">Id</param>
        /// <returns>Entidade.</returns>
        public TEntity ObterPorID(Guid obj)
        {
            return _servicoBase.ObterPorID(obj);
        }
        /// <summary>
        /// Obtém uma lista de entidade genérica.
        /// </summary>
        /// <returns>Lista de entidade.</returns>
        public IEnumerable<TEntity> Listar()
        {
            return _servicoBase.Listar();
        }
        /// <summary>
        /// Dispose.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            _unidadeDeTrabalho.Dispose();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources
                if (_unidadeDeTrabalho != null)
                {
                    _unidadeDeTrabalho.Dispose();
                }
            }
        }
    }
}
