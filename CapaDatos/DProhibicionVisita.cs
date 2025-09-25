using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DProhibicionVisita
    {
        public int id_prohibicion_visita { get; set; }
        public int ciudadano_id { get; set; }
        public DCiudadano ciudadano { get; set; }
        public int organismo_id { get; set; }
        public DOrganismo organismo { get; set; }
        public DateTime fecha_prohibicion { get; set; }
        public string disposicion { get; set; }
        public string detalle { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }
        public bool vigente { get; set; }
        public bool anulado { get; set; }
        public int usuario_id { get; set; }
        public DUsuario usuario { get; set; }
        public string tipo_levantamiento { get; set; }

    }
}
