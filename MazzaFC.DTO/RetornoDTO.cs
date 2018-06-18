using System;
using System.Collections.Generic;
using System.Text;

namespace MazzaFC.DTO
{
    public class RetornoDTO
    {
        /// <summary>
        /// Construtor da entidade Recurso
        /// </summary>
        public RetornoDTO()
        {
        }

        /// <summary>
        /// Construtor da entidade Recurso
        /// </summary>
        public RetornoDTO(Nullable<Guid> idref, String chave, Boolean erro, String mensagem)
        {
            this.IdRef = idref;
            this.Chave = chave;
            this.Erro = erro;
            this.Mensagem = mensagem;
        }

        /*********************************************************************************************************/

        /// <summary>
        /// Código de referência
        /// </summary>
        public Nullable<Guid> IdRef { get; protected set; }

        /// <summary>
        /// Identificador generico
        /// </summary>
        public String Chave { get; protected set; }

        /// <summary>
        /// flag para saber se é erro ou sucesso
        /// </summary>
        public Boolean Erro { get; protected set; }

        /// <summary>
        /// Mensagem
        /// </summary>
        public String Mensagem { get; protected set; }


        /***************************** METODOS *************************************/


        public void Sucesso(string mensagem, Nullable<Guid> idref = null)
        {
            this.IdRef = idref;
            this.Chave = "";
            this.Erro = false;
            this.Mensagem = mensagem;
        }

        public void Error(string mensagem, Nullable<Guid> idref = null)
        {
            this.IdRef = idref;
            this.Chave = "";
            this.Erro = true;
            this.Mensagem = mensagem;
        }
    }
}
