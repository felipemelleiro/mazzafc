using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MazzaFC.Dominio.Especificacoes.Usuario
{
    public class EspecificacaoNExcluido : EspecificacaoBase<MazzaFC.Dominio.Entidades.Usuario>
    {
        public EspecificacaoNExcluido()
        {

        }


        public override Expression<Func<MazzaFC.Dominio.Entidades.Usuario, bool>> Atende()
        {
            return a => a.Excluido == false;
        }
    }
}
