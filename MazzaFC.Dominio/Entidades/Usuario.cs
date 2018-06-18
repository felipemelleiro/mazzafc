using MazzaFC.Dominio.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MazzaFC.Dominio.Entidades
{
    public class Usuario
    {
        /// <summary>
        /// Construtor da entidade Usuario
        /// </summary>
        public Usuario()
        {
            this.UsuarioId = Guid.NewGuid();
        }

        //public Usuario(String usuarionome, String usuariosenha, String usuarioemail)
        //{
        //    this.UsuarioId = Guid.NewGuid();
        //    this.UsuarioNome = usuarionome;
        //    this.UsuarioSenha = usuariosenha;
        //    this.UsuarioEmail = usuarioemail;
        //    this.Excluido = false;
        //}

        /*********************************************************************************************************/

        /// <summary>
        /// Identificador do usuário
        /// </summary>
        public Guid UsuarioId { get; set; }

        /// <summary>
        /// Nome do usuário
        /// </summary>
        public String UsuarioNome { get; protected set; }

        /// <summary>
        /// Senha
        /// </summary>
        public String UsuarioSenha { get; protected set; }

        /// <summary>
        /// E-mail usado para acesso
        /// </summary>
        public String UsuarioEmail { get; protected set; }

        /***************************** LOG *****************************/

        /// <summary>
        /// Status de registro excluído
        /// </summary>
        public Boolean Excluido { get; protected set; }

        /***************************** METODOS *************************************/

        /// <summary>
        /// Método para salvar
        /// </summary>
        public void Salvar(String usuarionome, String usuariosenha, String usuarioemail)
        {
            this.UsuarioNome = usuarionome;
            this.UsuarioSenha = usuariosenha;
            this.UsuarioEmail = usuarioemail;
            this.Excluido = false;
        }

        /// <summary>
        /// Método para excluir
        /// </summary>
        public void Excluir()
        {
            this.Excluido = true;
        }

        /// <summary>
        /// Valida as propriedades da entidade
        /// </summary>
        public void ValidarEntidade()
        {
            var regrasException = new RegrasException<Usuario>();

            // se algum erro foi adicionado à lista de erros, dispara exceção
            if (regrasException.Erros.Any())
                throw regrasException;
        }
    }
}
