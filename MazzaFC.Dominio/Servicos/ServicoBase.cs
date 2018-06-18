using MazzaFC.Dominio.Interfaces.Repositorios;
using MazzaFC.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MazzaFC.Dominio.Servicos
{
    public class ServicoBase<TEntity> : IServicoBase<TEntity> where TEntity : class
    {
        private readonly IRepositorioBase<TEntity> _repositorio;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="repositorio">Repositório Base, deve ser passado via Injection</param>
        public ServicoBase(IRepositorioBase<TEntity> repositorio)
        {
            _repositorio = repositorio;
        }
        /// <summary>
        /// Adiciona uma entidade no banco de dados.
        /// </summary>
        /// <param name="obj">Entidade</param>
        public void Adicionar(TEntity obj)
        {
            _repositorio.Adicionar(obj);
        }

        /// <summary>
        /// Edita uma entidade no banco de dados
        /// </summary>
        /// <param name="obj">Entidade</param>
        public void Editar(TEntity obj)
        {
            _repositorio.Editar(obj);
        }
        /// <summary>
        /// Obtém uma entidade pelo seu ID
        /// </summary>
        /// <param name="obj">Entidade</param>
        /// <returns></returns>
        public TEntity ObterPorID(Guid obj)
        {
            return _repositorio.ObterPorID(obj);
        }
        /// <summary>
        /// Listar entidades
        /// </summary>
        /// <returns>Lista de entidade</returns>
        public IQueryable<TEntity> Listar()
        {
            return _repositorio.Listar();
        }

        /// <summary>
        /// Listar entidades
        /// </summary>
        /// <param name="where">Argumento para pesquisa.</param>
        /// <returns>Lista de entidade</returns>
        public IQueryable<TEntity> Listar(Expression<Func<TEntity, bool>> where)
        {
            return _repositorio.Listar(where);
        }

        /// <summary>
        /// Obtém uma entidade
        /// </summary>
        /// <param name="exp">Argumento para pesquisa.</param>
        /// <returns></returns>
        public TEntity Obter(Expression<Func<TEntity, bool>> exp)
        {
            return _repositorio.Obter(exp);
        }


        public void Detached(TEntity obj)
        {
            _repositorio.Detached(obj);
        }
    }
}
