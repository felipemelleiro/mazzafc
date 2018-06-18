using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazzaFC.APIContrato.EndPoint.Models
{
    public class AgendamentoForm
    {
        /// <summary>
        /// Identificador do agendamento
        /// </summary>
        public Nullable<Guid> AgendamentoId { get; set; }

        /// <summary>
        /// Identificador do paciente
        /// </summary>
        public Guid PacienteId { get; set; }

        /// <summary>
        /// Identificador do medico
        /// </summary>
        public Guid MedicoId { get; set; }

        /// <summary>
        /// Data / Hora do agendamento
        /// </summary>
        public DateTime AgendamentoDataHora { get; set; }

        /// <summary>
        /// Comentário do agendamento
        /// </summary>
        public String AgendamentoComentario { get; set; }
    }
}
