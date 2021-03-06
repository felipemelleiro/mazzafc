﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MazzaFC.API.Models
{
    public class UsuarioModel
    {
        /// <summary>
        /// Identificador do usuário
        /// </summary>
        public Nullable<Guid> UsuarioId { get; set; }

        /// <summary>
        /// Nome do usuário
        /// </summary>
        public String UsuarioNome { get; set; }

        /// <summary>
        /// Senha
        /// </summary>
        public String UsuarioSenha { get; set; }

        /// <summary>
        /// E-mail usado para acesso
        /// </summary>
        public String UsuarioEmail { get; set; }
    }
}
