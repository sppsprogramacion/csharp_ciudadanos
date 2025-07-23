using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DInterno
    {//inicio clase
        public int id_interno { get; set; }
        public string codigo { get; set; }
        public int prontuario { get; set; }
        public int dni { get; set; }
        public string apellido { get; set; }
        public string nombre { get; set; }
        public int sexo_id { get; set; }
        public DSexo sexo { get; set; }
        public DateTime fecha_nac { get; set; }
        public string telefono { get; set; }
        public int estado_civil_id { get; set; }
        public DEstadoCivil estado_civil { get; set; }
        public string nacionalidad_id { get; set; }
        public DNacionalidad nacionalidad { get; set; }
        public int organismo_id { get; set; }
        public DOrganismo organismo { get; set; }
        public string foto { get; set; }
        public DateTime fecha_carga { get; set; }
        public int usuario_carga_id { get; set; }
        public DUsuario usuario_carga { get; set; }
        public int organismo_carga_id { get; set; }
        public DOrganismo organismo_carga { get; set; }




    }//fin clase
}
