using System;
using System.Collections.Generic;
using System.Text;

namespace MazzaFC.DTO
{
    public class AgendamentoDTO
    {
        /// <summary>
        /// Identificador do agendamento
        /// </summary>
        public Guid AgendamentoId { get; set; }

        /// <summary>
        /// Data / Hora do agendamento
        /// </summary>
        public DateTime AgendamentoDataHora { get; set; }

        /// <summary>
        /// Comentário do agendamento
        /// </summary>
        public String AgendamentoComentario { get; set; }

        public PacienteDTO Paciente { get; set; }

        public MedicoDTO Medico { get; set; }
    }
}
