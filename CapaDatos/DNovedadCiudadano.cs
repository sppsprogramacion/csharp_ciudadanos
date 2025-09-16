using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DNovedadCiudadano
    {
        public int id_novedad_ciudadano { get; set; }
        public int ciudadano_id { get; set; }
        public DCiudadano ciudadano { get; set; }
        public string novedad { get; set; }
        public string novedad_detalle { get; set; }
        public DateTime fecha_novedad { get; set; }
        public int organismo_id { get; set; }
        public DOrganismo organismo { get; set; }        
        public int usuario_id { get; set; }
        public DUsuario usuario { get; set; }
    }
}
