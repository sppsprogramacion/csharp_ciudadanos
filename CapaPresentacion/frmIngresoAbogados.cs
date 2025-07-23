using CapaDatos;
using CapaNegocio;
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
    public partial class frmIngresoAbogados : Form
    {
        public frmIngresoAbogados()
        {
            InitializeComponent();
        }

        private async void frmIngresoAbogados_Load(object sender, EventArgs e)
        {
            //Carga de combo tipo defensor 
            NTipoDefensor nTipoDefensor = new NTipoDefensor();
            cmbTipoAbogado.ValueMember = "id_tipo_defensor";
            cmbTipoAbogado.DisplayMember = "tipo_defensor";
            (List<DTipoDefensor> listaTipoDefensor, string errorResponse) = await nTipoDefensor.MostrarTipoDefensor();
            MessageBox.Show("defensor", listaTipoDefensor[0].tipo_defensor);
            cmbTipoAbogado.DataSource = listaTipoDefensor;




        }

        private async void btnBuscarInternos_Click(object sender, EventArgs e)
        {
            NInterno nInternos = new NInterno();
            string apellido_ciudadanos = Convert.ToString(this.txtBuscarInternos.Text);
            (List<DInterno> listaInternos, string errorResponse) = await nInternos.RetornarListaInternoXapellido(apellido_ciudadanos);
            if (listaInternos == null)
            {
                MessageBox.Show(errorResponse, "Atención al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var datosFiltrados = listaInternos
                .Select(c => new
                {
                    id_interno = c.id_interno,
                    Apellido = c.apellido,
                    Nombre = c.nombre,
                    Prontuario = c.prontuario,
                    Sexo = c.sexo.sexo
                })
                .ToList();
            dgvInternos.DataSource = datosFiltrados;
        }

        private void dgvInternos_KeyDown(object sender, KeyEventArgs e)
        {
            //AL PRESIONAR ENTER MOSTRAR EL TRAMITE
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                //this.idInternoGlobal = 1;
                if (dgvInternos.SelectedRows.Count > 0)
                {
                    this.txtIdInterno.Text = Convert.ToString(this.dgvInternos.CurrentRow.Cells["id_interno"].Value);
                    MessageBox.Show("EL interno: " + Convert.ToString(this.dgvInternos.CurrentRow.Cells["apellido"].Value) + " " + Convert.ToString(this.dgvInternos.CurrentRow.Cells["nombre"].Value) + " " + "ha sido seleccionado");
                }
                else
                {
                    MessageBox.Show("No hay internos con ese apellido en la base de datos.");
                }

            }
        }

        private async void btnHistorialIngresos_Click(object sender, EventArgs e)
        {
            NAbogadoInterno nAbogadoInterno = new NAbogadoInterno();
            int id_ciudadano = Convert.ToInt32(this.txtIdAbogadoIngreso.Text);
            MessageBox.Show("id del ciudadano: " + id_ciudadano);
            (List<DAbogadoInterno> listaAbogadoInternos, string errorResponse) = await nAbogadoInterno.retornarListaInternosXId(id_ciudadano);
            if (listaAbogadoInternos == null)
            {
                MessageBox.Show(errorResponse, "Atención al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var datosFiltrados = listaAbogadoInternos
                .Select(c => new
                {
                    id_ciudadano = c.id_abogado_interno,
                    Ciudadano = c.ciudadano.id_ciudadano,
                    Interno = c.interno.id_interno,
                    Nombre_Abogado = c.ciudadano.apellido + c.ciudadano.nombre,
                    Nombre_Interno = c.interno.apellido + c.interno.nombre
                })
                .ToList();


            dgvListadoInternos.DataSource = datosFiltrados;
        }

        private async void btnEstablecerAbogado_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Este metodo se realiza en el formulario Administrar Datos de Ciudadano");
            MessageBox.Show("Asignar categorias Abogado");


            if (this.txtIdInterno.Text == string.Empty)
            {
                MessageBox.Show("debe seleccionar el interno, antes de vincular");
            }

            else
            {
                //NCiudadano nCiudadano = new NCiudadano();
                NAbogadoInterno nAbogadoInterno = new NAbogadoInterno();
                //List<DAbogadoInterno> listaAbogadoInterno = new List<DAbogadoInterno>();
                DAbogadoInterno listaAbogadoInterno = new DAbogadoInterno();

                var data = new
                {
                    ciudadano_id = Convert.ToInt32(txtIdAbogadoIngreso.Text),
                    interno_id = Convert.ToInt32(txtIdInterno.Text),
                    tipo_defensor_id = Convert.ToInt32(cmbTipoAbogado.SelectedValue),
                };

                string dataCiudadano = JsonConvert.SerializeObject(data);




                try
                {
                    //HttpResponseMessage httpResponse = await nCiudadanosCategorias.crearCiudadanosCategorias(dataCiudadano);
                    (DAbogadoInterno abogadoInterno, string errorResponseCiudadanosCategorias) = await nAbogadoInterno.asignarAbogadoInterno(dataCiudadano);

                    if (abogadoInterno != null)
                    {

                        MessageBox.Show("Se le asignó el abogado al interno correctamente", "Atención al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //dgvListadoInternos.DataSource = abogadoInterno;
                       

                    }
                    else
                    {
                        MessageBox.Show("Revisar codigo" + " " + txtIdAbogadoIngreso.Text + " " + Convert.ToInt32(2));
                        MessageBox.Show(errorResponseCiudadanosCategorias, "Atención al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //dgvListadoInternos.DataSource = listaAbogadoInterno;
                    }

                }
                catch (Exception ex)
                {
                    // Manejo de otros tipos de errores MySQL
                    MessageBox.Show("Error: " + ex.Message);
                }

            }
        }

        private void btnIngresarAbogado_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Los abogados ingresan por la ventana ingresos de ciudadanos");

            /*if (this.txtIdInterno.Text == string.Empty)
            {
                MessageBox.Show("debe seleccionar el interno, antes de vincular");
            }

            else
            {
                //NCiudadano nCiudadano = new NCiudadano();
                NAbogadoInterno nAbogadoInterno = new NAbogadoInterno();

                var data = new
                {
                    //novedad_detalle = txtNovedadDetalle.Text,
                    ciudadano_id = Convert.ToInt32(txtIdAbogadoIngreso.Text),
                    interno_id = Convert.ToInt32(txtIdInterno.Text),
                    tipo_defensor_id = Convert.ToInt32(cmbTipoAbogado.SelectedValue),
                };

                string dataAbogadoInterno = JsonConvert.SerializeObject(data);




                try
                {
                    //HttpResponseMessage httpResponse = await nCiudadanosCategorias.crearCiudadanosCategorias(dataCiudadano);
                    (DAbogadoInterno abogadoInternos, string errorResponseCiudadanosCategorias) = await nAbogadoInterno.asignarAbogadoInterno(dataAbogadoInterno);
                    if (abogadoInternos != null)
                    {

                        MessageBox.Show("Se le asignó el ingreso al abogado correctamente", "Atención al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Revisar codigo" + " " + txtIdAbogadoIngreso.Text + " " + Convert.ToInt32(2));
                        MessageBox.Show(errorResponseCiudadanosCategorias, "Atención al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
                catch (Exception ex)
                {
                    // Manejo de otros tipos de errores MySQL
                    MessageBox.Show("Error: " + ex.Message);
                }

            }*/



        }
    }
}
