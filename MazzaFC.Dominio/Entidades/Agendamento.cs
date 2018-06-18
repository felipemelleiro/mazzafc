using MazzaFC.Dominio.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MazzaFC.Dominio.Entidades
{
    public class Agendamento
    {
        /// <summary>
        /// Construtor da entidade Agendamento
        /// </summary>
        public Agendamento()
        {
            this.AgendamentoId = Guid.NewGuid();
        }

        /*********************************************************************************************************/

        /// <summary>
        /// Identificador do agendamento
        /// </summary>
        public Guid AgendamentoId { get; set; }

        /// <summary>
        /// Identificador do paciente
        /// </summary>
        public Guid PacienteId { get; protected set; }

        /// <summary>
        /// Identificador do medico
        /// </summary>
        public Guid MedicoId { get; protected set; }

        /// <summary>
        /// Data / Hora do agendamento
        /// </summary>
        public DateTime AgendamentoDataHora { get; protected set; }

        /// <summary>
        /// Comentário do agendamento
        /// </summary>
        public String AgendamentoComentario { get; protected set; }

        /***************************** LOG *****************************/

        /// <summary>
        /// Status de registro excluído
        /// </summary>
        public Boolean Excluido { get; protected set; }

        /***************************** VIRTUAL *************************************/

        /// <summary>
        /// Medico
        /// </summary>
        public virtual Medico Medico { get; protected set; }

        /// <summary>
        /// Paciente
        /// </summary>
        public virtual Paciente Paciente { get; protected set; }

        /***************************** METODOS *************************************/

        /// <summary>
        /// Método para salvar
        /// </summary>
        public void Salvar(Guid pacienteid, Guid medicoid, DateTime agendamentodatahora, String agendamentocomentario)
        {
            this.PacienteId = pacienteid;
            this.MedicoId = medicoid;
            this.AgendamentoDataHora = agendamentodatahora;
            this.AgendamentoComentario = agendamentocomentario;
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
            var regrasException = new RegrasException<Agendamento>();

            // se algum erro foi adicionado à lista de erros, dispara exceção
            if (regrasException.Erros.Any())
                throw regrasException;
        }
    }
}
