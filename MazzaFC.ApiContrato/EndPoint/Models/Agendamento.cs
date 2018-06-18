using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazzaFC.APIContrato.EndPoint.Models
{
    public class Agendamento
    {
        /// <summary>
        /// Identificador do agendamento
        /// </summary>
        public Nullable<Guid> AgendamentoId { get; set; }

        /// <summary>
        /// Data / Hora do agendamento
        /// </summary>
        public DateTime AgendamentoDataHora { get; set; }
        public String AgendamentoDataHoraText { get { return this.AgendamentoDataHora != DateTime.MinValue ? this.AgendamentoDataHora.ToString("dd/MM/yyyy") : ""; } }

        /// <summary>
        /// Comentário do agendamento
        /// </summary>
        public String AgendamentoComentario { get; set; }

        public Paciente Paciente { get; set; }

        public Medico Medico { get; set; }
    }
}
