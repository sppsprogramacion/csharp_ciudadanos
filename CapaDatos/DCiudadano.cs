using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DCiudadano
    {
        public int id_ciudadano { get; set; }
        public int dni { get; set; }
        public string apellido { get; set; }
        public string nombre { get; set; }
        public int sexo_id { get; set; }
        public DSexo sexo { get; set; }
        public DateTime fecha_nac { get; set; }
        public int edad { get; set; }
        public string telefono { get; set; }
        public int estado_civil_id { get; set; }
        public DEstadoCivil estado_civil { get; set; }
        public string nacionalidad_id { get; set; }
        public DNacionalidad nacionalidad { get; set; }
        public DateTime fecha_alta { get; set; }
        public bool es_visita { get; set; }
        public string foto { get; set; }
        public string pais_id { get; set; }
        public DPais pais { get; set; }
        public string provincia_id { get; set; }
        public DProvincia provincia { get; set; }
        //public int ciudad_id { get; set; }
        //public DCiudad ciudad { get; set; }
        public int departamento_id { get; set; }
        public Departamento departamento { get; set; }
        public int municipio_id { get; set; }
        public DMunicipio municipio { get; set; }
        public int categoria_ciudadano_id { get; set; }
        public DCategoriasCiudadano categoria_ciudadano { get; set; }
        public string ciudad { get; set; }
        public string barrio { get; set; }
        public string direccion { get; set; }
        public int numero_dom { get; set; }
        public bool tiene_discapacidad { get; set; }
        public string discapacidad_detalle { get; set; }
        public int organismo_alta_id { get; set; }
        public string novedad_detalle { get; set; }
      
    }
}
