using MazzaFC.Dominio.Entidades;
using MazzaFC.Dominio.Interfaces.Repositorios;
using MazzaFC.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MazzaFC.Infraestrutura.Dados.Repositorios
{
    public class RepositorioPaciente : RepositorioBase<Paciente>, IRepositorioPaciente
    {
        public RepositorioPaciente(Contexto db)
            : base(db)
        {
            Db = db;
        }

        public List<PacienteDTO> Listar()
        {
            var query = Db.Paciente
                .Include(lazy => lazy.Pessoa)
                .ToList();

            var retorno = (from model in query
                           select new PacienteDTO()
                           {
                               PacienteId = model.PacienteId,
                               PacientePlanoSaude = model.PacientePlanoSaude,
                               Pessoa = new PessoaDTO()
                               {
                                   PessoaId = model.Pessoa.PessoaId,
                                   PessoaDocumento = model.Pessoa.PessoaDocumento,
                                   PessoaNome = model.Pessoa.PessoaNome,
                                   PessoaDataNascimento = model.Pessoa.PessoaDataNascimento,
                                   PessoaRG = model.Pessoa.PessoaRG
                               }
                           }).ToList();

            return retorno;
        }

        public PacienteDTO ObterPorId(Guid id)
        {
            var query = Db.Paciente
                .Include(lazy => lazy.Pessoa)
                .Where(w => w.PacienteId == id)
                .ToList();

            var retorno = (from model in query
                           select new PacienteDTO()
                           {
                               PacienteId = model.PacienteId,
                               PacientePlanoSaude = model.PacientePlanoSaude,
                               Pessoa = new PessoaDTO()
                               {
                                   PessoaId = model.Pessoa.PessoaId,
                                   PessoaDocumento = model.Pessoa.PessoaDocumento,
                                   PessoaNome = model.Pessoa.PessoaNome,
                                   PessoaDataNascimento = model.Pessoa.PessoaDataNascimento,
                                   PessoaRG = model.Pessoa.PessoaRG
                               }
                           }).FirstOrDefault();

            return retorno;
        }
    }
}
