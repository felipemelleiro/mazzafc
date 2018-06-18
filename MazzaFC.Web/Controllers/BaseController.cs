using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MazzaFC.Web.Controllers
{
    public class BaseController : Controller
    {
        protected string token = "";

        public BaseController() : base()
        {
        }


        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            this.token = MazzaFC.Web.Security.CustomPrincipal.GetCurrentUser(HttpContext).Token;

        }
    }
}