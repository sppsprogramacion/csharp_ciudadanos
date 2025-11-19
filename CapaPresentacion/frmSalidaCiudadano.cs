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
using System.Net.Http;
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

            NRegistroDiario nRegistroDiario = new NRegistroDiario();
            (List<DRegistroDiario> listaRegistroDiario, string errorResponse) = await nRegistroDiario.retornarListaRegistroDiario(this.dtpFecha.Value.ToString("yyyy-MM-dd"), this.dtpHoraInicio.Value.ToString("HH:MM:ss"), this.dtpHoraFin.Value.ToString("HH:MM:ss"));


            if (listaRegistroDiario == null)
            {
                MessageBox.Show(errorResponse, "Atención al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var datosFiltrados = listaRegistroDiario
            .Select(c => new
            {
                IdRegistroDiario = c.id_resgistro_diario,
                Nombre = c.ciudadano.apellido + " " + c.ciudadano.nombre,
                Ingreso = c.hora_ingreso,
                Egreso = c.hora_egreso,
                Destino = c.organismo.organismo,
                División = c.sector_destino.sector_destino,
                TipoAcceso = c.tipo_atencion.tipo_atencion,
                Motivo = c.motivo_atencion.motivo_atencion,
                Sexo = c.ciudadano.sexo.sexo,
                Dni = c.ciudadano.dni,
                Interno = c.interno,
                Obs = c.observaciones,
                Operador = c.usuario.apellido + " " + c.usuario.nombre



            })
            .ToList();
                        
            dgvListaRegistroDiario.DataSource = datosFiltrados;

            if (listaRegistroDiario.Count == 0)
            {
                MessageBox.Show("No se encontraron registros", "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {

                dgvListaRegistroDiario.Columns[1].Width = 200;
            }


        }

        private async void dgvListaCiudadanos_KeyDown(object sender, KeyEventArgs e)
        {
            //AL PRESIONAR ENTER MOSTRAR EL TRAMITE
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                NRegistroDiario nRegistroDiario = new NRegistroDiario();
                //this.idInternoGlobal = 1;
                if (dgvListaRegistroDiario.SelectedRows.Count > 0)
                {
                    int idCiudadano;

                    idCiudadano = Convert.ToInt32(this.dgvListaRegistroDiario.CurrentRow.Cells["idRegistroDiario"].Value);

                   

                    this.txtIdRegistroDiario.Text = idCiudadano.ToString();
                    MessageBox.Show("Registro seleccionado correctamente"); 
                   


                }//fin if
                else
                {
                    MessageBox.Show("Debe seleccionar el registro en la grilla.");
                }

            }
        }

        private async void btnRegistrarSalida_Click(object sender, EventArgs e)
        {
            if (this.txtIdRegistroDiario.Text == string.Empty)
            {
                MessageBox.Show("Debe seleccionar un ciudadano de la lista");
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
                    hora_egreso = this.dtpHoraSalida.Value.ToString("HH:mm:ss"),
                    //horario_salida
                };

                string dataRegistroDiario = JsonConvert.SerializeObject(data);
                DateTime ahora = DateTime.Now;
                string horaFormateada = ahora.ToString("HH:mm:ss");

                //MessageBox.Show("la hora de egreso es: " + " " + this.dtpHoraSalida.Value.ToString("HH:mm:ss") + " " + this.dtpHoraFin.Value.ToString("HH:mm:ss") + " " + horaFormateada);

                try
                {
                    HttpResponseMessage httpResponse = await nRegistroDiario.crearEgresoRegistroDiario(Convert.ToInt32(txtIdRegistroDiario.Text), dataRegistroDiario);

                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var contentRespuesta = await httpResponse.Content.ReadAsStringAsync();
                        MessageBox.Show("Se estableció la hora correctamente", "Atención al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        (List<DRegistroDiario> listaRegistroDiario, string errorResponse) = await nRegistroDiario.retornarListaRegistroDiario(this.dtpFecha.Value.ToString("yyyy-MM-dd"), this.dtpHoraInicio.Value.ToString("HH:MM:ss"), this.dtpHoraFin.Value.ToString("HH:MM:ss"));


                        if (listaRegistroDiario == null)
                        {
                            MessageBox.Show(errorResponse, "Atención al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        var datosFiltrados = listaRegistroDiario
                        .Select(c => new
                        {
                            IdRegistroDiario = c.id_resgistro_diario,
                            Nombre = c.ciudadano.apellido + " " + c.ciudadano.nombre,
                            Ingreso = c.hora_ingreso,
                            Egreso = c.hora_egreso,
                            Destino = c.organismo.organismo,
                            División = c.sector_destino.sector_destino,
                            TipoAcceso = c.tipo_atencion.tipo_atencion,
                            Motivo = c.motivo_atencion.motivo_atencion,
                            Sexo = c.ciudadano.sexo.sexo,
                            Dni = c.ciudadano.dni,
                            Interno = c.interno,
                            Obs = c.observaciones,
                            Operador = c.usuario.apellido + " " + c.usuario.nombre



                        })
                        .ToList();

                        dgvListaRegistroDiario.DataSource = datosFiltrados;

                        if (listaRegistroDiario.Count == 0)
                        {
                            MessageBox.Show("No se encontraron registros", "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {

                            dgvListaRegistroDiario.Columns[1].Width = 200;
                        }

                        //this.HabilitarControlesDatosPersonales(false);
                    }
                    else
                    {
                        string errorMessage = await httpResponse.Content.ReadAsStringAsync();
                        MessageBox.Show("No se pudo editar el registro.");
                        MessageBox.Show($"Error de la API: {errorMessage}", $"Error {httpResponse.StatusCode}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {
                    // Manejo de otros tipos de errores MySQL
                    MessageBox.Show("Error: " + ex.Message);
                }

            }
        }
    }
}
