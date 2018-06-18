using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazzaFC.APIContrato.EndPoint.Models
{
    public class Retorno
    {
        /// <summary>
        /// Identificador generico
        /// </summary>
        public String Chave { get; set; }

        /// <summary>
        /// flag para saber se é erro ou sucesso
        /// </summary>
        public Boolean Erro { get; set; }

        /// <summary>
        /// Mensagem
        /// </summary>
        public String Mensagem { get; set; }

        /// <summary>
        /// Código de referência
        /// </summary>
        public Nullable<Guid> IdRef { get; set; }
    }
}
