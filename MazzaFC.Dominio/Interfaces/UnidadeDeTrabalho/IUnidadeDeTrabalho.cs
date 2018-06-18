using System;
using System.Collections.Generic;
using System.Text;

namespace MazzaFC.Dominio.Interfaces.UnidadeDeTrabalho
{
    public interface IUnidadeDeTrabalho
    {
        /// <summary>
        /// Efetua o commit da transação.
        /// </summary>
        void Commit();
        /// <summary>
        /// Dispose.
        /// </summary>
        void Dispose();
    }
}
