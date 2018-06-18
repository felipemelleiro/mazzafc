using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazzaFC.APIContrato.Repository
{
    public class UsuarioRepository : BaseRepository
    {
        public UsuarioRepository(string apiToken) : base(apiToken) { base.RoutePrefix = "api/usuario/"; }

        public EndPoint.BaseEndPoint<List<EndPoint.Models.Usuario>> Listar()
        {
            try
            {
                var apiRequest = new Utils.ApiRequest(System.IO.Path.Combine(this.ApiUrl, base.RoutePrefix, "listar"), this.ApiToken);
                var respostaApi = apiRequest.Get(null, null);
                var resultados = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EndPoint.Models.Usuario>>(respostaApi);

                return new EndPoint.BaseEndPoint<List<EndPoint.Models.Usuario>>()
                {
                    Erro = false,
                    Mensagem = "OK",
                    Excecao = null,
                    ObjRetorno = resultados
                };
            }
            catch (Exception ex)
            {
                return new EndPoint.BaseEndPoint<List<EndPoint.Models.Usuario>>()
                {
                    Erro = true,
                    Mensagem = ExceptionRetorno(ex),
                    Excecao = ex
                };
            }
        }

        public EndPoint.BaseEndPoint<EndPoint.Models.Usuario> ObterPorId(Guid id)
        {
            try
            {
                var data = new System.Collections.Specialized.NameValueCollection();
                data.Add("id", id.ToString());

                var apiRequest = new Utils.ApiRequest(System.IO.Path.Combine(this.ApiUrl, base.RoutePrefix, "obterporid"), this.ApiToken);
                var respostaApi = apiRequest.GetQueryString(null, data);
                var resultados = Newtonsoft.Json.JsonConvert.DeserializeObject<EndPoint.Models.Usuario>(respostaApi);

                return new EndPoint.BaseEndPoint<EndPoint.Models.Usuario>()
                {
                    Erro = false,
                    Mensagem = "OK",
                    Excecao = null,
                    ObjRetorno = resultados
                };
            }
            catch (Exception ex)
            {
                return new EndPoint.BaseEndPoint<EndPoint.Models.Usuario>()
                {
                    Erro = true,
                    Mensagem = ExceptionRetorno(ex),
                    Excecao = ex
                };
            }
        }

        public EndPoint.BaseEndPoint<EndPoint.Models.Retorno> Adicionar(EndPoint.Models.UsuarioForm model)
        {
            try
            {
                var apiRequest = new Utils.ApiRequest(System.IO.Path.Combine(this.ApiUrl, base.RoutePrefix, "adicionar"), this.ApiToken);
                var respostaApi = apiRequest.Post(null, model);
                var resultado = Newtonsoft.Json.JsonConvert.DeserializeObject<EndPoint.Models.Retorno>(respostaApi);

                return new EndPoint.BaseEndPoint<EndPoint.Models.Retorno>()
                {
                    Erro = resultado.Erro,
                    Mensagem = resultado.Mensagem,
                    Excecao = null,
                    ObjRetorno = resultado
                };
            }
            catch (Exception ex)
            {
                return new EndPoint.BaseEndPoint<EndPoint.Models.Retorno>()
                {
                    Erro = true,
                    Mensagem = ExceptionRetorno(ex),
                    Excecao = ex
                };
            }
        }

        public EndPoint.BaseEndPoint<EndPoint.Models.Retorno> Editar(EndPoint.Models.UsuarioForm model)
        {
            try
            {
                var apiRequest = new Utils.ApiRequest(System.IO.Path.Combine(this.ApiUrl, base.RoutePrefix, "editar"), this.ApiToken);
                var respostaApi = apiRequest.Post(null, model);
                var resultado = Newtonsoft.Json.JsonConvert.DeserializeObject<EndPoint.Models.Retorno>(respostaApi);

                return new EndPoint.BaseEndPoint<EndPoint.Models.Retorno>()
                {
                    Erro = resultado.Erro,
                    Mensagem = resultado.Mensagem,
                    Excecao = null,
                    ObjRetorno = resultado
                };
            }
            catch (Exception ex)
            {
                return new EndPoint.BaseEndPoint<EndPoint.Models.Retorno>()
                {
                    Erro = true,
                    Mensagem = ExceptionRetorno(ex),
                    Excecao = ex
                };
            }
        }

        public EndPoint.BaseEndPoint<EndPoint.Models.Retorno> Excluir(EndPoint.Models.UsuarioForm model)
        {
            try
            {
                var apiRequest = new Utils.ApiRequest(System.IO.Path.Combine(this.ApiUrl, base.RoutePrefix, "excluir"), this.ApiToken);
                var respostaApi = apiRequest.Post(null, model);
                var resultado = Newtonsoft.Json.JsonConvert.DeserializeObject<EndPoint.Models.Retorno>(respostaApi);

                return new EndPoint.BaseEndPoint<EndPoint.Models.Retorno>()
                {
                    Erro = resultado.Erro,
                    Mensagem = resultado.Mensagem,
                    Excecao = null,
                    ObjRetorno = resultado
                };
            }
            catch (Exception ex)
            {
                return new EndPoint.BaseEndPoint<EndPoint.Models.Retorno>()
                {
                    Erro = true,
                    Mensagem = ExceptionRetorno(ex),
                    Excecao = ex
                };
            }
        }
    }
}
