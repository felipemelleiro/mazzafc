using MazzaFC.Dominio.Entidades;
using MazzaFC.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazzaFC.Infraestrutura.Dados.Repositorios
{
    public class RepositorioPessoa : RepositorioBase<Pessoa>, IRepositorioPessoa
    {

        public RepositorioPessoa(Contexto db)
            : base(db)
        {
            Db = db;
        }


    }
}
