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
    [Route("api/medico")]
    [ApiController]
    public class MedicoController : ControllerCustomController
    {
        private readonly IServicoDeAplicacaoMedico _servicoDeAplicacaoMedico;
        private readonly IServicoDeAplicacaoPessoa _servicoDeAplicacaoPessoa;

        public MedicoController(IServicoDeAplicacaoMedico servicoDeAplicacaoMedico, IServicoDeAplicacaoPessoa servicoDeAplicacaoPessoa)
        {
            _servicoDeAplicacaoMedico = servicoDeAplicacaoMedico;
            _servicoDeAplicacaoPessoa = servicoDeAplicacaoPessoa;
        }

        [AcceptVerbs("GET")]
        [Route("listar")]
        public async Task<IActionResult> Listar()
        {
            try
            {
                GerarTokenParaModel(Request.Headers);

                var lista = _servicoDeAplicacaoMedico.Listar();

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

                var model = _servicoDeAplicacaoMedico.ObterPorId(id);

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
        public async Task<IActionResult> Adicionar(MedicoModel model)
        {
            RetornoDTO iRetorno = new RetornoDTO();

            try
            {
                GerarTokenParaModel(Request.Headers);

                if (model == null)
                {
                    return BadRequest(MazzaFC.Dominio.Resources.Global._ModelInvalido);
                }

                var _pessoaid = _servicoDeAplicacaoPessoa.Salvar(model.Pessoa.PessoaDocumento, model.Pessoa.PessoaNome, model.Pessoa.PessoaDataNascimento, model.Pessoa.PessoaRG);

                var _model = new MazzaFC.Dominio.Entidades.Medico();
                _model.Salvar(_pessoaid, model.MedicoEspecialidade, model.MedicoCRM);
                _model.ValidarEntidade();

                _servicoDeAplicacaoMedico.Adicionar(_model);

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
        public async Task<IActionResult> Editar(MedicoModel model)
        {
            RetornoDTO iRetorno = new RetornoDTO();

            try
            {
                GerarTokenParaModel(Request.Headers);

                var _model = _servicoDeAplicacaoMedico.ObterPorID(model.MedicoId.GetValueOrDefault());
                if (_model == null)
                {
                    return BadRequest(MazzaFC.Dominio.Resources.Global._ModelInvalido);
                }

                var _pessoaid = _servicoDeAplicacaoPessoa.Salvar(model.Pessoa.PessoaDocumento, model.Pessoa.PessoaNome, model.Pessoa.PessoaDataNascimento, model.Pessoa.PessoaRG);
                _model.Salvar(_pessoaid, model.MedicoEspecialidade, model.MedicoCRM);
                _model.ValidarEntidade();

                _servicoDeAplicacaoMedico.Editar(_model);

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
        public async Task<IActionResult> Excluir(MedicoModel model)
        {
            RetornoDTO iRetorno = new RetornoDTO();

            try
            {
                GerarTokenParaModel(Request.Headers);

                var _model = _servicoDeAplicacaoMedico.ObterPorID(model.MedicoId.GetValueOrDefault());
                if (_model == null)
                {
                    return BadRequest(MazzaFC.Dominio.Resources.Global._ModelInvalido);
                }

                _model.Excluir();
                _servicoDeAplicacaoMedico.Editar(_model);

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