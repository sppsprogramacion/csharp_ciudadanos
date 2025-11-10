using CapaDatos;
using CapaNegocio;
using CapaPresentacion.Validaciones.AdministrarCiudadano.Datos;
using CapaPresentacion.Validaciones.AdministrarCiudadano.ValidacionCiudadano;
using CapaPresentacion.Validaciones.NuevoCiudadano.Datos;
using CapaPresentacion.Validaciones.NuevoCiudadano.ValidacionNuevoCiudadano;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmSalidaCiudadano : Form
    {
        //VARIABLES GLOBALES
        private ErrorProvider errorProvider = new ErrorProvider();
        public frmSalidaCiudadano()
        {
            InitializeComponent();
        }

        private async void btnBuscarApellido_Click(object sender, EventArgs e)
        {
            //limpiar errores de provider
            errorProvider.Clear();

            //validar
            var data = new CiudadanoNuevoDatos
            {
                txtBuscarApellido = txtBuscarApellido.Text
            };

            var validator = new BuscarApellidoValidator();
            var result = validator.Validate(data);

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

            NCiudadano nCiudadanos = new NCiudadano();

            string apellido_ciudadanos = Convert.ToString(this.txtBuscarApellido.Text);
            (List<DCiudadano> listaCiudadanos, string errorResponse) = await nCiudadanos.RetornarListaCiudadanosXapellido(apellido_ciudadanos);
            if (listaCiudadanos == null)
            {
                MessageBox.Show(errorResponse, "Atención al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var datosFiltrados = listaCiudadanos
                .Select(c => new
                {
                    id_ciudadano = c.id_ciudadano,
                    Apellido = c.apellido,
                    Nombre = c.nombre,
                    DNI = c.dni,
                    Sexo = c.sexo.sexo
                })
                .ToList();


            dgvListaCiudadanos.DataSource = datosFiltrados;

            if (listaCiudadanos.Count == 0)
            {
                MessageBox.Show("No se encontraron registros", "Atención al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {

                dgvListaCiudadanos.Columns[1].Width = 200;
                dgvListaCiudadanos.Columns[1].Width = 200;
            }


        }

        private async void dgvListaCiudadanos_KeyDown(object sender, KeyEventArgs e)
        {
            //AL PRESIONAR ENTER MOSTRAR EL TRAMITE
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                //this.idInternoGlobal = 1;
                if (dgvListaCiudadanos.SelectedRows.Count > 0)
                {
                    int idCiudadano;

                    idCiudadano = Convert.ToInt32(this.dgvListaCiudadanos.CurrentRow.Cells["id_ciudadano"].Value);

                    NCiudadano nCiudadano = new NCiudadano();
                    (DCiudadano dCiudadanoResponse, string errorResponse) = await nCiudadano.BuscarCiudadanoXID(idCiudadano);



                    if (dCiudadanoResponse == null)
                    {
                        MessageBox.Show(errorResponse, "Atención al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                    this.txtIdCiudadano.Text = idCiudadano.ToString();
                    //this.txtDocumentoIdentidad.Text = dCiudadanoResponse.dni.ToString();
                    //this.txtNombreCiudadano.Text = dCiudadanoResponse.apellido + " " + dCiudadanoResponse.nombre;
                    //this.ptbFotoCiudadano.Load(dCiudadanoResponse.foto);
                    //this.txtNacionalidad.Text = dCiudadanoResponse.nacionalidad.nacionalidad.ToString();
                    //this.txtNacionalidad.Text = dCiudadanoResponse.categoria_ciudadano.ToString();


                    //this.txtIdCiudadanoIngreso.Text = Convert.ToString(this.dgvCiudadanosRegistroDiario.CurrentRow.Cells["id_ciudadano"].Value);
                    //this.txtDocumentoIdentidad.Text = Convert.ToString(this.dgvCiudadanosRegistroDiario.CurrentRow.Cells["dni"].Value);
                    //this.txtNombreCiudadano.Text = Convert.ToString(this.dgvCiudadanosRegistroDiario.CurrentRow.Cells["apellido"].Value) + " " + Convert.ToString(this.dgvCiudadanosRegistroDiario.CurrentRow.Cells["nombre"].Value);




                }//fin if
                else
                {
                    MessageBox.Show("Debe seleccionar un ciudadano.");
                }

            }
        }

        private async void btnRegistrarSalida_Click(object sender, EventArgs e)
        {
            if (this.txtIdCiudadano.Text == string.Empty)
            {
                MessageBox.Show("Debe seleccionar el Ciudadano");
            }

            else
            {
                NRegistroDiario nRegistroDiario = new NRegistroDiario();

                //limpiar errores de provider
                //errorProvider.Clear();

                /*//validacion de formulario
                var datosFormulario = new CiudadanoDatos
                {
                    txtDetalleCategoriaQuitar = txtDetalleCategoriaQuitar.Text,
                };

                var validator = new QuitarCategoriaDelCiudadano();
                var result = validator.Validate(datosFormulario);

                if (!result.IsValid)
                {
                    MessageBox.Show("Complete correctamente los campos del formulario", "Atencion al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    foreach (var failure in result.Errors)
                    {
                        Control control = Controls.Find(failure.PropertyName, true)[0];
                        errorProvider.SetError(control, failure.ErrorMessage);
                    }
                    return;
                }
                //fin validacion...........................*/

                var data = new
                {
                    horario_salida = this.dtpHoraSalida.Value.ToString("HH:MM:ss"),
                };

                string dataCategoria = JsonConvert.SerializeObject(data);

                (bool respuestaEditar, string errorResponse) = await nRegistroDiario.crearEgresoRegistroDiario(Convert.ToInt32(txtIdCiudadano.Text), dataCategoria);

                if (respuestaEditar)
                {

                    MessageBox.Show("Se quitó correctamente la categoria", "Atencion ciudadanos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    /*this.CargarCategoriasDelCiudadano();

                    this.txtIdCategoriaQuitar.Text = string.Empty;
                    this.txtCategoriaQuitar.Text = string.Empty;
                    this.txtFechaCargaCategoriaQuitar.Text = string.Empty;
                    this.txtDetalleCategoriaQuitar.Text = string.Empty;*/

                }
                else
                {
                    MessageBox.Show(errorResponse, "Atencion ciudadanos", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
    }
}
