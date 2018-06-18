using MazzaFC.APIContrato.EndPoint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MazzaFC.Web.Controllers
{
    [Authorize]
    public class PacienteController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Listar()
        {
            try
            {
                var respository = new MazzaFC.APIContrato.Repository.PacienteRepository(this.token);
                var retorno = respository.Listar();

                if (retorno.Erro)
                {
                    throw new Exception(retorno.Mensagem);
                }

                return Json(retorno.ObjRetorno, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        public ActionResult Salvar(Paciente model)
        {
            try
            {
                var respository = new MazzaFC.APIContrato.Repository.PacienteRepository(this.token);
                if (model.PacienteId == null || model.PacienteId == Guid.Empty)
                {
                    var retorno = respository.Adicionar(model);
                    if (retorno.Erro)
                    {
                        throw new Exception(retorno.Mensagem);
                    }

                    return Json(retorno.ObjRetorno, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var retorno = respository.Editar(model);
                    if (retorno.Erro)
                    {
                        throw new Exception(retorno.Mensagem);
                    }

                    return Json(retorno.ObjRetorno, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}