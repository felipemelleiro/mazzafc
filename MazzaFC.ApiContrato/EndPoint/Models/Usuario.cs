using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazzaFC.APIContrato.EndPoint.Models
{
    public class Usuario
    {
        /// <summary>
        /// Identificador do usuário
        /// </summary>
        public Guid UsuarioId { get; set; }

        /// <summary>
        /// Nome do usuário
        /// </summary>
        public String UsuarioNome { get; set; }

        /// <summary>
        /// E-mail usado para acesso
        /// </summary>
        public String UsuarioEmail { get; set; }

        /// <summary>
        /// Senha
        /// </summary>
        public String UsuarioSenha { get; set; }
    }
}
