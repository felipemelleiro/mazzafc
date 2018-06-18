using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazzaFC.APIContrato.EndPoint.Models
{
    public class Pessoa
    {
        /// <summary>
        /// Identificador da pessoa
        /// </summary>
        public Guid PessoaId { get; set; }


        /// <summary>
        /// Documento (CPF) da pessoa
        /// </summary>
        public String PessoaDocumento { get; set; }


        /// <summary>
        /// Nome da pessoa
        /// </summary>
        public String PessoaNome { get; set; }

        /// <summary>
        /// Data de Nascimento da pessoa
        /// </summary>
        public Nullable<DateTime> PessoaDataNascimento { get; set; }

        /// <summary>
        /// RG da pessoa
        /// </summary>
        public String PessoaRG { get; set; }
    }
}
