using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MazzaFC.Dominio.Especificacoes.Agendamento
{
    public class EspecificacaoNExcluido : EspecificacaoBase<MazzaFC.Dominio.Entidades.Agendamento>
    {
        public EspecificacaoNExcluido()
        {

        }


        public override Expression<Func<MazzaFC.Dominio.Entidades.Agendamento, bool>> Atende()
        {
            return a => a.Excluido == false;
        }
    }
}
