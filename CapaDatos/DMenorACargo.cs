using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DMenorACargo
    {
        public int id_menor_a_cargo { get; set; }
        public int ciudadano_tutor_id { get; set; }
        public DCiudadano ciudadanoTutor { get; set; }
        public int ciudadano_menor_id { get; set; }
        public DCiudadano ciudadanoMenor { get; set; }
        public string parentesco_menor_id { get; set; }
        public DParentescoMenor parentesco_menor { get; set; }
        public int edadMenor { get; set; }
        public DateTime fecha_carga { get; set; }
        public bool anulado { get; set; }
        public string detalle_anular { get; set; }
        public int usuario_id { get; set; }
        public DUsuario usuario { get; set; }
    }
}
