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
    [Route("api/paciente")]
    [ApiController]
    public class PacienteController : ControllerCustomController
    {
        private readonly IServicoDeAplicacaoPaciente _servicoDeAplicacaoPaciente;
        private readonly IServicoDeAplicacaoPessoa _servicoDeAplicacaoPessoa;

        public PacienteController(IServicoDeAplicacaoPaciente servicoDeAplicacaoPaciente, IServicoDeAplicacaoPessoa servicoDeAplicacaoPessoa)
        {
            _servicoDeAplicacaoPaciente = servicoDeAplicacaoPaciente;
            _servicoDeAplicacaoPessoa = servicoDeAplicacaoPessoa;
        }

        [AcceptVerbs("GET")]
        [Route("listar")]
        public async Task<IActionResult> Listar()
        {
            try
            {
                GerarTokenParaModel(Request.Headers);

                var lista = _servicoDeAplicacaoPaciente.Listar();

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

                var model = _servicoDeAplicacaoPaciente.ObterPorId(id);

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
        public async Task<IActionResult> Adicionar(PacienteModel model)
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

                var _model = new MazzaFC.Dominio.Entidades.Paciente();
                _model.Salvar(_pessoaid, model.PacientePlanoSaude);
                _model.ValidarEntidade();

                _servicoDeAplicacaoPaciente.Adicionar(_model);

                iRetorno.Sucesso(MazzaFC.Dominio.Resources.Global._OperacaoSucesso, _model.PacienteId);
                return Ok(iRetorno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [AcceptVerbs("POST")]
        [Route("editar")]
        public async Task<IActionResult> Editar(PacienteModel model)
        {
            RetornoDTO iRetorno = new RetornoDTO();

            try
            {
                GerarTokenParaModel(Request.Headers);

                var _model = _servicoDeAplicacaoPaciente.ObterPorID(model.PacienteId);
                if (_model == null)
                {
                    return BadRequest(MazzaFC.Dominio.Resources.Global._ModelInvalido);
                }

                var _pessoaid = _servicoDeAplicacaoPessoa.Salvar(model.Pessoa.PessoaDocumento, model.Pessoa.PessoaNome, model.Pessoa.PessoaDataNascimento, model.Pessoa.PessoaRG);
                _model.Salvar(_pessoaid, model.PacientePlanoSaude);
                _model.ValidarEntidade();

                _servicoDeAplicacaoPaciente.Editar(_model);

                iRetorno.Sucesso(MazzaFC.Dominio.Resources.Global._OperacaoSucesso, _model.PacienteId);
                return Ok(iRetorno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}