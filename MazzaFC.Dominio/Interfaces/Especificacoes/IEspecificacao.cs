using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MazzaFC.Dominio.Interfaces.Especificacoes
{
    /// <summary>
    /// Interface base das especificações
    /// </summary>
    /// <typeparam name="TEntity">Entidade que será utilizada na montagem da especificação.</typeparam>
    public interface IEspecificacao<TEntity>
    {
        /// <summary>
        /// Método que monta a expressão para consulta.
        /// </summary>
        /// <returns>Expression<Func<TEntity, bool>></returns>
        Expression<Func<TEntity, bool>> Atende();
    }
}
