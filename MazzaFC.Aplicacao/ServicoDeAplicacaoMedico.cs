using MazzaFC.Dominio.Entidades;
using MazzaFC.Dominio.Interfaces.Aplicacoes;
using MazzaFC.Dominio.Interfaces.Servicos;
using MazzaFC.Dominio.Interfaces.UnidadeDeTrabalho;
using MazzaFC.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazzaFC.Aplicacao
{
    public class ServicoDeAplicacaoMedico : ServicoDeAplicacaoBase<Medico>, IServicoDeAplicacaoMedico
    {
        private readonly IServicoMedico _servicoMedico;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="servicoMedico">Serviço Medico, deve ser passado via Injection</param>
        /// <param name="unidadeDeTrabalho">Unidade de trabalho, deve ser passado via Injection</param>
        public ServicoDeAplicacaoMedico(IServicoMedico servicoMedico, IUnidadeDeTrabalho unidadeDeTrabalho)
            : base(servicoMedico, unidadeDeTrabalho)
        {
            _servicoMedico = servicoMedico;
        }

        public List<MedicoDTO> Listar()
        {
            return _servicoMedico.Listar();
        }

        public MedicoDTO ObterPorId(Guid id)
        {
            return _servicoMedico.ObterPorId(id);
        }
    }
}
