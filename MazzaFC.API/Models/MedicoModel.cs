using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MazzaFC.API.Models
{
    public class MedicoModel
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

        /// <summary>
        /// Model Pessoa
        /// </summary>
        public PessoaModel Pessoa { get; set; }
    }
}
