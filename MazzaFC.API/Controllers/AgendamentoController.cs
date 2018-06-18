using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MazzaFC.API.Models;
using MazzaFC.Dominio.Interfaces.Aplicacoes;
using MazzaFC.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MazzaFC.API.Controllers
{
    [Route("api/agendamento")]
    [ApiController]
    public class AgendamentoController : ControllerCustomController
    {
        private readonly IServicoDeAplicacaoAgendamento _servicoDeAplicacaoAgendamento;

        public AgendamentoController(IServicoDeAplicacaoAgendamento servicoDeAplicacaoAgendamento)
        {
            _servicoDeAplicacaoAgendamento = servicoDeAplicacaoAgendamento;
        }

        [AcceptVerbs("GET")]
        [Route("listar")]
        public async Task<IActionResult> Listar()
        {
            try
            {
                GerarTokenParaModel(Request.Headers);

                var lista = _servicoDeAplicacaoAgendamento.Listar();

                return Ok(lista);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [AcceptVerbs("GET")]
        [Route("obterporid")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                GerarTokenParaModel(Request.Headers);

                var model = _servicoDeAplicacaoAgendamento.ObterPorId(id);

                if (model == null)
                {
                    return BadRequest("ID inválido!");
                }

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [AcceptVerbs("POST")]
        [Route("adicionar")]
        public async Task<IActionResult> Adicionar(AgendamentoModel model)
        {
            RetornoDTO iRetorno = new RetornoDTO();

            try
            {
                GerarTokenParaModel(Request.Headers);

                if (model == null)
                {
                    return BadRequest(MazzaFC.Dominio.Resources.Global._ModelInvalido);
                }

                var _model = new MazzaFC.Dominio.Entidades.Agendamento();
                _model.Salvar(model.PacienteId, model.MedicoId, model.AgendamentoDataHora, model.AgendamentoComentario);
                _model.ValidarEntidade();

                _servicoDeAplicacaoAgendamento.Adicionar(_model);

                iRetorno.Sucesso(MazzaFC.Dominio.Resources.Global._OperacaoSucesso, _model.MedicoId);
                return Ok(iRetorno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [AcceptVerbs("POST")]
        [Route("editar")]
        public async Task<IActionResult> Editar(AgendamentoModel model)
        {
            RetornoDTO iRetorno = new RetornoDTO();

            try
            {
                GerarTokenParaModel(Request.Headers);

                var _model = _servicoDeAplicacaoAgendamento.ObterPorID(model.AgendamentoId.GetValueOrDefault());
                if (_model == null)
                {
                    return BadRequest(MazzaFC.Dominio.Resources.Global._ModelInvalido);
                }

                _model.Salvar(model.PacienteId, model.MedicoId, model.AgendamentoDataHora, model.AgendamentoComentario);
                _model.ValidarEntidade();

                _servicoDeAplicacaoAgendamento.Editar(_model);

                iRetorno.Sucesso(MazzaFC.Dominio.Resources.Global._OperacaoSucesso, _model.MedicoId);
                return Ok(iRetorno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [AcceptVerbs("POST")]
        [Route("excluir")]
        public async Task<IActionResult> Excluir(AgendamentoModel model)
        {
            RetornoDTO iRetorno = new RetornoDTO();

            try
            {
                GerarTokenParaModel(Request.Headers);

                var _model = _servicoDeAplicacaoAgendamento.ObterPorID(model.AgendamentoId.GetValueOrDefault());
                if (_model == null)
                {
                    return BadRequest(MazzaFC.Dominio.Resources.Global._ModelInvalido);
                }

                _model.Excluir();
                _servicoDeAplicacaoAgendamento.Editar(_model);

                iRetorno.Sucesso(MazzaFC.Dominio.Resources.Global._OperacaoSucesso, _model.MedicoId);
                return Ok(iRetorno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}