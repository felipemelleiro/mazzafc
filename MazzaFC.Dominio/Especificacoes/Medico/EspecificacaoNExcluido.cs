using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MazzaFC.Dominio.Especificacoes.Medico
{
    public class EspecificacaoNExcluido : EspecificacaoBase<MazzaFC.Dominio.Entidades.Medico>
    {
        public EspecificacaoNExcluido()
        {

        }


        public override Expression<Func<MazzaFC.Dominio.Entidades.Medico, bool>> Atende()
        {
            return a => a.Excluido == false;
        }
    }
}
