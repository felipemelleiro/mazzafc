using MazzaFC.Dominio.Entidades;
using MazzaFC.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazzaFC.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioMedico : IRepositorioBase<Medico>
    {
        List<MedicoDTO> Listar();

        MedicoDTO ObterPorId(Guid id);
    }
}
