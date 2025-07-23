//using CapaDatos;
//using CapaNegocio;
//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;






namespace CapaPresentacion
{
    public partial class frmPrincipal : Form
    {
        public static frmPrincipal principal;
        
        public static frmPrincipal VerificarFormulario()
        {
            if (principal == null || principal.IsDisposed)
                principal = new frmPrincipal();

                return principal;
        }
           
        
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnAdministrar_Click(object sender, EventArgs e)
        {

            CiudadanoNuevo FCiudadanos = new CiudadanoNuevo();
            FCiudadanos.Show();
            //CiudadanoNuevo FrmCiudadano = new CiudadanoNuevo();
            //FrmCiudadano.Close();
            //frmNuevo FNuevo = new frmNuevo();
            //FNuevo.Show();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void btnRegistroDiario_Click(object sender, EventArgs e)
        {
            frmRegistroDiario registroDiario = new frmRegistroDiario();
            registroDiario.Show();
        }
    }
}
