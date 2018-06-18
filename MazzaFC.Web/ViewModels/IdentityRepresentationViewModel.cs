using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MazzaFC.Web.ViewModels
{
    [Serializable]
    public class IdentityRepresentationViewModel
    {
        public bool IsAuthenticated { get; set; }

        public string MensagemLogin { get; set; }

        public Guid UsuarioId { get; set; }

        public string Name { get; set; }

        public string Token { get; set; }

        public string Roles { get; set; }
    }
}