using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace MazzaFC.Web.Security.Interfaces
{
    public interface ICustomIdentity : IIdentity
    {
        bool IsInRole(string role);

        string ToJson();
    }
}