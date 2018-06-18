using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazzaFC.APIContrato.EndPoint
{
    public class BaseEndPoint<T>
    {
        public bool Erro { get; set; }
        public string Mensagem { get; set; }
        public Exception Excecao { get; set; }
        public T ObjRetorno { get; set; }
    }
}
