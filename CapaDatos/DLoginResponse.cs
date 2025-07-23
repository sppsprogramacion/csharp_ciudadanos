using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DLoginResponse
    {
        public DUsuario usuario { get; set; }
        public string token { get; set; }
    }
}
