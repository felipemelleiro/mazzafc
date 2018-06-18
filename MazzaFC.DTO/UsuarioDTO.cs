using System;
using System.Collections.Generic;
using System.Text;

namespace MazzaFC.DTO
{
    public class UsuarioDTO
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

        /// <summary>
        /// Token de autenticação
        /// </summary>
        public String Token { get; set; }
    }
}
