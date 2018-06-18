using System;
using System.Collections.Generic;
using System.Text;

namespace MazzaFC.DTO
{
    public class PacienteDTO
    {
        /// <summary>
        /// Identificador do paciente
        /// </summary>
        public Guid PacienteId { get; set; }

        /// <summary>
        /// Plano de saúde do paciente
        /// </summary>
        public String PacientePlanoSaude { get; set; }


        public PessoaDTO Pessoa { get; set; }
    }
}
