using MazzaFC.Dominio.Entidades;
using MazzaFC.Dominio.Especificacoes.Usuario;
using MazzaFC.Dominio.Interfaces.Repositorios;
using MazzaFC.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MazzaFC.Infraestrutura.Dados.Repositorios
{
    public class RepositorioUsuario : RepositorioBase<Usuario>, IRepositorioUsuario
    {
        public RepositorioUsuario(Contexto db)
            : base(db)
        {
            Db = db;
        }


        public UsuarioDTO ObterAutenticacao(string email, string senha)
        {
            var filtro = new EspecificacaoNExcluido();
            var query = Db.Usuario.Where(filtro.Atende());

            query = query.Where(w => w.UsuarioEmail == email && w.UsuarioSenha == senha);
            var retorno = (from user in query
                           select new UsuarioDTO()
                           {
                               UsuarioId = user.UsuarioId,
                               UsuarioNome = user.UsuarioNome,
                               UsuarioEmail = user.UsuarioEmail
                           }).FirstOrDefault();

            return retorno;
        }

        public UsuarioDTO ObterPorId(Guid id)
        {
            var filtro = new EspecificacaoNExcluido();
            var query = Db.Usuario.Where(filtro.Atende());

            query = query.Where(w => w.UsuarioId == id);
            var retorno = (from user in query
                           select new UsuarioDTO()
                           {
                               UsuarioId = user.UsuarioId,
                               UsuarioNome = user.UsuarioNome,
                               UsuarioEmail = user.UsuarioEmail,
                               UsuarioSenha = user.UsuarioSenha
                           }).FirstOrDefault();

            return retorno;
        }

        public List<UsuarioDTO> Listar()
        {
            var filtro = new EspecificacaoNExcluido();
            var query = Db.Usuario.Where(filtro.Atende());

            var retorno = (from user in query
                           select new UsuarioDTO()
                           {
                               UsuarioId = user.UsuarioId,
                               UsuarioNome = user.UsuarioNome,
                               UsuarioEmail = user.UsuarioEmail,
                               UsuarioSenha = user.UsuarioSenha
                           }).ToList();

            return retorno;
        }
    }
}
