using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazzaFC.APIContrato.Repository
{
    public class AutenticacaoRepository : BaseRepository
    {
        public AutenticacaoRepository(string apiToken) : base(apiToken) { }

        public EndPoint.BaseEndPoint<EndPoint.Models.UsuarioAutenticado> ObterAutenticacao(string email, string senha)
        {
            try
            {
                var apiEvent = "api/usuario/obterautenticacao";
                var apiRequest = new Utils.ApiRequest(System.IO.Path.Combine(this.ApiUrl, apiEvent), null);
                var respostaApi = apiRequest.Post(null, new { email = email, senha = senha });
                var resultados = Newtonsoft.Json.JsonConvert.DeserializeObject<EndPoint.Models.UsuarioAutenticado>(respostaApi);

                return new EndPoint.BaseEndPoint<EndPoint.Models.UsuarioAutenticado>()
                {
                    Erro = false,
                    Mensagem = "OK",
                    Excecao = null,
                    ObjRetorno = resultados
                };
            }
            catch (Exception ex)
            {
                return new EndPoint.BaseEndPoint<EndPoint.Models.UsuarioAutenticado>()
                {
                    Erro = true,
                    Mensagem = ExceptionRetorno(ex),
                    Excecao = ex
                };
            }
        }

    }
}
