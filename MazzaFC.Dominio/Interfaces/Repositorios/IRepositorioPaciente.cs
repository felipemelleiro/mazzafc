using MazzaFC.Dominio.Entidades;
using MazzaFC.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazzaFC.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioPaciente : IRepositorioBase<Paciente>
    {
        List<PacienteDTO> Listar();

        PacienteDTO ObterPorId(Guid id);
    }
}
