using MazzaFC.Dominio.Entidades;
using MazzaFC.Dominio.Interfaces.Aplicacoes;
using MazzaFC.Dominio.Interfaces.Servicos;
using MazzaFC.Dominio.Interfaces.UnidadeDeTrabalho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MazzaFC.Aplicacao
{
    public class ServicoDeAplicacaoPessoa : ServicoDeAplicacaoBase<Pessoa>, IServicoDeAplicacaoPessoa
    {
        private readonly IServicoPessoa _servicoPessoa;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="servicoPessoa">Serviço Pessoa, deve ser passado via Injection</param>
        /// <param name="unidadeDeTrabalho">Unidade de trabalho, deve ser passado via Injection</param>
        public ServicoDeAplicacaoPessoa(IServicoPessoa servicoPessoa, IUnidadeDeTrabalho unidadeDeTrabalho)
            : base(servicoPessoa, unidadeDeTrabalho)
        {
            _servicoPessoa = servicoPessoa;
        }


        public Guid Salvar(String pessoadocumento, String pessoanome, Nullable<DateTime> pessoadatanascimento, String pessoarg)
        {
            var _model = _servicoPessoa.Listar(w => w.PessoaDocumento.FormatarCPF() == pessoadocumento.FormatarCPF()).FirstOrDefault();
            if (_model == null)
            {
                // Não existe a pessoa com o documento
                // Deve ser inserido
                _model = new Pessoa();
                _model.Salvar(pessoadocumento, pessoanome, pessoadatanascimento, pessoarg);
                _model.ValidarEntidade();
                _servicoPessoa.Adicionar(_model);
            }
            else
            {
                // Pessoa já cadastrada no ducomento
                // Deve ser alterado
                _model.Salvar(pessoadocumento, pessoanome, pessoadatanascimento, pessoarg);
                _model.ValidarEntidade();
                _servicoPessoa.Editar(_model);
            }

            return _model.PessoaId;
        }
    }
}
