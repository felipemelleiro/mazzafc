using MazzaFC.Web.Security;
using MazzaFC.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MazzaFC.Web.Areas.Autenticacao.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            // We do not want to use any existing identity information
            EnsureLoggedOut();

            // Store the originating URL so we can attach it to a form field
            var viewModel = new LoginViewModel { ReturnUrl = returnUrl };

            return View(viewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel viewModel)
        {
            // Ensure we have a valid viewModel to work with
            if (!ModelState.IsValid)
                return View(viewModel);

            var _modelAutenticacao = CustomPrincipal.Login(viewModel.Email, viewModel.Senha, viewModel.LembreMe);

            if (_modelAutenticacao.IsAuthenticated)
            {
                return RedirectToLocal(viewModel.ReturnUrl);
            }

            // No existing user was found that matched the given criteria
            ModelState.AddModelError("", _modelAutenticacao.MensagemLogin);

            // If we got this far, something failed, redisplay form
            return View(viewModel);
        }

        public ActionResult LogOff()
        {
            CustomPrincipal.Logout();

            return RedirectToLocal("/");
        }

        #region Helpers

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }

        private void EnsureLoggedOut()
        {
            // If the request is (still) marked as authenticated we send the user to the logout action
            if (Request.IsAuthenticated)
                LogOff();
        }

        #endregion
    }
}