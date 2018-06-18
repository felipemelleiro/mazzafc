using MazzaFC.Dominio.Interfaces.Especificacoes;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MazzaFC.Dominio.Especificacoes
{
    public abstract class EspecificacaoBase<TEntity> : IEspecificacao<TEntity>
    {
        public abstract Expression<Func<TEntity, bool>> Atende();
    }
}
