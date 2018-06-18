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
    public class ServicoDeAplicacaoPaciente : ServicoDeAplicacaoBase<Paciente>, IServicoDeAplicacaoPaciente
    {
        private readonly IServicoPaciente _servicoPaciente;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="servicoPaciente">Serviço Paciente, deve ser passado via Injection</param>
        /// <param name="unidadeDeTrabalho">Unidade de trabalho, deve ser passado via Injection</param>
        public ServicoDeAplicacaoPaciente(IServicoPaciente servicoPaciente, IUnidadeDeTrabalho unidadeDeTrabalho)
            : base(servicoPaciente, unidadeDeTrabalho)
        {
            _servicoPaciente = servicoPaciente;
        }

        public List<PacienteDTO> Listar()
        {
            return _servicoPaciente.Listar();
        }

        public PacienteDTO ObterPorId(Guid id)
        {
            return _servicoPaciente.ObterPorId(id);
        }
    }
}
