using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MazzaFC.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MazzaFC.API.Controllers
{
    [ApiController]
    public class ControllerCustomController : ControllerBase
    {
        public TokenModel tokenUser = null;

        protected string GerarModelParaToken(TokenModel model)
        {
            try
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(model);

                var token = MazzaFCCrypt.Criptografar(json);

                return token;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro ao gerar token. [{0}]", ex.Message));
            }
        }

        protected void GerarTokenParaModel(IHeaderDictionary headers)
        {
            try
            {
                var token = Request.Headers["token"];

                if (String.IsNullOrEmpty(token))
                {
                    throw new Exception(string.Format("{0}", "Token inválido"));
                }

                GerarTokenParaModel(token);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro no token. [{0}]", ex.Message));
            }
        }

        protected void GerarTokenParaModel(string token)
        {
            try
            {
                var contexto = MazzaFCCrypt.Descriptografar(token);
                this.tokenUser = Newtonsoft.Json.JsonConvert.DeserializeObject<TokenModel>(contexto);

                TokenValidarAcesso();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}", ex.Message));
            }
        }

        protected void TokenValidarAcesso()
        {
            if (this.tokenUser == null)
            {
                throw new Exception(string.Format("{0}", "Token inválido!"));
            }


        }
    }
}