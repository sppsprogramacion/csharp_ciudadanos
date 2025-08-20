using CapaPresentacion.Validaciones.AdministrarCiudadano.Datos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion.Validaciones.RegistroDirario.Datos
{
    public class RegistroDiarioDatos 
    {
        public string txtIdCiudadanoIngreso { get; set; }
        public string cmbTipoAtencion { get; set; }
        public string cmbTipoAcceso { get; set; }
        public string cmbSector { get; set; }
        public string cmbMotivoAtencion { get; set; }        
        public string txtBuscarInternos { get; set; }
        public string motivo_atencion_id { get; set; }
        public string txtObservaciones { get; set; }
        
    }
}
