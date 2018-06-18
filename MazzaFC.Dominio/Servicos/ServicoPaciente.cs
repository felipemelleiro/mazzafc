using MazzaFC.Dominio.Entidades;
using MazzaFC.Dominio.Interfaces.Repositorios;
using MazzaFC.Dominio.Interfaces.Servicos;
using MazzaFC.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazzaFC.Dominio.Servicos
{
    public class ServicoPaciente : ServicoBase<Paciente>, IServicoPaciente
    {
        #region Variáveis privadas somente leitura
        private readonly IRepositorioPaciente _repositorioPaciente;
        #endregion


        public ServicoPaciente(IRepositorioPaciente repositorioPaciente)
            : base(repositorioPaciente)
        {
            _repositorioPaciente = repositorioPaciente;
        }

        public List<PacienteDTO> Listar()
        {
            return _repositorioPaciente.Listar();
        }

        public PacienteDTO ObterPorId(Guid id)
        {
            return _repositorioPaciente.ObterPorId(id);
        }
    }
}
