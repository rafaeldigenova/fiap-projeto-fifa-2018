using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.ProjetoFifa2018.Web.ViewModel
{
    public class LoginViewModel
    {
        public string UseName { get; set; }
        public string Password { get; set; }
        public bool IsPersistent { get; set; }
    }
}
