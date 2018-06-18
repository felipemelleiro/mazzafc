using MazzaFC.Dominio.Entidades;
using MazzaFC.Dominio.Especificacoes.Medico;
using MazzaFC.Dominio.Interfaces.Repositorios;
using MazzaFC.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MazzaFC.Infraestrutura.Dados.Repositorios
{
    public class RepositorioMedico : RepositorioBase<Medico>, IRepositorioMedico
    {
        public RepositorioMedico(Contexto db)
            : base(db)
        {
            Db = db;
        }


        public List<MedicoDTO> Listar()
        {
            var filtro = new EspecificacaoNExcluido();
            var query = Db.Medico
                .Include(lazy => lazy.Pessoa)
                .Where(filtro.Atende());

            var retorno = (from model in query
                           select new MedicoDTO()
                           {
                               MedicoId = model.MedicoId,
                               MedicoCRM = model.MedicoCRM,
                               MedicoEspecialidade = model.MedicoEspecialidade,
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

        public MedicoDTO ObterPorId(Guid id)
        {
            var filtro = new EspecificacaoNExcluido();
            var query = Db.Medico
                .Include(lazy => lazy.Pessoa)
                .Where(w => w.MedicoId == id);
                
            query = query.Where(filtro.Atende());

            var retorno = (from model in query
                           select new MedicoDTO()
                           {
                               MedicoId = model.MedicoId,
                               MedicoCRM = model.MedicoCRM,
                               MedicoEspecialidade = model.MedicoEspecialidade,
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
