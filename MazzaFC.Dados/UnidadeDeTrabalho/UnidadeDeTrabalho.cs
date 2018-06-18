using MazzaFC.Dominio.Interfaces.UnidadeDeTrabalho;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace MazzaFC.Infraestrutura.Dados.UnidadeDeTrabalho
{
    public class UnidadeDeTrabalho : IDisposable, IUnidadeDeTrabalho
    {
        private bool _disposed;
        private Contexto _contexto;
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="contexto">Contexto, deve ser passado via injecton</param>
        public UnidadeDeTrabalho(Contexto contexto)
        {
            _contexto = contexto;
        }
        /// <summary>
        /// Commit das alterações
        /// </summary>
        public void Commit()
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    _contexto.SaveChanges();
                    scope.Complete();
                }
            }
            //catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            //{
            //    List<String> lsErros = new List<string>();

            //    foreach (var validationErrors in dbEx.EntityValidationErrors)
            //    {
            //        foreach (var validationError in validationErrors.ValidationErrors)
            //        {
            //            var errorMsg = "O campo [" + validationError.PropertyName + "] " + validationError.ErrorMessage + "";
            //            lsErros.Add(errorMsg);

            //            throw new Exception(errorMsg);
            //        }
            //    }
            //}
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Dispose.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Dispose.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _contexto.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
