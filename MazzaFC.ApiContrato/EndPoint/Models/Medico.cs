using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazzaFC.APIContrato.EndPoint.Models
{
    public class Medico
    {
        /// <summary>
        /// Identificador do medico
        /// </summary>
        public Nullable<Guid> MedicoId { get; set; }

        /// <summary>
        /// Especialidade do medico
        /// </summary>
        public String MedicoEspecialidade { get; set; }

        /// <summary>
        /// CRM do medico
        /// </summary>
        public String MedicoCRM { get; set; }


        public Pessoa Pessoa { get; set; }
    }
}
