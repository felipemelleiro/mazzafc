using MazzaFC.Dominio.Interfaces.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MazzaFC.Infraestrutura.Dados.Repositorios
{
    public class RepositorioBase<TEntity> : IRepositorioBase<TEntity> where TEntity : class
    {
        private Contexto _db;
        public Contexto Db
        {
            get { return _db; }
            set { _db = value; }
        }
        public RepositorioBase(Contexto db)
        {
            Db = db;
        }

        public void Adicionar(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
        }

        //public void Excluir(TEntity obj)
        //{
        //    if (Db.Entry(obj).State == EntityState.Detached)
        //    {
        //        Db.Set<TEntity>().Attach(obj);
        //    }


        //    Db.Set<TEntity>().Remove(obj);
        //    Db.Entry(obj).State = EntityState.Deleted;
        //}

        public void Editar(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
        }

        public void Detached(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Detached;
        }

        public TEntity ObterPorID(Guid obj)
        {
            return Db.Set<TEntity>().Find(obj);
        }

        //public TEntity ObterPorCodigoId(int id)
        //{
        //    return Db.Set<TEntity>().Find(id);
        //}

        public IQueryable<TEntity> Listar()
        {
            return Db.Set<TEntity>().AsQueryable();
        }

        public IQueryable<TEntity> Listar(Expression<Func<TEntity, bool>> where)
        {
            return Listar().Where(where);
        }

        public TEntity Obter(Expression<Func<TEntity, bool>> exp)
        {
            return Listar().FirstOrDefault(exp);
        }
    }
}
