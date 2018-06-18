using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazzaFC.APIContrato.Repository
{
    public class AgendamentoRepository : BaseRepository
    {
        public AgendamentoRepository(string apiToken) : base(apiToken) { base.RoutePrefix = "api/agendamento/"; }

        public EndPoint.BaseEndPoint<List<EndPoint.Models.Agendamento>> Listar()
        {
            try
            {
                var apiRequest = new Utils.ApiRequest(System.IO.Path.Combine(this.ApiUrl, base.RoutePrefix, "listar"), this.ApiToken);
                var respostaApi = apiRequest.Get(null, null);
                var resultados = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EndPoint.Models.Agendamento>>(respostaApi);

                return new EndPoint.BaseEndPoint<List<EndPoint.Models.Agendamento>>()
                {
                    Erro = false,
                    Mensagem = "OK",
                    Excecao = null,
                    ObjRetorno = resultados
                };
            }
            catch (Exception ex)
            {
                return new EndPoint.BaseEndPoint<List<EndPoint.Models.Agendamento>>()
                {
                    Erro = true,
                    Mensagem = ExceptionRetorno(ex),
                    Excecao = ex
                };
            }
        }

        public EndPoint.BaseEndPoint<EndPoint.Models.Agendamento> ObterPorId(Guid id)
        {
            try
            {
                var data = new System.Collections.Specialized.NameValueCollection();
                data.Add("id", id.ToString());

                var apiRequest = new Utils.ApiRequest(System.IO.Path.Combine(this.ApiUrl, base.RoutePrefix, "obterporid"), this.ApiToken);
                var respostaApi = apiRequest.GetQueryString(null, data);
                var resultados = Newtonsoft.Json.JsonConvert.DeserializeObject<EndPoint.Models.Agendamento>(respostaApi);

                return new EndPoint.BaseEndPoint<EndPoint.Models.Agendamento>()
                {
                    Erro = false,
                    Mensagem = "OK",
                    Excecao = null,
                    ObjRetorno = resultados
                };
            }
            catch (Exception ex)
            {
                return new EndPoint.BaseEndPoint<EndPoint.Models.Agendamento>()
                {
                    Erro = true,
                    Mensagem = ExceptionRetorno(ex),
                    Excecao = ex
                };
            }
        }

        public EndPoint.BaseEndPoint<EndPoint.Models.Retorno> Adicionar(EndPoint.Models.AgendamentoForm model)
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

        public EndPoint.BaseEndPoint<EndPoint.Models.Retorno> Editar(EndPoint.Models.AgendamentoForm model)
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

        public EndPoint.BaseEndPoint<EndPoint.Models.Retorno> Excluir(EndPoint.Models.Agendamento model)
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
