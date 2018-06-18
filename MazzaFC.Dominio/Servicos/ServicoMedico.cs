using MazzaFC.Dominio.Entidades;
using MazzaFC.Dominio.Interfaces.Repositorios;
using MazzaFC.Dominio.Interfaces.Servicos;
using MazzaFC.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazzaFC.Dominio.Servicos
{
    public class ServicoMedico : ServicoBase<Medico>, IServicoMedico
    {
        #region Variáveis privadas somente leitura
        private readonly IRepositorioMedico _repositorioMedico;
        #endregion


        public ServicoMedico(IRepositorioMedico repositorioMedico)
            : base(repositorioMedico)
        {
            _repositorioMedico = repositorioMedico;
        }

        public List<MedicoDTO> Listar()
        {
            return _repositorioMedico.Listar();
        }

        public MedicoDTO ObterPorId(Guid id)
        {
            return _repositorioMedico.ObterPorId(id);
        }
    }
}
