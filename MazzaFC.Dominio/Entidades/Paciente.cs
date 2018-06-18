using MazzaFC.Dominio.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MazzaFC.Dominio.Entidades
{
    public class Paciente
    {
        /// <summary>
        /// Construtor da entidade Paciente
        /// </summary>
        public Paciente()
        {
            this.PacienteId = Guid.NewGuid();
        }

        /*********************************************************************************************************/

        /// <summary>
        /// Identificador do paciente
        /// </summary>
        public Guid PacienteId { get; set; }

        /// <summary>
        /// Identificador da pessoa
        /// </summary>
        public Guid PessoaId { get; protected set; }

        /// <summary>
        /// Plano de saúde do paciente
        /// </summary>
        public String PacientePlanoSaude { get; protected set; }

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
        public void Salvar(Guid pessoaid, String pacienteplanosaude)
        {
            this.PessoaId = pessoaid;
            this.PacientePlanoSaude = pacienteplanosaude;
        }

        /// <summary>
        /// Valida as propriedades da entidade
        /// </summary>
        public void ValidarEntidade()
        {
            var regrasException = new RegrasException<Paciente>();

            // se algum erro foi adicionado à lista de erros, dispara exceção
            if (regrasException.Erros.Any())
                throw regrasException;
        }
    }
}
