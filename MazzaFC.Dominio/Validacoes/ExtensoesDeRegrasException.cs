using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazzaFC.Dominio.Validacoes
{
    public static class ExtensoesDeRegrasException
    {
        public static void CopiarErrosPara(this RegrasException ex, ModelStateDictionary modelState, string prefixo = null)
        {
            prefixo = string.IsNullOrWhiteSpace(prefixo) ? "" : prefixo + ".";

            foreach (var erro in ex.Erros)
            {
                var propriedade = ExpressionHelper.GetExpressionText(erro.Propriedade);
                var chave = string.IsNullOrWhiteSpace(propriedade) ? "" : prefixo + propriedade;
                modelState.AddModelError(chave, erro.Mensagem);
            }
        }
    }
}
