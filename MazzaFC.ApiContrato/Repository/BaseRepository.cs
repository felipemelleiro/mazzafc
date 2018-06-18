using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazzaFC.APIContrato.Repository
{
    public abstract class BaseRepository
    {
        public string ApiUrl { get; set; }

        public string ApiToken { get; set; }

        public string RoutePrefix { get; set; }

        protected BaseRepository(string apitoken)
        {
            this.ApiUrl = ConfigurationManager.AppSettings["UrlApi"];
            this.ApiToken = apitoken;
        }


        public string ExceptionRetorno(Exception ex)
        {
            string retorno = "Não foi possível detalhar o erro!";

            if (ex != null)
            {
                try
                {
                    var _erro = Newtonsoft.Json.JsonConvert.DeserializeObject<EndPoint.Models.Retorno>(ex.Message);
                    retorno = _erro.Mensagem;
                }
                catch
                {
                    if (ex.InnerException != null)
                    {
                        retorno = ex.InnerException.Message;
                    }
                    else
                    {
                        retorno = ex.Message;
                    }
                }
            }

            return retorno;
        }
    }
}
