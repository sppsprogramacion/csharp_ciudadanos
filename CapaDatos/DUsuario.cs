using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DUsuario
    {
        public int id_usuario { get; set; }
        public int dni { get; set; }
        public int legajo { get; set; }
        public string apellido { get; set; }
        public string nombre { get; set; }
        public int sexo_id { get; set; }
        public DSexo sexo { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }

        //public DRol rol { get; set; }
        public int organismo_id { get; set; }
        public DOrganismo organismo { get; set; }
        public bool activo { get; set; }
        public string[] roles { get; set; }


    }
}
