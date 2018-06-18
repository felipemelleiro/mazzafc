using MazzaFC.Web.Security.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace MazzaFC.Web.Security
{
    public class CustomPrincipal : ICustomPrincipal
    {

        public static CustomIdentity GetCurrentUser(HttpContextBase httpContext)
        {
            HttpCookie cookie = httpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie != null)
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
                CustomPrincipal.Login(ticket.UserData);

                return (Security.CustomIdentity)HttpContext.Current.User.Identity;
            }

            return null;

        }

        private CustomPrincipal() { }

        private CustomPrincipal(ICustomIdentity identity)
        {
            this.Identity = identity;
        }

        public IIdentity Identity { get; private set; }

        public bool IsInRole(string role)
        {
            if (string.IsNullOrEmpty(role))
            {
                throw new ArgumentException("Role is null");
            }
            return ((ICustomIdentity)Identity).IsInRole(role);
        }


        public static void Logout()
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie != null)
            {
                FormsAuthentication.SignOut();
                HttpContext.Current.Request.Cookies.Remove(FormsAuthentication.FormsCookieName);
            }
            HttpContext.Current.User = new GenericPrincipal(new GenericIdentity(""), new string[] { });
        }

        /// <summary>
        /// Login
        /// </summary>
        public static CustomIdentity Login(string email, string senha, bool rememberMe)
        {
            var identity = CustomIdentity.GetCustomIdentity(email, senha);
            if (identity.IsAuthenticated)
            {
                HttpContext.Current.User = new CustomPrincipal(identity);
                FormsAuthenticationTicket ticket =
                       new FormsAuthenticationTicket(
                           1, identity.UsuarioId.ToString(), DateTime.Now, DateTime.Now.AddMinutes(30), rememberMe,
                           identity.ToJson(), FormsAuthentication.FormsCookiePath);
                string encryptedTicket = FormsAuthentication.Encrypt(ticket);

                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                cookie.Path = FormsAuthentication.FormsCookiePath;

                if (rememberMe)
                {
                    cookie.Expires = DateTime.Now.AddYears(1);// good for one year
                }

                HttpContext.Current.Response.Cookies.Add(cookie);
            }
            return identity;
        }

        public static bool Login(string cookieString)
        {
            ICustomIdentity identity = CustomIdentity.FromJson(cookieString);
            if (identity.IsAuthenticated)
            {
                HttpContext.Current.User = new CustomPrincipal(identity);
            }
            return identity.IsAuthenticated;
        }


    }
}