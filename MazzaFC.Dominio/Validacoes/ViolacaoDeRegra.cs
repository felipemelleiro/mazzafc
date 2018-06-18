using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MazzaFC.Dominio.Validacoes
{
    public class ViolacaoDeRegra
    {
        public LambdaExpression Propriedade { get; internal set; }
        public string Mensagem { get; internal set; }
    }
}
