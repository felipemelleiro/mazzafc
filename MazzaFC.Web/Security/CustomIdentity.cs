using MazzaFC.Web.Security.Interfaces;
using MazzaFC.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;

namespace MazzaFC.Web.Security
{
    public class CustomIdentity : ICustomIdentity
    {
        /// <summary>
        /// Authenticate and get identity out with roles
        /// </summary>
        /// <param name="userName">User name</param>
        /// <param name="password">Password</param>
        /// <returns>Instance of identity</returns>
        public static CustomIdentity GetCustomIdentity(string email, string senha)
        {
            //Criptografia appCriptografia = new Criptografia();
            //password = appCriptografia.getMd5Hash(password);

            CustomIdentity identity = new CustomIdentity();

            var autenticacaoRespository = new APIContrato.Repository.AutenticacaoRepository(null);
            var autenticacaoResultado = autenticacaoRespository.ObterAutenticacao(email, senha);

            if (autenticacaoResultado.Erro)
            {
                identity.MensagemLogin = autenticacaoResultado.Mensagem;
            }
            else
            {
                identity.IsAuthenticated = true;
                identity.UsuarioId = autenticacaoResultado.ObjRetorno.UsuarioId;
                identity.Name = autenticacaoResultado.ObjRetorno.UsuarioNome;
                identity.Token = autenticacaoResultado.ObjRetorno.Token;

                List<string> roles = new List<string>();
                identity.Roles = roles.ToArray();
            }

            return identity;
        }

        private CustomIdentity() { }

        public string AuthenticationType
        {
            get { return "Custom"; }
        }

        public bool IsAuthenticated { get; private set; }

        public string MensagemLogin { get; private set; }

        public Guid UsuarioId { get; private set; }

        public string Name { get; private set; }

        public string Token { get; private set; }

        private string[] Roles { get; set; }

        public bool IsInRole(string role)
        {
            if (string.IsNullOrEmpty(role))
            {
                throw new ArgumentException("Role is null");
            }
            return Roles.Where(one => one.ToUpper().Trim() == role.ToUpper().Trim()).Any();
        }

        /// <summary>
        /// Create serialized string for storing in a cookie
        /// </summary>
        /// <returns>String representation of identity</returns>
        public string ToJson()
        {
            string returnValue = string.Empty;
            IdentityRepresentationViewModel representation = new IdentityRepresentationViewModel()
            {
                IsAuthenticated = this.IsAuthenticated,
                MensagemLogin = this.MensagemLogin,
                UsuarioId = this.UsuarioId,
                Name = this.Name,
                Roles = string.Join("|", this.Roles),
                Token = this.Token
            };

            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(IdentityRepresentationViewModel));
            using (MemoryStream stream = new MemoryStream())
            {
                jsonSerializer.WriteObject(stream, representation);
                stream.Flush();
                byte[] json = stream.ToArray();
                returnValue = Encoding.UTF8.GetString(json, 0, json.Length);
            }

            return returnValue;
        }

        /// <summary>
        /// Create identity from a cookie data
        /// </summary>
        /// <param name="cookieString">String stored in cookie, created via ToJson method</param>
        /// <returns>Instance of identity</returns>
        public static ICustomIdentity FromJson(string cookieString)
        {
            if (!string.IsNullOrEmpty(cookieString))
            {
                IdentityRepresentationViewModel serializedIdentity = null;
                using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(cookieString)))
                {
                    DataContractJsonSerializer jsonSerializer =
                        new DataContractJsonSerializer(typeof(IdentityRepresentationViewModel));
                    serializedIdentity = jsonSerializer.ReadObject(stream) as IdentityRepresentationViewModel;
                }
                CustomIdentity identity = new CustomIdentity()
                {
                    IsAuthenticated = serializedIdentity.IsAuthenticated,
                    MensagemLogin = serializedIdentity.MensagemLogin,
                    Name = serializedIdentity.Name,
                    Roles = serializedIdentity.Roles.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries),
                    Token = serializedIdentity.Token
                };


                return identity;
            }

            return new CustomIdentity();
        }

    }
}