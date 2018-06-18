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
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerCustomController
    {
        private readonly IServicoDeAplicacaoUsuario _servicoDeAplicacaoUsuario;

        public UsuarioController(IServicoDeAplicacaoUsuario servicoDeAplicacaoUsuario)
        {
            _servicoDeAplicacaoUsuario = servicoDeAplicacaoUsuario;
        }

        [AcceptVerbs("GET")]
        [Route("listar")]
        public async Task<IActionResult> Listar()
        {
            try
            {
                GerarTokenParaModel(Request.Headers);

                var lista = _servicoDeAplicacaoUsuario.Listar();

                return Ok(lista);

            }
            catch(Exception ex)
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

                var model = _servicoDeAplicacaoUsuario.ObterPorId(id);

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
        [Route("obterautenticacao")]
        public async Task<IActionResult> ObterAutenticacao(AutenticacaoModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var autenticacao = _servicoDeAplicacaoUsuario.ObterAutenticacao(model.Email, model.Senha);

            if (autenticacao == null)
            {
                return BadRequest("Autenticação inválida!");
            }

            autenticacao.Token = GerarModelParaToken(new TokenModel()
            {
                UsuarioEmail = autenticacao.UsuarioEmail,
                UsuarioId = autenticacao.UsuarioId
            });

            return Ok(autenticacao);
        }

        [AcceptVerbs("POST")]
        [Route("adicionar")]
        public async Task<IActionResult> Adicionar(UsuarioModel model)
        {
            RetornoDTO iRetorno = new RetornoDTO();

            try
            {
                GerarTokenParaModel(Request.Headers);

                if (model == null)
                {
                    return BadRequest(MazzaFC.Dominio.Resources.Global._ModelInvalido);
                }

                var _model = new MazzaFC.Dominio.Entidades.Usuario();
                _model.Salvar(model.UsuarioNome, model.UsuarioSenha, model.UsuarioEmail);
                _model.ValidarEntidade();

                _servicoDeAplicacaoUsuario.Adicionar(_model);

                iRetorno.Sucesso(MazzaFC.Dominio.Resources.Global._OperacaoSucesso, _model.UsuarioId);
                return Ok(iRetorno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [AcceptVerbs("POST")]
        [Route("editar")]
        public async Task<IActionResult> Editar(UsuarioModel model)
        {
            RetornoDTO iRetorno = new RetornoDTO();

            try
            {
                GerarTokenParaModel(Request.Headers);

                var _model = _servicoDeAplicacaoUsuario.ObterPorID(model.UsuarioId.GetValueOrDefault());
                if (_model == null)
                {
                    return BadRequest(MazzaFC.Dominio.Resources.Global._ModelInvalido);
                }

                _model.Salvar(model.UsuarioNome, model.UsuarioSenha, model.UsuarioEmail);
                _model.ValidarEntidade();

                _servicoDeAplicacaoUsuario.Editar(_model);

                iRetorno.Sucesso(MazzaFC.Dominio.Resources.Global._OperacaoSucesso, _model.UsuarioId);
                return Ok(iRetorno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [AcceptVerbs("POST")]
        [Route("excluir")]
        public async Task<IActionResult> Excluir(UsuarioModel model)
        {
            RetornoDTO iRetorno = new RetornoDTO();

            try
            {
                GerarTokenParaModel(Request.Headers);

                var _model = _servicoDeAplicacaoUsuario.ObterPorID(model.UsuarioId.GetValueOrDefault());
                if (_model == null)
                {
                    return BadRequest(MazzaFC.Dominio.Resources.Global._ModelInvalido);
                }

                _model.Excluir();
                _servicoDeAplicacaoUsuario.Editar(_model);

                iRetorno.Sucesso(MazzaFC.Dominio.Resources.Global._OperacaoSucesso, _model.UsuarioId);
                return Ok(iRetorno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}