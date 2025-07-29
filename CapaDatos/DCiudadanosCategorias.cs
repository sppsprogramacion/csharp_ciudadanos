using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DCiudadanosCategorias
    {
        public int id_ciudadano_categoria { get; set; }
        public int ciudadano_id { get; set; }
        public DCiudadano ciudadano { get; set; }
        public int categoria_ciudadano_id { get; set; }
        public DCategoriasCiudadano categoria_ciudadano { get; set; }
        public DateTime fecha_carga { get; set; }
        public bool vigente { get; set; }
        public string detalle_quitar_categoria { get; set; }
        public DOrganismo organismo { get; set; }
        public DUsuario usuario { get; set; }
    }
}
