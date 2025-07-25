﻿using CapaDatos;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaPresentacion;
using Newtonsoft.Json;
using System.Net.Http;

namespace CapaPresentacion
{
    public partial class frmRegistroDiario : Form
    {

        public int idInternoGlobal { get; set; }
        public frmRegistroDiario()
        {
            InitializeComponent();
        }

        private async void frmRegistroDiario_Load(object sender, EventArgs e)
        {
            //Carga de combo tipo de atención 
            NTipoAtencion nTipoAtencion = new NTipoAtencion();
            cmbTipoAtencion.ValueMember = "id_tipo_atencion";
            cmbTipoAtencion.DisplayMember = "tipo_atencion";
            (List<DTipoAtencion> listaTipoAtencion, string errorTipoAtencionn) = await nTipoAtencion.RetornarTipoAtencion();
            cmbTipoAtencion.DataSource = listaTipoAtencion;

            //Carga de combo tipo de acceso 
            NTipoAcceso nTipoAcceso = new NTipoAcceso();
            cmbTipoAcceso.ValueMember = "id_tipo_acceso";
            cmbTipoAcceso.DisplayMember = "tipo_acceso";
            (List<DTipoAcceso> listaTipoAcceso, string error) = await nTipoAcceso.RetornarTipoAcceso();
            cmbTipoAcceso.DataSource = listaTipoAcceso;
                        

            //Carga de combo organismo destino
            NOrganismoDestino nOrganismoDestino = new NOrganismoDestino();
            cmbOrganismoDestino.ValueMember = "id_organismo_destino";
            cmbOrganismoDestino.DisplayMember = "organismo_destino";
            List<DOrganismoDestino> listaOrganismoDestino = await nOrganismoDestino.retornarOrganismoDestinoListaxUsuario(1);
            cmbOrganismoDestino.DataSource = listaOrganismoDestino;
        }
        private void Limpiar()
        {
            this.txtIdCiudadanoIngreso.Text = string.Empty;
            this.txtDocumentoIdentidad.Text = string.Empty;
            this.txtNombreCiudadano.Text = string.Empty;
            this.txtBuscarInternos.Text = string.Empty;
            this.txtBuscarApellido.Text = string.Empty;
            this.txtBuscarInternoss.Text = string.Empty;
        }
        private async void button1_Click(object sender, EventArgs e)
        {
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
            dgvCiudadanosRegistroDiario.DataSource = datosFiltrados;
        }

        private void dgvCiudadanosRegistroDiario_KeyDown(object sender, KeyEventArgs e)
        {
            //AL PRESIONAR ENTER MOSTRAR EL TRAMITE
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                this.idInternoGlobal = 1;
                if (dgvCiudadanosRegistroDiario.SelectedRows.Count > 0)
                {
                    if (this.idInternoGlobal > 0)
                    {//inicio if

                        this.txtIdCiudadanoIngreso.Text = Convert.ToString(this.dgvCiudadanosRegistroDiario.CurrentRow.Cells["id_ciudadano"].Value);
                        this.txtDocumentoIdentidad.Text = Convert.ToString(this.dgvCiudadanosRegistroDiario.CurrentRow.Cells["dni"].Value);
                        this.txtNombreCiudadano.Text = Convert.ToString(this.dgvCiudadanosRegistroDiario.CurrentRow.Cells["apellido"].Value) + " " + Convert.ToString(this.dgvCiudadanosRegistroDiario.CurrentRow.Cells["nombre"].Value);




                    }//fin if
                    else
                    {
                        MessageBox.Show("Debe seleccionar un ciudadano.");
                    }
                }
            }
        }

        private void btnAgregarInterno_Click(object sender, EventArgs e)
        {
            frmAgregarInternos agregarInternos = new frmAgregarInternos();
            agregarInternos.ShowDialog();
        }

        private async void cmbOrganismoDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id_organismo_destino = Convert.ToInt32(this.cmbOrganismoDestino.SelectedValue);

            //Carga de combo sectores
            NSectoresDestino nSectoresDestino = new NSectoresDestino();
            cmbSector.ValueMember = "id_sector_destino";
            cmbSector.DisplayMember = "sector_destino";
            (List<DSectoresDestino> listaSectoresDestino, string errorSectoresOrganismo) = await nSectoresDestino.RetornarListaSectoresXOrganismo(Convert.ToInt32(this.cmbOrganismoDestino.SelectedValue));
            cmbSector.DataSource = listaSectoresDestino;

            //Carga de combo tmotivo de atención
            NMotivoAtencion nMotivoAtencion = new NMotivoAtencion();
            cmbMotivoAtencion.ValueMember = "id_motivo_atencion";
            cmbMotivoAtencion.DisplayMember = "motivo_atencion";
            (List<DMotivoAtencion> listaMotivoAtencion, string errorMotivoAtencion) = await nMotivoAtencion.RetornarMotivoAtencionXOrganismo(id_organismo_destino);
            cmbMotivoAtencion.DataSource = listaMotivoAtencion;

        }

        private async void btnBuscarInternos_Click(object sender, EventArgs e)
        {
            NInterno nInternos = new NInterno();
            string apellido_ciudadanos = Convert.ToString(this.txtBuscarInternoss.Text);
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
            dgvAgregarInternos.DataSource = datosFiltrados;
        }

        private void dgvAgregarInternos_KeyDown(object sender, KeyEventArgs e)
        {
            //AL PRESIONAR ENTER MOSTRAR EL TRAMITE
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                this.idInternoGlobal = 1;
                if (dgvAgregarInternos.SelectedRows.Count > 0)
                {
                    this.txtBuscarInternos.Text = Convert.ToString(this.dgvAgregarInternos.CurrentRow.Cells["apellido"].Value) + " " + Convert.ToString(this.dgvAgregarInternos.CurrentRow.Cells["nombre"].Value);
                }
                else
                {
                    MessageBox.Show("No hay internos con ese apellido en la base de datos.");
                }
                
            }
        }

        private async void btnCrearRegistroDiario_Click(object sender, EventArgs e)
        {
            NRegistroDiario nRegistroDiario = new NRegistroDiario();

            List<DRegistroDiario> listaCiudadanos = new List<DRegistroDiario>();

            //dataGridView1.DataSource = listaCiudadanos;



            var data = new
            {
                ciudadano_id = Convert.ToInt32(txtIdCiudadanoIngreso.Text),
                tipo_atencion_id = Convert.ToInt32(cmbTipoAtencion.SelectedValue.ToString()),
                tipo_acceso_id = Convert.ToInt32(cmbTipoAcceso.SelectedValue.ToString()),
                sector_destino_id = Convert.ToInt32(cmbSector.SelectedValue.ToString()),
                interno = txtBuscarInternos.Text,
                motivo_atencion_id = Convert.ToInt32(cmbMotivoAtencion.SelectedValue.ToString()),
                observaciones = Convert.ToString("Aqui se ingresa los comentarios de Atencion Ciudadano")
                
            };

            string dataRegistroDiario = JsonConvert.SerializeObject(data);

            try
            {
                //HttpResponseMessage httpResponse = await nRegistroDiario.crearRegistroDiario(dataRegistroDiario);
                (DRegistroDiario registroDiario, string errorResponseRegistroDiario) = await nRegistroDiario.crearRegistroDiario(dataRegistroDiario);

                if (registroDiario != null)
                {

                    MessageBox.Show("Se realizó correctamente el Registro", "Atención al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("Imprimir ticket");
                    //dgvListadoInternos.DataSource = abogadoInterno;


                }
                else
                {
                    MessageBox.Show("Revisar codigo");
                    MessageBox.Show(errorResponseRegistroDiario, "Atención al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //dgvListadoInternos.DataSource = listaAbogadoInterno;
                }

                /*if (httpResponse.IsSuccessStatusCode)
                {
                    var contentRespuesta = await httpResponse.Content.ReadAsStringAsync();
                    DRegistroDiario dataRespuesta = JsonConvert.DeserializeObject<DRegistroDiario>(contentRespuesta);
                    MessageBox.Show("Registro Diario creado correctamente");
                    this.Limpiar();




                    //NRegistroDiario nRegistroDiarios = new NRegistroDiario();
                    //(List<DCiudadano> listaCiudadanoss, string errorResponse) = await nCiudadanos.RetornarListaCiudadanos();
                    //if (listaCiudadanoss == null)
                    //{
                    //    MessageBox.Show(errorResponse, "Restricion Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    return;
                    //}
                    //dataGridView1.DataSource = listaCiudadanoss;

                }
                else
                {
                    string errorMessage = await httpResponse.Content.ReadAsStringAsync();
                    MessageBox.Show("No se pudo insertar el registro.");
                    MessageBox.Show($"Error de la API: {errorMessage}", $"Error {httpResponse.StatusCode}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }*/

            }
            catch (Exception ex)
            {
                // Manejo de otros tipos de errores MySQL
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private async void txtBuscarApellido_KeyDown(object sender, KeyEventArgs e)
        {
            //AL PRESIONAR ENTER MOSTRAR EL TRAMITE
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

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
                dgvCiudadanosRegistroDiario.DataSource = datosFiltrados;
            }
        }

        private void btnIngresoAbogados_Click(object sender, EventArgs e)
        {
            
            int idCiudadano;
            int dniCiudadano;
            string nombreCiudadano;
            idCiudadano = Convert.ToInt32(dgvCiudadanosRegistroDiario.CurrentRow.Cells["id_ciudadano"].Value.ToString());
            dniCiudadano = Convert.ToInt32(dgvCiudadanosRegistroDiario.CurrentRow.Cells["dni"].Value.ToString());
            nombreCiudadano = dgvCiudadanosRegistroDiario.CurrentRow.Cells["Apellido"].Value.ToString() + " " + dgvCiudadanosRegistroDiario.CurrentRow.Cells["Nombre"].Value.ToString(); ; 
            MessageBox.Show(Convert.ToString(idCiudadano));
            if (this.txtDniCiudadanoIngreso.Text == string.Empty)
            {
                MessageBox.Show("Debe seleccionar un Ciudadano");   
            }
            else
            {

                if (dgvCiudadanosRegistroDiario.SelectedRows.Count > 0)
                {
                    if (idCiudadano > 0)
                    {
                        frmIngresoAbogados ingresoAbogados = new frmIngresoAbogados();
                        AddOwnedForm(ingresoAbogados);
                        ingresoAbogados.txtIdAbogadoIngreso.Text = Convert.ToString(idCiudadano);
                        ingresoAbogados.txtDniAbogado.Text = Convert.ToString(dniCiudadano);
                        ingresoAbogados.txtNombreAbogado.Text = nombreCiudadano;
                        ingresoAbogados.ShowDialog();


                        //frmRegistroDiario registroDiario = new frmRegistroDiario();
                        //AddOwnedForm(registroDiario);
                        //registroDiario.txtBuscarInternos.Text = Convert.ToString(this.dgvDatosInternos.CurrentRow.Cells["apellido"].Value);
                        //MessageBox.Show(Convert.ToString(this.dgvDatosInternos.CurrentRow.Cells["apellido"].Value));
                        //registroDiario.Show();
                        //this.Close();







                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar un ciudadano.");
                    }
                }

            }
        }
    }
}
