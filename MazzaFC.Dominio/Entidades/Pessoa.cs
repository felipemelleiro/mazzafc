using MazzaFC.Dominio.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MazzaFC.Dominio.Entidades
{
    public class Pessoa
    {
        /// <summary>
        /// Construtor da entidade Pessoa
        /// </summary>
        public Pessoa()
        {
            this.PessoaId = Guid.NewGuid();
        }

        /*********************************************************************************************************/

        /// <summary>
        /// Identificador da pessoa
        /// </summary>
        public Guid PessoaId { get; set; }


        /// <summary>
        /// Documento (CPF) da pessoa
        /// </summary>
        public String PessoaDocumento { get; protected set; }


        /// <summary>
        /// Nome da pessoa
        /// </summary>
        public String PessoaNome { get; protected set; }

        /// <summary>
        /// Data de Nascimento da pessoa
        /// </summary>
        public Nullable<DateTime> PessoaDataNascimento { get; protected set; }

        /// <summary>
        /// RG da pessoa
        /// </summary>
        public String PessoaRG { get; protected set; }


        /***************************** VIRTUAL *************************************/

        public virtual Medico Medico { get; protected set; }

        public virtual Paciente Paciente { get; protected set; }

        /***************************** METODOS *************************************/

        /// <summary>
        /// Método para salvar
        /// </summary>
        public void Salvar(String pessoadocumento, String pessoanome, Nullable<DateTime> pessoadatanascimento, String pessoarg)
        {
            this.PessoaDocumento = pessoadocumento.FormatarCPF();
            this.PessoaNome = pessoanome;
            this.PessoaDataNascimento = pessoadatanascimento;
            this.PessoaRG = pessoarg;
        }

        /// <summary>
        /// Valida as propriedades da entidade
        /// </summary>
        public void ValidarEntidade()
        {
            var regrasException = new RegrasException<Pessoa>();

            // se algum erro foi adicionado à lista de erros, dispara exceção
            if (regrasException.Erros.Any())
                throw regrasException;
        }
    }
}
