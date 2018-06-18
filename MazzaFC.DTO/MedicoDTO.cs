using System;
using System.Collections.Generic;
using System.Text;

namespace MazzaFC.DTO
{
    public class MedicoDTO
    {
        /// <summary>
        /// Identificador do medico
        /// </summary>
        public Guid MedicoId { get; set; }

        /// <summary>
        /// Especialidade do medico
        /// </summary>
        public String MedicoEspecialidade { get; set; }

        /// <summary>
        /// CRM do medico
        /// </summary>
        public String MedicoCRM { get; set; }


        public PessoaDTO Pessoa { get; set; }
    }
}
