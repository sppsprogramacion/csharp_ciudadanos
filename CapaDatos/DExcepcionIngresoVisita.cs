using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DExcepcionIngresoVisita
    {
        public int id_excepcion_ingreso_visita { get; set; }
        public int ciudadano_id { get; set; }
        public DCiudadano ciudadano { get; set; }
        public int interno_id { get; set; }
        public DInterno interno { get; set; }
        public string motivo { get; set; }
        public string detalle_excepcion { get; set; }
        public DateTime fecha_excepcion { get; set; }
        public bool cumplimentado { get; set; }
        public bool controlado { get; set; }
        public bool anulado { get; set; }        
        public DateTime fecha_carga { get; set; }
        public int organismo_id { get; set; }
        public DOrganismo organismo { get; set; }
        public int usuario_id { get; set; }
        public DUsuario usuario_carga { get; set; }

    }
}
