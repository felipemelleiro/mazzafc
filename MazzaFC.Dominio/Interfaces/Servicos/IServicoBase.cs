using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MazzaFC.Dominio.Interfaces.Servicos
{
    public interface IServicoBase<TEntity> where TEntity : class
    {
        /// <summary>
        /// Adiciona a entidade
        /// </summary>
        /// <param name="obj">Entidade</param>
        void Adicionar(TEntity obj);
        /// <summary>
        /// Exclui a entidade
        /// </summary>
        /// <param name="obj">Entidade</param>
        //void Excluir(TEntity obj);
        /// <summary>
        /// Edita a entidade
        /// </summary>
        /// <param name="obj">Entidade</param>
        void Editar(TEntity obj);
        /// <summary>
        /// Obtém a entidade por Id
        /// </summary>
        /// <param name="obj">Id</param>
        /// <returns></returns>
        TEntity ObterPorID(Guid obj);
        /// <summary>
        /// Retorna uma lista de entidades
        /// </summary>
        /// <returns>IEnumerable<TEntity></returns>
        IQueryable<TEntity> Listar();

        IQueryable<TEntity> Listar(Expression<Func<TEntity, bool>> where);

        TEntity Obter(Expression<Func<TEntity, bool>> exp);

        //TEntity ObterPorCodigoId(int id);

        void Detached(TEntity obj);
    }
}
