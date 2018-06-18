using MazzaFC.Dominio.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MazzaFC.Dominio.Entidades
{
    public class Medico
    {
        /// <summary>
        /// Construtor da entidade Medico
        /// </summary>
        public Medico()
        {
            this.MedicoId = Guid.NewGuid();
        }

        /*********************************************************************************************************/

        /// <summary>
        /// Identificador do medico
        /// </summary>
        public Guid MedicoId { get; set; }

        /// <summary>
        /// Identificador da pessoa
        /// </summary>
        public Guid PessoaId { get; protected set; }

        /// <summary>
        /// Especialidade do medico
        /// </summary>
        public String MedicoEspecialidade { get; protected set; }

        /// <summary>
        /// CRM do medico
        /// </summary>
        public String MedicoCRM { get; protected set; }

        /***************************** LOG *****************************/

        /// <summary>
        /// Status de registro excluído
        /// </summary>
        public Boolean Excluido { get; protected set; }

        /***************************** VIRTUAL *************************************/

        /// <summary>
        /// Pessoa
        /// </summary>
        public virtual Pessoa Pessoa { get; protected set; }

        /// <summary>
        /// Agendamentos
        /// </summary>
        public virtual List<Agendamento> Agendamentos { get; protected set; }

        /***************************** METODOS *************************************/

        /// <summary>
        /// Método para salvar
        /// </summary>
        public void Salvar(Guid pessoaid, String medicoespecialidade, String medicocrm)
        {
            this.PessoaId = pessoaid;
            this.MedicoEspecialidade = medicoespecialidade;
            this.MedicoCRM = medicocrm;
            this.Excluido = false;
        }

        /// <summary>
        /// Método para excluir
        /// </summary>
        public void Excluir()
        {
            this.Excluido = true;
        }

        /// <summary>
        /// Valida as propriedades da entidade
        /// </summary>
        public void ValidarEntidade()
        {
            var regrasException = new RegrasException<Medico>();

            // se algum erro foi adicionado à lista de erros, dispara exceção
            if (regrasException.Erros.Any())
                throw regrasException;
        }
    }
}
