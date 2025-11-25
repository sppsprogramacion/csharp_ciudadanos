using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DProhibicionAnticipada
    {
        public int id_prohibicion_anticipada { get; set; }
        public int dni_visita { get; set; }
        public string apellido_visita { get; set; }
        public string nombre_visita { get; set; }
        public int sexo_id { get; set; }
        public DSexo sexo { get; set; }
        public string detalle { get; set; }
        public string apellido_interno { get; set; }
        public string nombre_interno { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }
        public bool is_exinterno { get; set; }
        public bool vigente { get; set; }
        public string tipo_levantamiento { get; set; }
        public DateTime fecha_prohibicion { get; set; }
        public int organismo_id { get; set; }
        public DOrganismo organismo { get; set; }
        public int usuario_id { get; set; }
        public DUsuario usuario { get; set; }
    }
}
