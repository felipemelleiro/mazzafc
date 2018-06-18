using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazzaFC.APIContrato.EndPoint.Models
{
    public class Paciente
    {
        /// <summary>
        /// Identificador do paciente
        /// </summary>
        public Guid PacienteId { get; set; }

        /// <summary>
        /// Plano de saúde do paciente
        /// </summary>
        public String PacientePlanoSaude { get; set; }


        public Pessoa Pessoa { get; set; }
    }
}
