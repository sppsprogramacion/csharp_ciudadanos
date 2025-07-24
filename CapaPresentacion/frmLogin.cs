using CapaDatos;
using CapaNegocio;
using CapaPresentacion.Validaciones.Login.Datos;
using CapaPresentacion.Validaciones.Login.ValidacionLogin;
using CommonCache;
//using MaterialSkin.Controls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CapaPresentacion
{
    public partial class frmLogin : Form
    {
        //VARIABLES GLOBALES
        private ErrorProvider errorProvider = new ErrorProvider();

        public frmLogin()
        {
            InitializeComponent();
        }

        private async void btnAcceder_Click(object sender, EventArgs e)
        {//inicio boton
            //limpiar errores de provider
            errorProvider.Clear();

            NAuth nAuth = new NAuth();

            var dataValidar = new LoginDatos
            {
                txtUsuario = txtUsuario.Text,
                txtPasword = txtPasword.Text
            };

            var validator = new LoginValidator();
            var result = validator.Validate(dataValidar);


            if (!result.IsValid)
            {
                MessageBox.Show("Complete correctamente los campos del formulario", "Atencion Ciudadanos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                foreach (var failure in result.Errors)
                {

                    Control control = Controls.Find(failure.PropertyName, true)[0];
                    errorProvider.SetError(control, failure.ErrorMessage);
                }
                return;
            }
            //fin validar

            var data = new
            {
                dni = Convert.ToInt32(txtUsuario.Text),
                clave = txtPasword.Text
            };

            string dataLogin = JsonConvert.SerializeObject(data);

            (bool acceso, string error) = await nAuth.LoginUsuario(dataLogin);

            if (acceso)
            {
                CurrentUser currentUser = CurrentUser.Instance;

                MessageBox.Show("Bienvenido " + currentUser.nombre + " " + currentUser.apellido, "Accesso concedido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmPrincipal FrmPrincipal = new frmPrincipal();

                this.Hide();
                FrmPrincipal.Show();
            }
            else
            {
                MessageBox.Show($"{error}", "Error de inicio de sesion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            

        }//fin boton

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            
            Application.Exit();
        }
    }
}
