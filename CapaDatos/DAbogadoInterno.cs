using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DAbogadoInterno
    {
        public int id_abogado_interno { get; set; }
        public int ciudadano_id { get; set; }
        public DCiudadano ciudadano { get; set; }
        public int interno_id { get; set; }
        public DInterno interno { get; set; }
        public int tipo_defensor_id { get; set; }
        public DTipoDefensor tipo_defensor { get; set; }
        public DateTime fecha_carga { get; set; }
        public bool vigente { get; set; }
        
    }
}
