using CapaDatos;
using CapaNegocio;
using CapaPresentacion.Validaciones.AdministrarCiudadano.Datos;
using CapaPresentacion.Validaciones.AdministrarCiudadano.ValidacionCiudadano;
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
    public partial class frmAdministrarCiudadadno : Form
    {
        //VARIABLES GLOBALES
        //private bool isNuevo = false;

        private bool isEditar = false;
        private bool valor = false;
        public int idInternoGlobal { get; set; }


        DCiudadano dCiudadano = new DCiudadano();
        DInterno dInterno = new DInterno();

        //para validaciones
        private ErrorProvider errorProvider = new ErrorProvider();

        public frmAdministrarCiudadadno()
        {
            InitializeComponent();
        }


        //hobilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.txtApellido.ReadOnly = !valor;
            this.txtNombre.ReadOnly = !valor;
            this.txtDni.ReadOnly = !valor;
            this.cmbSexo.Enabled = !valor;
            this.cmbEstadoCivil.Enabled = !valor;
            this.txtTelefono.ReadOnly = !valor;
            this.cmbNacionalidad.Enabled = !valor;
            this.cmbPais.Enabled = !valor;
            this.cmbProvincia.Enabled = !valor;
            this.cmbDepartamento.Enabled = !valor;
            this.cmbMunicipio.Enabled = !valor;
            this.txtCiudad.ReadOnly = !valor;
            this.txtBarrio.ReadOnly = !valor;
            this.txtDireccion.ReadOnly = !valor;
            
        }

        //habilitar los botones
        private void Botones()
        {
            if (this.isEditar)
            {
                this.Habilitar(true);
                //this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                //this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }
        }



        private void habilitarPropiedades()
        {
            this.btnGuardar.Enabled = false;
            this.btnCancelar.Enabled = false;
        }

        //Habilitar los controles del formualrio editar
        private void HabilitarControlesDatosPersonales(bool valor)
        {
            this.txtApellido.Enabled = valor;
            this.txtNombre.Enabled = valor;
            this.txtDni.Enabled = valor;
            this.cmbSexo.Enabled = valor;
            this.dtpFechaNacimiento.Enabled = valor;
            this.cmbEstadoCivil.Enabled = valor;
            this.txtTelefono.Enabled = valor;
            this.cmbNacionalidad.Enabled = valor;
            this.txtDetalleMotivo.Enabled = valor;

        }

        private void HabilitarControlesDatosDomicilio(bool valor)
        {
            this.cmbPais.Enabled = valor;
            this.cmbProvincia.Enabled = valor;
            this.cmbDepartamento.Enabled = valor;
            this.cmbMunicipio.Enabled = valor;
            this.txtCiudad.Enabled = valor;
            this.txtBarrio.Enabled = valor;
            this.txtDireccion.Enabled = valor;
            this.txtDomicilio.Enabled = valor;
            this.txtDetalleDomicilio.Enabled = valor;
            
        }



        private async void btnGuardar_Click(object sender, EventArgs e)
        {//incio boton edicion

            MessageBox.Show("boton guardar cambios en editar");

            NCiudadano nCiudadano = new NCiudadano();

            //limpiar errores de provider
            errorProvider.Clear();

            //validacion de formulario
            var datosFormulario = new CiudadanoDatos
            {
                txtDni = txtDni.Text,
                txtApellido = txtApellido.Text,
                txtNombre = txtNombre.Text,
                dtpickFechaNacimiento = dtpFechaNacimiento.Value,
                cmbSexo = Convert.ToInt32(cmbSexo.SelectedValue.ToString()),
                cmbEstadoCivil = Convert.ToInt32(cmbEstadoCivil.SelectedValue.ToString()),
                txtTelefono = txtTelefono.Text,
                cmbNacionalidad = cmbNacionalidad.SelectedValue.ToString(),                
                txtDetalleMotivo = txtDetalleMotivo.Text,
            };

            var validator = new EditarDPersonalesCiudadanoValidator();
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
            //FIN VALIDAR

            var data = new
            {

                dni = Convert.ToInt32(txtDni.Text),
                apellido = txtApellido.Text,
                nombre = txtNombre.Text,
                sexo_id = Convert.ToInt32(cmbSexo.SelectedValue.ToString()),
                estado_civil_id = Convert.ToInt32(cmbEstadoCivil.SelectedValue.ToString()),
                telefono = txtTelefono.Text,
                fecha_nac = dtpFechaNacimiento.Value,
                nacionalidad_id = Convert.ToString(cmbNacionalidad.SelectedValue.ToString()),
                detalle_motivo = txtDetalleMotivo.Text,


            };

            string dataCiudadano = JsonConvert.SerializeObject(data);

            try
            {
                HttpResponseMessage httpResponse = await nCiudadano.editarDatosPersonales(Convert.ToInt32(txtIdCiudadano.Text), dataCiudadano);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var contentRespuesta = await httpResponse.Content.ReadAsStringAsync();
                    MessageBox.Show("La edición de datos del ciudadano se realizó corectamente");

                    HabilitarControlesDatosPersonales(false);

                    //buscar y actualizar el ciudadano this.dCiudadano
                    (DCiudadano dCiudadano2, string errorResponse) = await nCiudadano.BuscarCiudadanoXID(Convert.ToInt32(txtIdCiudadano.Text));

                    this.dCiudadano = dCiudadano2;

                    if (this.dCiudadano == null)
                    {
                        MessageBox.Show(errorResponse, "Atención al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
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
        

    }//fin boton guardar edicion

        private async void frmAdministrarCiudadadno_Load(object sender, EventArgs e)
        {//Inicio evento Load

            int idCiudadano;
            //acceder a la instancia de FormTramites abierta.
            CiudadanoNuevo FCiudadanoNuevoDatos = Application.OpenForms["CiudadanoNuevo"] as CiudadanoNuevo;
            CiudadanoNuevo ciudadanoNuevos = new CiudadanoNuevo();
            idCiudadano = Convert.ToInt32(FCiudadanoNuevoDatos.idCiudadanoGlobal);
            
            NCiudadano nCiudadano = new NCiudadano();
            (DCiudadano dCiudadano2, string errorResponse) = await nCiudadano.BuscarCiudadanoXID(idCiudadano);
            
            this.dCiudadano = dCiudadano2;

            if (this.dCiudadano == null)
            {
                MessageBox.Show(errorResponse, "Atención al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Carga de combo sexo 
            NSexo nSexo = new NSexo();
            cmbSexo.ValueMember = "id_sexo";
            cmbSexo.DisplayMember = "sexo";
            (List<DSexo> listaSexo, string errorResponseSexo) = await nSexo.RetornarListaSexo();
            cmbSexo.DataSource = listaSexo;

            //Carga de combo nacionalidad
            NNacionalidad nNacionalidad = new NNacionalidad();
            cmbNacionalidad.ValueMember = "id_nacionalidad";
            cmbNacionalidad.DisplayMember = "nacionalidad";
            (List<DNacionalidad> listaNacionalidad, string errorRespnse) = await nNacionalidad.RetornarListaNacionalidad();
            cmbNacionalidad.DataSource = listaNacionalidad;

            //Carga de combo pais
            NPais nPais = new NPais();
            cmbPais.ValueMember = "id_pais";
            cmbPais.DisplayMember = "pais";
            (List<DPais> listaPais, string error) = await nPais.RetornarListaPais();
            cmbPais.DataSource = listaPais;

            //Carga de combo provincia
            NProvincia nProvincia = new NProvincia();
            string id_paiss = Convert.ToString(this.dCiudadano.pais_id);
            cmbProvincia.ValueMember = "id_provincia";
            cmbProvincia.DisplayMember = "provincia";
            (List<DProvincia> listaProvincia, string errorResponseProvincia) = await nProvincia.RetornarListaProvinciasXPais(id_paiss);
            cmbProvincia.DataSource = listaProvincia;
           

            //Carga de combo estado civil
            NEstadoCivil nEstadoCivil = new NEstadoCivil();

            cmbEstadoCivil.ValueMember = "id_estado_civil";
            cmbEstadoCivil.DisplayMember = "estado_civil";
            (List<DEstadoCivil> listaEstadoCivil, string errorResponseEstadoCivil) = await nEstadoCivil.RetornarListaEstadoCivil();
            Console.WriteLine(listaEstadoCivil);

            cmbEstadoCivil.DataSource = listaEstadoCivil;


            
            //DCiudadano dCiudadano = new DCiudadano();
            //habilitar();
           

            txtIdCiudadano.Text = Convert.ToString(this.dCiudadano.id_ciudadano);
            txtApellido.Text = this.dCiudadano.apellido;
            txtNombre.Text = this.dCiudadano.nombre;
            txtDni.Text = this.dCiudadano.dni.ToString();
            cmbSexo.Text = this.dCiudadano.sexo.sexo;
            dtpFechaNacimiento.Text = this.dCiudadano.fecha_nac.ToShortDateString();
            cmbEstadoCivil.Text = this.dCiudadano.estado_civil.estado_civil;
            txtTelefono.Text = this.dCiudadano.telefono;
            cmbNacionalidad.Text = this.dCiudadano.nacionalidad.nacionalidad;
            cmbPais.Text = this.dCiudadano.pais.pais;
            cmbProvincia.Text = this.dCiudadano.provincia.provincia;
            cmbDepartamento.Text = this.dCiudadano.departamento.departamento;
            cmbMunicipio.Text = this.dCiudadano.municipio.municipio;
            txtCiudad.Text = this.dCiudadano.ciudad;
            txtBarrio.Text = this.dCiudadano.barrio;
            txtDireccion.Text = this.dCiudadano.direccion;
            txtDomicilio.Text = Convert.ToString(this.dCiudadano.numero_dom);
            //txtCategoriaCiudadano.Text = Convert.ToString(this.dCiudadano.categoria_ciudadano);
            //MessageBox.Show(Convert.ToString("numero de categoria es: " + this.dCiudadano.categoria_ciudadano));
            pictureFoto.Load(this.dCiudadano.foto);





        }//Fin evento Load

        

        private void btnEditar_Click(object sender, EventArgs e)
        {
                //valor = true;
                this.btnGuardar.Enabled = true;
                this.btnCancelar.Enabled = true;
                HabilitarControlesDatosPersonales(true);
               //Habilitar_Controles(true);

        }

        async void cmbPais_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbPais.Enabled == true)
            {
                //Carga de combo provincia
                NProvincia nProvincia = new NProvincia();
                string id_paiss = Convert.ToString(this.cmbPais.SelectedValue);
                cmbProvincia.ValueMember = "id_provincia";
                cmbProvincia.DisplayMember = "provincia";
                (List<DProvincia> listaProvincia, string errorResponseListaProvincia) = await nProvincia.RetornarListaProvinciasXPais(id_paiss);
                cmbProvincia.DataSource = listaProvincia;
                
            }
        }

        async void cmbProvincia_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if(cmbProvincia.Enabled == true)
            {
                //Carga de combo departamento
                NDepartamento nDepartamento = new NDepartamento();
                string provincia_identificador = Convert.ToString(this.cmbProvincia.SelectedValue);
                cmbDepartamento.ValueMember = "id_departamento";
                cmbDepartamento.DisplayMember = "departamento";
                (List<Departamento> listaDepartamento, string errorResponseDepartamento) = await nDepartamento.RetornarListaDepartamentoXProvincia(provincia_identificador);
                cmbDepartamento.DataSource = listaDepartamento;
            }
        }

        async void cmbDepartamento_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if(cmbDepartamento.Enabled == true)
            {
                //Carga de combo departamento
                NMunicipio nMunicipio = new NMunicipio();
                int departamento_identificador = Convert.ToInt32(this.cmbDepartamento.SelectedValue);
                cmbMunicipio.ValueMember = "id_municipio";
                cmbMunicipio.DisplayMember = "municipio";
                (List<DMunicipio> listaMunicipio, string errorResponseMunicipio) = await nMunicipio.RetornarListaMunicipioXDepartamento(departamento_identificador);
                cmbMunicipio.DataSource = listaMunicipio;
            }
            
        }

        private void cmbPais_SelectedIndexChanged_2(object sender, EventArgs e)
        {
            MessageBox.Show("Presiono el boton combobox pais 2");
        }

        async private void btnVincular_Click(object sender, EventArgs e)
        {
            if (this.txtIdCiudadano.Text == string.Empty)
            {
                MessageBox.Show("debe esperar que cargue los datos del ciudadano");
            }
            else
            {
                NVisitaInterno nVisitaInterno = new NVisitaInterno();
                (List <DVisitaInterno> listaVisitasInternos, string errorResponse) = await nVisitaInterno.retornarListaVisitaInternoXCiudadano(Convert.ToInt32(this.txtIdCiudadano.Text));

                if (listaVisitasInternos == null)
                {
                    MessageBox.Show(errorResponse, "Atención al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                NParentesco nInterno = new NParentesco();
                //List<DParentesco> listaParentescos = new List<DParentesco>();
                (List<DParentesco> listaParentescos, string errorResponseParentesco) = await nInterno.retornarListaParentesco();

                var datosFiltrados = listaVisitasInternos
                .Select(c => new
                {
                    //ciudadano_id = c.ciudadano_id,
                    apellido_visita = this.txtApellido.Text,
                    nombre_visita = this.txtNombre.Text,
                    interno_id = c.interno_id,
                    apellido_interno = c.interno.apellido,
                    nombre_interno = c.interno.nombre,
                    prontuario = c.interno.prontuario,
                    parentesco = c.parentesco.parentesco

                })
                .ToList();


                dgvVisitasVinculadas.DataSource = datosFiltrados;

                //Carga de combo parentesco
                NParentesco nParentesco = new NParentesco();
               
                cmbParentesco.ValueMember = "id_parentesco";
                cmbParentesco.DisplayMember = "parentesco";
                (List<DParentesco> listaParentesco, string errorResponseParentescos) = await nParentesco.retornarListaParentesco();
                cmbParentesco.DataSource = listaParentesco;

                this.txtDocumentoVisita.Text = txtDni.Text;
                this.txtIdVisita.Text = txtIdCiudadano.Text;
                this.tabControl1.SelectedIndex = 1;

            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CiudadanoNuevo FrmCiudadanoNuevo = new CiudadanoNuevo();
            this.Close();
            FrmCiudadanoNuevo.ShowDialog();
            
        }

        private async void btnBuscarInterno_Click(object sender, EventArgs e)
        {
            NInterno nInternos = new NInterno();
            string apellido_ciudadanos = Convert.ToString(this.txtBuscarApellidoInternos.Text);
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

            dtvInternos.DataSource = datosFiltrados;
        }

        private async void dtvInternos_KeyDown(object sender, KeyEventArgs e)
        {
            
            //AL PRESIONAR ENTER MOSTRAR EL TRAMITE
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                
                this.idInternoGlobal = 1;
                if (dtvInternos.SelectedRows.Count > 0)
                {
                    if (this.idInternoGlobal > 0)
                    {//inicio if
                                                
                        this.txtProntuario.Text = Convert.ToString(this.dtvInternos.CurrentRow.Cells["prontuario"].Value);
                        this.txtIdInterno.Text = Convert.ToString(this.dtvInternos.CurrentRow.Cells["id_interno"].Value);
                                                 this.tabControl1.SelectedIndex = 1;




                    }//fin if
                    else
                    {
                        MessageBox.Show("Debe seleccionar un ciudadano.");
                    }
                }
            }
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {//inicio de boton crear parentesco

            if (this.txtIdInterno.Text == string.Empty) 
            {
                MessageBox.Show("debe seleccionar el interno, antes de vincular");
            }
            else
            {
                NVisitaInterno nVisitaInterno = new NVisitaInterno();

                List<DVisitaInterno> listaVisitaInterno = new List<DVisitaInterno>();

                //30diceimbre2024 dgvVisitasVinculadas.DataSource = listaVisitaInterno;



                var data = new
                {
                    ciudadano_id = Convert.ToInt32(txtIdVisita.Text),
                    interno_id = Convert.ToInt32(txtIdInterno.Text),
                    parentesco_id = Convert.ToString(cmbParentesco.SelectedValue.ToString()),
                    

                };
                //MessageBox.Show(Convert.ToString(cmbParentesco.SelectedValue.ToString()));
                string dataVisitaInterno = JsonConvert.SerializeObject(data);

                try
                {
                    (DVisitaInterno visitaInterno, string errorResponseVisitaInterno) = await nVisitaInterno.crearVisitaInterno(dataVisitaInterno);

                    if (visitaInterno != null)
                    {
                        MessageBox.Show("La vinculación se realizó correctamente", "Atención al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //var contentRespuesta = await httpResponse.Content.ReadAsStringAsync();
                        //DVisitaInterno dataRespuesta = JsonConvert.DeserializeObject<DVisitaInterno>(contentRespuesta);
                        //MessageBox.Show("Parentesco creado correctamente" + dataRespuesta);
                        ////this.Limpiar();
                        NVisitaInterno nVisitaInternoActual = new NVisitaInterno();
                        //List<DVisitaInterno> listaVisitasInternosActual = new List<DVisitaInterno>();
                        (List < DVisitaInterno > listaVisitasInternosActual, string errorResponseVisitasInternos) = await nVisitaInterno.retornarListaVisitaInternoXCiudadano(Convert.ToInt32(this.txtIdCiudadano.Text));

                        NParentesco nInterno = new NParentesco();
                        List<DParentesco> listaParentescos = new List<DParentesco>();
                        (List<DParentesco> listaParentescoss, string errorResponse) = await nInterno.retornarListaParentesco();







                        var datosFiltrados = listaVisitasInternosActual
                        .Select(c => new
                        {
                            //ciudadano_id = c.ciudadano_id,
                            apellido_visita = this.txtApellido.Text,
                            nombre_visita = this.txtNombre.Text,
                            interno_id = c.interno_id,
                            apellido_interno = c.interno.apellido,
                            nombre_interno = c.interno.nombre,
                            prontuario = c.interno.prontuario,
                            parentesco = c.parentesco.parentesco

                        })
                        .ToList();


                        dgvVisitasVinculadas.DataSource = datosFiltrados;

                    }
                    else
                    {
                        MessageBox.Show("Revisar codigo" + " " + txtIdCioudadanoCategoria.Text + " " + Convert.ToInt32(2));
                        MessageBox.Show(errorResponseVisitaInterno, "Atención al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }


                }
                catch (Exception ex)
                {
                    // Manejo de otros tipos de errores MySQL
                    MessageBox.Show("Error: " + ex.Message);
                }

            }




        }//fin boton crear parentesco

        private async void btnGuardarDomicilio_Click(object sender, EventArgs e)
        {

            NCiudadano nCiudadano = new NCiudadano();

            //limpiar errores de provider
            errorProvider.Clear();

            //validacion de formulario
            var datosFormulario = new CiudadanoDatos
            {
                
                cmbPais = cmbPais.SelectedValue.ToString(),
                cmbProvincia = cmbProvincia.SelectedValue.ToString(),
                cmbDepartamento = cmbDepartamento.SelectedValue.ToString(),
                cmbMunicipio = cmbMunicipio.SelectedValue.ToString(),
                txtCiudad = txtCiudad.Text,
                txtBarrio = txtBarrio.Text,
                txtDireccion = txtDireccion.Text,
                txtNumeroDominio = txtDomicilio.Text,
                txtDetalleDomicilio = txtDetalleDomicilio.Text,
            };

            var validator = new EditarDDomicilioCiudadanoValidator();
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

            var data = new
            {
                
                pais_id = cmbPais.SelectedValue.ToString(),
                provincia_id = cmbProvincia.SelectedValue.ToString(),
                departamento_id = Convert.ToInt32(cmbDepartamento.SelectedValue.ToString()),
                municipio_id = Convert.ToInt32(cmbMunicipio.SelectedValue.ToString()),
                ciudad = txtCiudad.Text,
                barrio = txtBarrio.Text,
                direccion = txtDireccion.Text,
                numero_dom = Convert.ToInt32(txtDomicilio.Text),
                detalle_motivo = txtDetalleDomicilio.Text,


            };

            string dataCiudadano = JsonConvert.SerializeObject(data);

            try
            {
                HttpResponseMessage httpResponse = await nCiudadano.editarCiudadanoDni(Convert.ToInt32(txtIdCiudadano.Text), dataCiudadano);
                
                if (httpResponse.IsSuccessStatusCode)
                {
                    var contentRespuesta = await httpResponse.Content.ReadAsStringAsync();
                    MessageBox.Show("La edición de datos del ciudadano se realizó corectamente");
                    //this.Limpiar();

                    (DCiudadano dCiudadano2, string errorResponse) = await nCiudadano.BuscarCiudadanoXID(Convert.ToInt32(txtIdCiudadano.Text));

                    this.dCiudadano = dCiudadano2;

                    if (this.dCiudadano == null)
                    {
                        MessageBox.Show(errorResponse, "Atención al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

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

        private async void btnEditarDomicilio_Click(object sender, EventArgs e)
        {
            //Carga de combo departamento
            NDepartamento nDepartamento = new NDepartamento();
            string provincia_identificador = Convert.ToString(this.cmbProvincia.SelectedValue);
            cmbDepartamento.ValueMember = "id_departamento";
            cmbDepartamento.DisplayMember = "departamento";
            (List<Departamento> listaDepartamento, string errorResponseDepartamento) = await nDepartamento.RetornarListaDepartamentoXProvincia(provincia_identificador);
            cmbDepartamento.DataSource = listaDepartamento;
            cmbDepartamento.Text = this.dCiudadano.departamento.departamento;

            //Carga de combo departamento
            NMunicipio nMunicipio = new NMunicipio();
            int departamento_identificador = Convert.ToInt32(this.cmbDepartamento.SelectedValue);
            cmbMunicipio.ValueMember = "id_municipio";
            cmbMunicipio.DisplayMember = "municipio";
            (List<DMunicipio> listaMunicipio, string errorResponseMunicipio) = await nMunicipio.RetornarListaMunicipioXDepartamento(departamento_identificador);
            cmbMunicipio.DataSource = listaMunicipio;

            cmbMunicipio.Text = this.dCiudadano.municipio.municipio;

            HabilitarControlesDatosDomicilio(true);
        }

        private async void btnVincularVisitas_Click(object sender, EventArgs e)
        {
            if (this.txtIdCiudadano.Text == string.Empty)
            {
                MessageBox.Show("debe esperar que cargue los datos del ciudadano");
            }
            else
            {

                NVisitaInterno nVisitaInterno = new NVisitaInterno();
                //List<DVisitaInterno> listaVisitasInternos = new List<DVisitaInterno>();
                (List<DVisitaInterno> listaVisitasInternos, string errorResponseVisitaInternos) = await nVisitaInterno.retornarListaVisitaInternoXCiudadano(Convert.ToInt32(this.txtIdCiudadano.Text));

                NParentesco nInterno = new NParentesco();
                //List<DParentesco> listaParentescos = new List<DParentesco>();
                (List<DParentesco> listaParentescos, string errorResponseParentescos) = await nInterno.retornarListaParentesco();
            }

            this.txtIdCiuadanoVincularvisita.Text = txtIdCiudadano.Text;
            this.txtDniVisita.Text = txtDni.Text;
            this.txtNombreVisita.Text = txtIdCiudadano.Text;
            this.tabControl1.SelectedIndex = 3;
            

        }

        private async void btnAsignarVisita_Click(object sender, EventArgs e)
        {//inicio del boton asignar visitas
            if (this.txtIdCiuadanoVincularvisita.Text == string.Empty)
            {
                MessageBox.Show("debe seleccionar el interno, antes de vincular");
            }

            else
            {
                NCiudadano nCiudadano = new NCiudadano();

                var data = new
                {
                    novedad_detalle = txtNovedadDetalle.Text,
                };

                string dataCiudadano = JsonConvert.SerializeObject(data);




                try
                {
                    HttpResponseMessage httpResponse = await nCiudadano.establecerVisita(Convert.ToInt32(txtIdCiuadanoVincularvisita.Text), dataCiudadano);

                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var contentRespuesta = await httpResponse.Content.ReadAsStringAsync();
                        MessageBox.Show("La vinculación de la visita se realizó correctamente");
                        //this.Limpiar();

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


        }//fin del boton asignar visitas

        private async void btnEstablecerDiscapacidad_Click(object sender, EventArgs e)
        {
                NCiudadano nCiudadano = new NCiudadano();

                var data = new
                {
                    novedad_detalle = txtEstablecerDiscapacidad.Text,
                };

                string dataCiudadano = JsonConvert.SerializeObject(data);
                try
                {
                    HttpResponseMessage httpResponse = await nCiudadano.establecerVisita(Convert.ToInt32(txtIdCiuadanoVincularvisita.Text), dataCiudadano);

                    if (httpResponse.IsSuccessStatusCode)
                    {
                        var contentRespuesta = await httpResponse.Content.ReadAsStringAsync();
                        MessageBox.Show("Se estableció la visita con discapacidad con acompañante en forma correcta");
                        //this.Limpiar();

                    }
                    else
                    {
                        string errorMessage = await httpResponse.Content.ReadAsStringAsync();
                        MessageBox.Show("No se pudo establecer la visita con acompañante.");
                        MessageBox.Show($"Error de la API: {errorMessage}", $"Error {httpResponse.StatusCode}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {
                    // Manejo de otros tipos de errores MySQL
                    MessageBox.Show("Error: " + ex.Message);
                }

        }

        private async void btnIngreso_Click(object sender, EventArgs e)
        {
            
            this.tabControl1.SelectedIndex = 2;
        }

       

        private void btnAgregarInterno_Click(object sender, EventArgs e)
        {
            AgregarInternos agregarInternos = new AgregarInternos();
            agregarInternos.Show();
        }

        private void cmbOrganismoDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Carga de combo provincia
            //NProvincia nProvincia = new NProvincia();
            //string id_paiss = Convert.ToString(this.cmbPais.SelectedValue);
            //cmbProvincia.ValueMember = "id_provincia";
            //cmbProvincia.DisplayMember = "provincia";
            //List<DProvincia> listaProvincia = await nProvincia.RetornarListaProvinciasXPais(id_paiss);
            //cmbProvincia.DataSource = listaProvincia;
        }

        private async void btnAsignarCategorias_Click(object sender, EventArgs e)
        {
             
            if (this.txtIdCiudadano.Text == string.Empty)
            {
                MessageBox.Show("debe esperar que cargue los datos del ciudadano");
            }
            else
            {

                NVisitaInterno nVisitaInterno = new NVisitaInterno();
                //List<DVisitaInterno> listaVisitasInternos = new List<DVisitaInterno>();
                (List<DVisitaInterno> listaVisitasInternos, string errorResponseVisitaInternoss) = await nVisitaInterno.retornarListaVisitaInternoXCiudadano(Convert.ToInt32(this.txtIdCiudadano.Text));

                NParentesco nInterno = new NParentesco();
                //List<DParentesco> listaParentescos = new List<DParentesco>();
                (List<DParentesco> listaParentescos, string errorResponseParentesco) = await nInterno.retornarListaParentesco();



            }
            

            //Carga de combo categorias
            NCategoriasCiudadano nCategoriasCiudadano = new NCategoriasCiudadano();
            cmbCategorias.ValueMember = "id_categoria_ciudadano";
            cmbCategorias.DisplayMember = "categoria_ciudadano";
            (List<DCategoriasCiudadano> listaCategoriasCiudadanos, string response) = await nCategoriasCiudadano.RetornarListaCategoriasCiudadano();
            cmbCategorias.DataSource = listaCategoriasCiudadanos;




            NCategoriasCiudadano nCategoriasCiuddano = new NCategoriasCiudadano();
            //string apellido_ciudadanos = Convert.ToString(this.txtBuscarApellido.Text);
            (List<DCategoriasCiudadano> listaCategorias, string errorResponse) = await nCategoriasCiuddano.RetornarListaCategoriasCiudadano();
            if (listaCategorias == null)
            {
                MessageBox.Show(errorResponse, "Atención al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var datosFiltrados = listaCategorias
                .Select(c => new
                {
                    id_categorias_ciudadano = c.id_categoria_ciudadano,
                    Catgegorias = c.categoria_ciudadano
                    
                })
                .ToList();


            //dgvCategoriasCiudadano.DataSource = datosFiltrados;



            this.txtIdCioudadanoCategoria.Text = txtIdCiudadano.Text;
            this.txtDniCiudadanoCategoria.Text = txtDni.Text;
            this.txtNombnreCiudadanoCategoria.Text = txtApellido.Text + " " + txtNombre.Text; 
            this.tabControl1.SelectedIndex = 4;


    }

        private async void btnCrearCiudadanosCategorias_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Asignar categorias Abogado");
            
            
             if (this.txtIdCioudadanoCategoria.Text == string.Empty)
            {
                MessageBox.Show("debe seleccionar la visita, antes de vincular");
            }

            else
            {
                //NCiudadano nCiudadano = new NCiudadano();
                NCiuddanosCategorias nCiudadanosCategorias = new NCiuddanosCategorias();

                var data = new
                {
                    //novedad_detalle = txtNovedadDetalle.Text,
                    ciudadano_id = Convert.ToInt32(txtIdCioudadanoCategoria.Text),
                    //categoria_ciudadano_id = Convert.ToInt32(2),
                    categoria_ciudadano_id = Convert.ToString(cmbParentesco.SelectedValue.ToString()),
                };

                string dataCiudadano = JsonConvert.SerializeObject(data);




                try
                {
                    //HttpResponseMessage httpResponse = await nCiudadanosCategorias.crearCiudadanosCategorias(dataCiudadano);
                    (DCiudadanosCategorias ciudadanosCategoria, string errorResponseCiudadanosCategorias) = await nCiudadanosCategorias.crearCiudadanosCategorias(dataCiudadano);

                    if (ciudadanosCategoria != null)
                    {
                        
                        MessageBox.Show("Se le asignó la categoria al ciudadano correctamente", "Atención al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Revisar codigo" + " "  + txtIdCioudadanoCategoria.Text + " " + Convert.ToInt32(2));
                        MessageBox.Show(errorResponseCiudadanosCategorias, "Atención al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
                catch (Exception ex)
                {
                    // Manejo de otros tipos de errores MySQL
                    MessageBox.Show("Error: " + ex.Message);
                }

            }
            




        }

        //Cancelar Edicion Datos Personales
        private void button2_Click(object sender, EventArgs e)
        {
            txtIdCiudadano.Text = Convert.ToString(this.dCiudadano.id_ciudadano);
            txtApellido.Text = this.dCiudadano.apellido;
            txtNombre.Text = this.dCiudadano.nombre;
            txtDni.Text = this.dCiudadano.dni.ToString();
            cmbSexo.Text = this.dCiudadano.sexo.sexo;
            dtpFechaNacimiento.Text = this.dCiudadano.fecha_nac.ToShortDateString();
            cmbEstadoCivil.Text = this.dCiudadano.estado_civil.estado_civil;
            txtTelefono.Text = this.dCiudadano.telefono;
            cmbNacionalidad.Text = this.dCiudadano.nacionalidad.nacionalidad;
            cmbPais.Text = this.dCiudadano.pais.pais;
            cmbProvincia.Text = this.dCiudadano.provincia.provincia;
            cmbDepartamento.Text = this.dCiudadano.departamento.departamento;
            cmbMunicipio.Text = this.dCiudadano.municipio.municipio;
            txtCiudad.Text = this.dCiudadano.ciudad;
            txtBarrio.Text = this.dCiudadano.barrio;
            txtDireccion.Text = this.dCiudadano.direccion;
            txtDomicilio.Text = Convert.ToString(this.dCiudadano.numero_dom);

            HabilitarControlesDatosPersonales(false);
        }
        //Fin Cancelar Edicion Datos Personales........................................

        //Cancelar Edicion Domicilio
        private void button3_Click(object sender, EventArgs e)
        {
            txtIdCiudadano.Text = Convert.ToString(this.dCiudadano.id_ciudadano);
            txtApellido.Text = this.dCiudadano.apellido;
            txtNombre.Text = this.dCiudadano.nombre;
            txtDni.Text = this.dCiudadano.dni.ToString();
            cmbSexo.Text = this.dCiudadano.sexo.sexo;
            dtpFechaNacimiento.Text = this.dCiudadano.fecha_nac.ToShortDateString();
            cmbEstadoCivil.Text = this.dCiudadano.estado_civil.estado_civil;
            txtTelefono.Text = this.dCiudadano.telefono;
            cmbNacionalidad.Text = this.dCiudadano.nacionalidad.nacionalidad;
            cmbPais.Text = this.dCiudadano.pais.pais;
            cmbProvincia.Text = this.dCiudadano.provincia.provincia;
            cmbDepartamento.Text = this.dCiudadano.departamento.departamento;
            cmbMunicipio.Text = this.dCiudadano.municipio.municipio;
            txtCiudad.Text = this.dCiudadano.ciudad;
            txtBarrio.Text = this.dCiudadano.barrio;
            txtDireccion.Text = this.dCiudadano.direccion;
            txtDomicilio.Text = Convert.ToString(this.dCiudadano.numero_dom);
        }
        //Fin Cancelar Edicion Domicilio...........................

        private async void btnActualizarPestañaVinculacion_Click(object sender, EventArgs e)
        {
            if (this.txtIdCiudadano.Text == string.Empty)
            {
                MessageBox.Show("debe esperar que cargue los datos del ciudadano");
            }
            else
            {
                NVisitaInterno nVisitaInterno = new NVisitaInterno();
                (List<DVisitaInterno> listaVisitasInternos, string errorResponse) = await nVisitaInterno.retornarListaVisitaInternoXCiudadano(Convert.ToInt32(this.txtIdCiudadano.Text));

                if (listaVisitasInternos == null)
                {
                    MessageBox.Show(errorResponse, "Atención al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                NParentesco nInterno = new NParentesco();
                //List<DParentesco> listaParentescos = new List<DParentesco>();
                (List<DParentesco> listaParentescos, string errorResponseParentesco) = await nInterno.retornarListaParentesco();

                var datosFiltrados = listaVisitasInternos
                .Select(c => new
                {
                    //ciudadano_id = c.ciudadano_id,
                    apellido_visita = this.txtApellido.Text,
                    nombre_visita = this.txtNombre.Text,
                    interno_id = c.interno_id,
                    apellido_interno = c.interno.apellido,
                    nombre_interno = c.interno.nombre,
                    prontuario = c.interno.prontuario,
                    parentesco = c.parentesco.parentesco

                })
                .ToList();


                dgvVisitasVinculadas.DataSource = datosFiltrados;






                //Carga de combo parentesco
                NParentesco nParentesco = new NParentesco();


                cmbParentesco.ValueMember = "id_parentesco";
                cmbParentesco.DisplayMember = "parentesco";
                (List<DParentesco> listaParentesco, string errorResponseParentescos) = await nParentesco.retornarListaParentesco();
                cmbParentesco.DataSource = listaParentesco;







                this.txtDocumentoVisita.Text = txtDni.Text;
                this.txtIdVisita.Text = txtIdCiudadano.Text;
                this.tabControl1.SelectedIndex = 1;

            }
        }

        private async void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private async void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private async void btnActualizarDatos_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Boton nuevo");
            if (this.txtIdCiudadano.Text == string.Empty)
            {
                MessageBox.Show("debe esperar que cargue los datos del ciudadano");
            }
            else
            {

                NVisitaInterno nVisitaInterno = new NVisitaInterno();
                //List<DVisitaInterno> listaVisitasInternos = new List<DVisitaInterno>();
                (List<DVisitaInterno> listaVisitasInternos, string errorResponseVisitaInternoss) = await nVisitaInterno.retornarListaVisitaInternoXCiudadano(Convert.ToInt32(this.txtIdCiudadano.Text));

                NParentesco nInterno = new NParentesco();
                //List<DParentesco> listaParentescos = new List<DParentesco>();
                (List<DParentesco> listaParentescos, string errorResponseParentesco) = await nInterno.retornarListaParentesco();



            }


            //Carga de combo categorias
            NCategoriasCiudadano nCategoriasCiudadano = new NCategoriasCiudadano();
            cmbCategorias.ValueMember = "id_categoria_ciudadano";
            cmbCategorias.DisplayMember = "categoria_ciudadano";
            (List<DCategoriasCiudadano> listaCategoriasCiudadanos, string response) = await nCategoriasCiudadano.RetornarListaCategoriasCiudadano();
            cmbCategorias.DataSource = listaCategoriasCiudadanos;




            NCategoriasCiudadano nCategoriasCiuddano = new NCategoriasCiudadano();
            //string apellido_ciudadanos = Convert.ToString(this.txtBuscarApellido.Text);
            (List<DCategoriasCiudadano> listaCategorias, string errorResponse) = await nCategoriasCiuddano.RetornarListaCategoriasCiudadano();
            if (listaCategorias == null)
            {
                MessageBox.Show(errorResponse, "Atención al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var datosFiltrados = listaCategorias
                .Select(c => new
                {
                    id_categorias_ciudadano = c.id_categoria_ciudadano,
                    Catgegorias = c.categoria_ciudadano

                })
                .ToList();


            //dgvCategoriasCiudadano.DataSource = datosFiltrados;



            this.txtIdCioudadanoCategoria.Text = txtIdCiudadano.Text;
            this.txtDniCiudadanoCategoria.Text = txtDni.Text;
            this.txtNombnreCiudadanoCategoria.Text = txtApellido.Text + " " + txtNombre.Text;
            this.tabControl1.SelectedIndex = 4;

        }
    }
    
}
