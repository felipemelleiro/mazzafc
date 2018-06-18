using System;
using System.Collections.Generic;
using System.Text;

namespace MazzaFC.Dominio.Interfaces.Aplicacoes
{
    public interface IServicoDeAplicacaoBase<TEntity> where TEntity : class
    {
        /// <summary>
        /// Adiciona uma entidade genérica.
        /// </summary>
        /// <param name="obj">Entidade</param>
        void Adicionar(TEntity obj);

        /// <summary>
        /// Edita uma entidade genérica.
        /// </summary>
        /// <param name="obj">Entidade</param>
        void Editar(TEntity obj);
        /// <summary>
        /// Obtém uma entidade genérica pelo seu ID
        /// </summary>
        /// <param name="obj">Id</param>
        /// <returns>Entidade.</returns>
        TEntity ObterPorID(Guid obj);
        /// <summary>
        /// Obtém uma lista de entidade genérica.
        /// </summary>
        /// <returns>Lista de entidade.</returns>
        IEnumerable<TEntity> Listar();
        /// <summary>
        /// Dispose.
        /// </summary>
        void Dispose();
    }
}
