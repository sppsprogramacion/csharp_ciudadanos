using CapaDatos;
using CapaNegocio;
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
        public frmLogin()
        {
            InitializeComponent();
        }

        private async void btnAcceder_Click(object sender, EventArgs e)
        {//inicio boton

            NAuth nAuth = new NAuth();

            var data = new
            {
                dni = Convert.ToInt32(txtUsuario.Text),
                clave = txtPasword.Text
            };

            string dataLogin = JsonConvert.SerializeObject(data);


            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    HttpResponseMessage httpResponse = await nAuth.LoginUsuario(dataLogin);

                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var contentRespuesta = await httpResponse.Content.ReadAsStringAsync();
                        DUsuario dataUsuario = JsonConvert.DeserializeObject<DUsuario>(contentRespuesta);
                        CurrentUser currentUser = CurrentUser.Instance;

                        MessageBox.Show("Bienvenido " + currentUser.nombre + " " + currentUser.apellido, "Accesso concedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show("Roles " + currentUser.roles[1]);
                        MessageBox.Show("Token: " + SessionManager.Token);
                        //FormVisitas formVisitas = new FormVisitas();
                        frmPrincipal FrmPrincipal = new frmPrincipal();

                        this.Hide();
                        FrmPrincipal.Show();
                    }
                    else
                    {
                        string errorMessage = await httpResponse.Content.ReadAsStringAsync();
                        var mensaje = JObject.Parse(errorMessage)["message"]?.ToString();
                        MessageBox.Show($"Error: {mensaje}", "Error de inicio de sesion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                }
                catch (HttpRequestException httpRequestException)
                {
                    // Capturar errores de la solicitud HTTP
                    //throw new Exception($"Error al realizar la solicitud: {httpRequestException.Message}");
                    MessageBox.Show("Error de conexion");
                }
                catch (Exception ex)
                {
                    // Manejo de otros tipos de errores MySQL
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }//fin boton
    }
}
