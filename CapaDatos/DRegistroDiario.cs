using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DRegistroDiario
    {
        public int id_resgistro_diario { get; set; }
        public int ciudadano_id { get; set; }
        public DCiudadano ciudadano { get; set; }
        public int tipo_atencion_id { get; set; }
        public DTipoAtencion tipo_atencion { get; set; }
        public int tipo_acceso_id { get; set; }
        public DTipoAcceso tipo_acceso { get; set; }

        public int sector_destino_id { get; set; }
        public DSectoresDestino sector_destino { get; set; }
        public int motivo_atencion_id { get; set; }
        public DMotivoAtencion motivo_atencion { get; set; }
        public string interno { get; set; }
        public DateTime fecha_ingreso { get; set; }
        public string hora_ingreso { get; set; }
        public string hora_egreso { get; set; }
        public string observaciones { get; set; }
        
        public int organismo_id { get; set; }
        public DOrganismo organismo { get; set; }
        public int usuario_id { get; set; }
        public DUsuario usuario { get; set; }
    }
}
