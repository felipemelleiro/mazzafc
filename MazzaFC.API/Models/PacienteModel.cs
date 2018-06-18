using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MazzaFC.API.Models
{
    public class PacienteModel
    {
        /// <summary>
        /// Identificador do paciente
        /// </summary>
        public Guid PacienteId { get; set; }

        /// <summary>
        /// Plano de saúde do paciente
        /// </summary>
        public String PacientePlanoSaude { get; set; }

        /// <summary>
        /// Model Pessoa
        /// </summary>
        public PessoaModel Pessoa { get; set; }
        
    }
}
