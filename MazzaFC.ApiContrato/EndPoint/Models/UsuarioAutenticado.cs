using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazzaFC.APIContrato.EndPoint.Models
{
    public class UsuarioAutenticado
    {
        public Guid UsuarioId { get; set; }

        public String UsuarioNome { get; set; }

        public String UsuarioEmail { get; set; }

        public String Token { get; set; }
    }
}
