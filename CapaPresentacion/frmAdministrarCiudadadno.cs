using CapaDatos;
using CapaNegocio;
using CapaPresentacion.FuncionesGenerales;
using CapaPresentacion.Validaciones.AdministrarCiudadano.Datos;
using CapaPresentacion.Validaciones.AdministrarCiudadano.ValidacionCiudadano;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.tool.xml;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using CapaPresentacion.Validaciones.AdminVisita.ValidacionProhibicion;
using CapaPresentacion.Reportes.AdministrarCiudadano;
using PdfiumViewer;
using PdfDocument = PdfiumViewer.PdfDocument;
using System.Net;
using CommonCache;

namespace CapaPresentacion
{
    public partial class frmAdministrarCiudadadno : Form
    {
        //VARIABLES GLOBALES
        //private bool isNuevo = false;

        private bool isEditar = false;
        private bool valor = false;
        public int idInternoGlobal { get; set; }

        //PARA SUBIR IMAGEN
        string imagePath;


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

            this.txtDetalleMotivo.Text = "";

            this.btnGuardar.Enabled = valor;

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
            this.txtNumDomicilio.Enabled = valor;
            this.txtDetalleDomicilio.Enabled = valor;

            this.txtDetalleDomicilio.Text = "";
            
            btnGuardarDomicilio.Enabled = valor;
        }



        private async void btnGuardar_Click(object sender, EventArgs e)
        {//incio boton edicion

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
                cmbSexo = cmbSexo.SelectedValue.ToString(),
                cmbEstadoCivil = cmbEstadoCivil.SelectedValue.ToString(),
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
                    MessageBox.Show("La edición de datos del ciudadano se realizó corectamente", "Atención al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    //buscar y actualizar el ciudadano this.dCiudadano
                    this.ActualizarCiudadano();
                   
                    this.HabilitarControlesDatosPersonales(false);
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

            //// Ajustar el tamaño del formulario            
            FormularioAyudas.AjustarFormulario(this);

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
           
            //CARGAR DATOS DEL CIUDADANO
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
            txtNumDomicilio.Text = Convert.ToString(this.dCiudadano.numero_dom);
            
            pictureFoto.Load(this.dCiudadano.foto);

            //controlar edad
            this.ControlEdad();
            //fin controlar edad

            //controlar es visita y discapacidad
            this.ControlEsVisita();
            this.ControlTieneDiscapacidad();
            //fin controlar es visita y discapacidad

            //FIN CARGAR DATOPS DEL CIUDADANO


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

        private void btnVincular_Click(object sender, EventArgs e)
        {
            if (this.txtIdCiudadano.Text == string.Empty)
            {
                MessageBox.Show("debe esperar que cargue los datos del ciudadano");
            }
            else
            {
                
                this.tabCodigoRojo.SelectedIndex = 1;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private async void btnBuscarInterno_Click(object sender, EventArgs e)
        {

            using (frmInternosBuscar formInternos = new frmInternosBuscar())
            {
                txtIdInterno.Text = "";
                txtInternoVincular.Text = "";

                // Aquí se abre el FormularioB
                if (formInternos.ShowDialog() == DialogResult.OK)
                {
                    // Recién después de cerrar FormularioB, puedo leer el dato
                    txtIdInterno.Text = formInternos.IdInternoSeleccionado;
                    txtInternoVincular.Text = formInternos.InternoSeleccionado;
                }
            }

            
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

                //limpiar errores de provider
                errorProvider.Clear();

                //validacion de formulario
                var datosFormulario = new CiudadanoDatos
                {
                    txtIdVisita = txtIdVisita.Text,
                    txtIdInterno = txtIdInterno.Text,
                    cmbParentesco = cmbParentesco.SelectedValue?.ToString() ?? string.Empty,
                    
                };

                var validator = new VincularVisitaInternoValidator();
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
                    ciudadano_id = Convert.ToInt32(txtIdVisita.Text),
                    interno_id = Convert.ToInt32(txtIdInterno.Text),
                    parentesco_id = cmbParentesco.SelectedValue.ToString(),

                };
                //MessageBox.Show(Convert.ToString(cmbParentesco.SelectedValue.ToString()));
                string dataVisitaInterno = JsonConvert.SerializeObject(data);

               (DVisitaInterno visitaInterno, string errorResponseVisitaInterno) = await nVisitaInterno.crearVisitaInterno(dataVisitaInterno);

                if (visitaInterno != null)
                {
                    MessageBox.Show("La vinculación se realizó correctamente", "Atención al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                
                    NVisitaInterno nVisitaInternoActual = new NVisitaInterno();
                        
                    (List < DVisitaInterno > listaVisitasInternosActual, string errorResponseVisitasInternos) = await nVisitaInterno.retornarListaVisitaInternoXCiudadano(Convert.ToInt32(this.txtIdCiudadano.Text));

                    NParentesco nInterno = new NParentesco();
                    List<DParentesco> listaParentescos = new List<DParentesco>();
                    (List<DParentesco> listaParentescoss, string errorResponse) = await nInterno.retornarListaParentesco();

                    var datosFiltrados = listaVisitasInternosActual
                    .Select(c => new
                    {
                        Id = c.id_visita_interno,
                        Interno = c.interno.apellido + " " + c.interno.nombre,
                        Prontuario = c.interno.prontuario,
                        Unidad = c.interno.organismo.organismo,
                        Parentesco = c.parentesco.parentesco,
                        Vigente = c.vigente,
                        Prohibido = c.prohibido,
                        FechaProhib = c.fecha_prohibido,
                        FechaInicio = c.fecha_inicio,
                        FechaFin = c.fecha_fin,
                        DetalleProhib = c.detalles_prohibicion,
                        FechaAlta = c.fecha_alta,
                        Usuario = c.usuario.apellido + " " + c.usuario.nombre

                    })
                    .ToList();

                    dgvVisitasVinculadas.DataSource = datosFiltrados;

                    if (listaVisitasInternosActual.Count == 0)
                    {
                        MessageBox.Show("No se encontraron registros", "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {

                        dgvVisitasVinculadas.Columns[1].Width = 200;
                    }
                }
                else
                {
                    MessageBox.Show(errorResponseVisitaInterno, "Atención al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                txtNumDomicilio = txtNumDomicilio.Text,
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
            //fin validacion...........................

            var data = new
            {
                pais_id = cmbPais.SelectedValue.ToString(),
                provincia_id = cmbProvincia.SelectedValue.ToString(),
                departamento_id = Convert.ToInt32(cmbDepartamento.SelectedValue.ToString()),
                municipio_id = Convert.ToInt32(cmbMunicipio.SelectedValue.ToString()),
                ciudad = txtCiudad.Text,
                barrio = txtBarrio.Text,
                direccion = txtDireccion.Text,
                numero_dom = Convert.ToInt32(txtNumDomicilio.Text),
                detalle_motivo = txtDetalleDomicilio.Text,
            };

            string dataCiudadano = JsonConvert.SerializeObject(data);

            try
            {
                HttpResponseMessage httpResponse = await nCiudadano.editarCiudadanoDomicilio(Convert.ToInt32(txtIdCiudadano.Text), dataCiudadano);
                
                if (httpResponse.IsSuccessStatusCode)
                {
                    var contentRespuesta = await httpResponse.Content.ReadAsStringAsync();
                    MessageBox.Show("La edición de datos del ciudadano se realizó corectamente", "Atención al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //buscar y actualizar el ciudadano this.dCiudadano
                    this.ActualizarCiudadano();

                    this.HabilitarControlesDatosDomicilio(false);
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

        private void btnVincularVisitas_Click(object sender, EventArgs e)
        {
            if (this.txtIdCiudadano.Text == string.Empty)
            {
                MessageBox.Show("debe esperar que cargue los datos del ciudadano");
            }
            
            this.tabCodigoRojo.SelectedIndex = 3;
        }

        private async void btnAsignarVisita_Click(object sender, EventArgs e)
        {//inicio del boton asignar visitas
            if (this.txtIdCiuadanoVincularvisita.Text == string.Empty)
            {
                MessageBox.Show("Debe seleccionar el ciudadano");
            }

            else
            {
                NCiudadano nCiudadano = new NCiudadano();

                //limpiar errores de provider
                errorProvider.Clear();

                //validacion de formulario
                var datosFormulario = new CiudadanoDatos
                {
                    txtAsignarVisitaDetalle = txtAsignarVisitaDetalle.Text,
                };

                var validator = new AsignarComoVisitaValidator();
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
                //fin validacion...........................

                var data = new
                {
                    novedad_detalle = txtAsignarVisitaDetalle.Text,
                };

                string dataCiudadano = JsonConvert.SerializeObject(data);

                (bool respuestaEditar, string errorResponse) = await nCiudadano.establecerVisita(Convert.ToInt32(txtIdCiudadano.Text), dataCiudadano);

                if (respuestaEditar)
                {

                    MessageBox.Show("Se establecio correctamente como visita", "Atencion ciudadanos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //actualiza datos del ciudadano y controla si esta como vivista
                    this.ActualizarCiudadano();
                    this.txtAsignarVisitaDetalle.Text = "";
                }
                else
                {
                    MessageBox.Show(errorResponse, "Atencion ciudadanos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                          
                }
            }


        }//fin del boton asignar visitas

        private async void btnEstablecerDiscapacidad_Click(object sender, EventArgs e)
        {
            NCiudadano nCiudadano = new NCiudadano();

            //limpiar errores de provider
            errorProvider.Clear();

            //validacion de formulario
            var datosFormulario = new CiudadanoDatos
            {
                txtEstablecerDiscapacidad = txtEstablecerDiscapacidad.Text,
            };

            var validator = new EstablecerDiscapacidadValidator();
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
            //fin validacion...........................

            var data = new
            {
                novedad_detalle = txtEstablecerDiscapacidad.Text,
            };

            string dataCiudadano = JsonConvert.SerializeObject(data);

            (bool respuestaEditar, string errorResponse) = await nCiudadano.establecerDiscapacidad(Convert.ToInt32(txtIdCiudadano.Text), dataCiudadano);

            if (respuestaEditar)
            {

                MessageBox.Show("Se establecio correctamente con discapacidad", "Atencion ciudadanos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //actualizar datos y control discapacidad
                this.ActualizarCiudadano();
                txtEstablecerDiscapacidad.Text = "";
            }
            else
            {
                MessageBox.Show(errorResponse, "Atencion ciudadanos", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            
            this.tabCodigoRojo.SelectedIndex = 2;
        }


        private void btnAgregarInterno_Click(object sender, EventArgs e)
        {
            AgregarInternos agregarInternos = new AgregarInternos();
            agregarInternos.Show();
        }

        private void cmbOrganismoDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnAsignarCategorias_Click(object sender, EventArgs e)
        {
             
            if (this.txtIdCiudadano.Text == string.Empty)
            {
                MessageBox.Show("debe esperar que cargue los datos del ciudadano");
            }
            
            this.tabCodigoRojo.SelectedIndex = 4;

        }

        private async void btnCrearCiudadanosCategorias_Click(object sender, EventArgs e)
        {           
            
            if (this.txtIdCioudadanoCategoria.Text == string.Empty)
            {
                MessageBox.Show("Debe seleccionar el ciudadano");
            }

            else
            {
                NCiuddanosCategorias nCiudadanosCategorias = new NCiuddanosCategorias();

                var data = new
                {

                    ciudadano_id = Convert.ToInt32(txtIdCioudadanoCategoria.Text),
                    categoria_ciudadano_id = Convert.ToInt32(cmbCategorias.SelectedValue.ToString()),
                };


                string dataCiudadano = JsonConvert.SerializeObject(data);

                try
                {
                    (DCiudadanosCategorias ciudadanosCategoria, string errorResponseCiudadanosCategorias) = await nCiudadanosCategorias.crearCiudadanosCategorias(dataCiudadano);

                    if (ciudadanosCategoria != null)
                    {
                        
                        MessageBox.Show("Se le asignó la categoria al ciudadano correctamente", "Atención al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.CargarCategoriasDelCiudadano();
                    }
                    else
                    {
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
            txtNumDomicilio.Text = Convert.ToString(this.dCiudadano.numero_dom);

            HabilitarControlesDatosPersonales(false);
            //limpiar errores de provider
            errorProvider.Clear();
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
            txtNumDomicilio.Text = Convert.ToString(this.dCiudadano.numero_dom);

            this.HabilitarControlesDatosDomicilio(false);
            //limpiar errores de provider
            errorProvider.Clear();
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
                                
                var datosFiltrados = listaVisitasInternos
                .Select(c => new
                {
                    Id = c.id_visita_interno,
                    Interno = c.interno.apellido + " " + c.interno.nombre,
                    Prontuario = c.interno.prontuario,
                    Unidad = c.interno.organismo.organismo,
                    Parentesco = c.parentesco.parentesco,
                    Vigente = c.vigente,
                    Prohibido = c.prohibido,
                    FechaProhib = c.fecha_prohibido,
                    FechaInicio = c.fecha_inicio,
                    FechaFin = c.fecha_fin,
                    DetalleProhib = c.detalles_prohibicion,
                    FechaAlta = c.fecha_alta,
                    Usuario = c.usuario.apellido + " " + c.usuario.nombre
                    

                })
                .ToList();

                dgvVisitasVinculadas.DataSource = datosFiltrados;

                if (listaVisitasInternos.Count == 0)
                {
                    MessageBox.Show("No se encontraron registros", "Atención al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                else
                {

                    dgvVisitasVinculadas.Columns[1].Width = 200;
                }

                //Carga de combo parentesco
                NParentesco nParentesco = new NParentesco();

                cmbParentesco.ValueMember = "id_parentesco";
                cmbParentesco.DisplayMember = "parentesco";
                (List<DParentesco> listaParentesco, string errorResponseParentescos) = await nParentesco.retornarListaParentesco();
                
                if (listaParentesco.Count == 0)
                {
                    MessageBox.Show("No se encontraron registros para cargar la lista de parentescos", "Atención al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }

                cmbParentesco.DataSource = listaParentesco;

                
                this.txtIdVisita.Text = txtIdCiudadano.Text;

            }
        
        }
                

        private async void btnActualizarDatos_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Boton nuevo");
            if (this.txtIdCiudadano.Text == string.Empty)
            {
                MessageBox.Show("debe esperar que cargue los datos del ciudadano");
                
                return;
            }
            
            //Carga de combo categorias
            NCategoriasCiudadano nCategoriasCiudadano = new NCategoriasCiudadano();
            cmbCategorias.ValueMember = "id_categoria_ciudadano";
            cmbCategorias.DisplayMember = "categoria_ciudadano";
            (List<DCategoriasCiudadano> listaCategoriasCiudadanos, string response) = await nCategoriasCiudadano.RetornarListaCategoriasCiudadano();
            cmbCategorias.DataSource = listaCategoriasCiudadanos;

            this.CargarCategoriasDelCiudadano();

            this.txtIdCioudadanoCategoria.Text = txtIdCiudadano.Text;
            this.txtDniCiudadanoCategoria.Text = txtDni.Text;
            this.txtNombnreCiudadanoCategoria.Text = txtApellido.Text + " " + txtNombre.Text;
            this.tabCodigoRojo.SelectedIndex = 4;

        }

        private async void btnActualizarAsignar_Click(object sender, EventArgs e)
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


            //controlar es visita y discapacidad
            this.ControlEsVisita();
            this.ControlTieneDiscapacidad();
            //fin controlar es visita y discapacidad

            this.txtIdCiuadanoVincularvisita.Text = txtIdCiudadano.Text;
            this.txtDniVisita.Text = txtDni.Text;
            this.txtNombreVisita.Text = txtApellido.Text + " " + txtNombre.Text;
        }

        //ACTUALIZAR CIUDADANO
        private async void ActualizarCiudadano()
        {
            NCiudadano nCiudadano = new NCiudadano();

            //buscar y actualizar el ciudadano this.dCiudadano
            (DCiudadano dCiudadano2, string errorResponse) = await nCiudadano.BuscarCiudadanoXID(Convert.ToInt32(txtIdCiudadano.Text));


            if (this.dCiudadano == null)
            {
                MessageBox.Show(errorResponse, "Atención al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.dCiudadano = dCiudadano2;
            pictureFoto.Load(this.dCiudadano.foto);
            //controlar edad
            this.ControlEdad();
            //fin controlar edad

            //controlar es visita y discapacidad
            this.ControlEsVisita();
            this.ControlTieneDiscapacidad();
            //fin controlar es visita y discapacidad
        }
        //FIN ACTUALIZAR CIUDADANO

        //CONTROL ES VISITA
        private void ControlEsVisita()
        {
            if (this.dCiudadano.es_visita)
            {
                lblEsVisitaPrincipal.Text = "Ciudadano registrado como visita";
                lblEsVisitaPrincipal.ForeColor = Color.SteelBlue;
                lblEsVisita.Text = "Ciudadano registrado como visita";
                lblEsVisita.ForeColor = Color.SteelBlue;
                btnAsignarVisita.Enabled = false;
            }
            else
            {
                lblEsVisitaPrincipal.Text = "Ciudadano no registrado como visita";
                lblEsVisitaPrincipal.ForeColor = Color.Red;
                lblEsVisita.Text = "Ciudadano no registrado como visita";
                lblEsVisita.ForeColor = Color.Red;
            }
        }
        //FIN CONTROL ES VISITA

        //CONTROL TIENE DISCAPACIDAD
        private void ControlTieneDiscapacidad()
        {
            if (this.dCiudadano.tiene_discapacidad)
            {                
                lblTieneDiscapacidad.Text = "Ciudadano registrado con discapacidad";
                lblTieneDiscapacidad.ForeColor = Color.SteelBlue;
                lblDetalleTieneDiscapacidad.Text = dCiudadano.discapacidad_detalle;
                lblDetalleTieneDiscapacidad.ForeColor = Color.SteelBlue;
                btnEstablecerDiscapacidad.Enabled = false;
            }
            else
            {
                lblTieneDiscapacidad.Text = "Ciudadano no registrado con discapacidad";
                lblTieneDiscapacidad.ForeColor = Color.Red;

                lblDetalleTieneDiscapacidad.Text = "";
            }
        }
        //FIN CONTROL TIENE DISCAPACIDAD

        //CONTROL EDAD
        private void ControlEdad()
        {
            if (this.dCiudadano.edad < 18)
            {
                lblMenorEdad.Text = "Edad: " + this.dCiudadano.edad + " años. Es MENOR.";
            }
            else
            {
                lblMenorEdad.Text = "Edad: " + this.dCiudadano.edad + " años. Es ADULTO.";
            }
        }
        //FIN CONTROL EDAD

        //CARGAR LISTA CATEGORIAS VIGENTES DEL CIUDADANO
        private async void CargarCategoriasDelCiudadano()
        {

            NCiuddanosCategorias nCiudadanosCategorias = new NCiuddanosCategorias();

            (List<DCiudadanosCategorias> listaCiudadanosCategorias, string errorResponse) = await nCiudadanosCategorias.retornarCiudadanosCategoriasVigentesXCiudadano(Convert.ToInt32(txtIdCiudadano.Text));
            if (listaCiudadanosCategorias == null)
            {
                MessageBox.Show(errorResponse, "Atención al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            var datosFiltrados = listaCiudadanosCategorias
                .Select(c => new
                {
                    IdCategoriaCiudadano = c.id_ciudadano_categoria,
                    Categoria = c.categoria_ciudadano.categoria_ciudadano,
                    FechaCarga = c.fecha_carga,
                    OrganismoCarga = c.organismo.organismo,
                    UsuarioCarga = c.usuario.apellido + " " + c.usuario.nombre

                })
                .ToList();

            dgvCategoriasCiudadano.DataSource = datosFiltrados;

            if (listaCiudadanosCategorias.Count == 0)
            {
                MessageBox.Show("No se encontraron registros", "Atención al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {

                dgvCategoriasCiudadano.Columns[1].Width = 150;
                dgvCategoriasCiudadano.Columns[3].Width = 150;
                dgvCategoriasCiudadano.Columns[4].Width = 150;
            }
        
        }//FIN CARGAR LISTA VIGENTES CATEGORIAS DEL CIUDADANO..................

        //CARGAR LISTA CATEGORIAS HISTORICA DEL CIUDADANO
        private async void CargarCategoriasHistoricaDelCiudadano()
        {

            NCiuddanosCategorias nCiudadanosCategorias = new NCiuddanosCategorias();

            (List<DCiudadanosCategorias> listaCiudadanosCategorias, string errorResponse) = await nCiudadanosCategorias.retornarCiudadanosCategoriasHistoricasXCiudadano(Convert.ToInt32(txtIdCiudadano.Text));
            if (listaCiudadanosCategorias == null)
            {
                MessageBox.Show(errorResponse, "Atención al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var datosFiltrados = listaCiudadanosCategorias
                .Select(c => new
                {
                    IdCategoriaCiudadano = c.id_ciudadano_categoria,
                    Categoria = c.categoria_ciudadano.categoria_ciudadano,
                    FechaCarga = c.fecha_carga,
                    OrganismoCarga = c.organismo.organismo,
                    UsuarioCarga = c.usuario.apellido + " " + c.usuario.nombre,
                    Vigente = c.vigente

                })
                .ToList();

            dgvCategoriasCiudadano.DataSource = datosFiltrados;

            if (listaCiudadanosCategorias.Count == 0)
            {
                MessageBox.Show("No se encontraron registros", "Atención al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {

                dgvCategoriasCiudadano.Columns[1].Width = 150;
                dgvCategoriasCiudadano.Columns[3].Width = 150;
                dgvCategoriasCiudadano.Columns[4].Width = 150;
            }

        }//FIN CARGAR LISTA HISTORICA CATEGORIAS DEL CIUDADANO..................


        private async void btnActualizarIngresos_Click(object sender, EventArgs e)
        {
            if (this.txtIdCiudadano.Text == string.Empty)
            {
                MessageBox.Show("debe esperar que cargue los datos del ciudadano");
            }
            else
            {
                NRegistroDiario nRegistroDiario = new NRegistroDiario();
                (List<DRegistroDiario> listaRegistroDiario, string errorResponse) = await nRegistroDiario.RetornarListaXCiudadano(Convert.ToInt32(this.txtIdCiudadano.Text));

                if (listaRegistroDiario == null)
                {
                    MessageBox.Show(errorResponse, "Atención al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                NParentesco nInterno = new NParentesco();
                //List<DParentesco> listaParentescos = new List<DParentesco>();
                (List<DParentesco> listaParentescos, string errorResponseParentesco) = await nInterno.retornarListaParentesco();

                var datosFiltrados = listaRegistroDiario
                .Select(c => new
                {
                    Ingreso = c.fecha_ingreso,
                    HoraIngreso = c.hora_ingreso,
                    HoraEgreso = c.hora_egreso,
                    TipoAtencion = c.tipo_atencion.tipo_atencion,
                    TipoAcceso = c.tipo_acceso.tipo_acceso,
                    SectorDestino = c.sector_destino.sector_destino,
                    MotivoAtencion = c.motivo_atencion.motivo_atencion,
                    Interno = c.interno,
                    Observacion = c.observaciones,
                    Organismo = c.organismo.organismo,
                    Usuario = c.usuario.apellido + " " + c.usuario.nombre

                })
                .ToList();

                dgvRegistroDiario.DataSource = datosFiltrados;

            }


        }

        private void dgvCategoriasCiudadano_KeyDown(object sender, KeyEventArgs e)
        {
            //AL PRESIONAR ENTER MOSTRAR EL TRAMITE
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (dgvCategoriasCiudadano.SelectedRows.Count > 0)
                {

                    this.txtIdCategoriaQuitar.Text = Convert.ToString(this.dgvCategoriasCiudadano.CurrentRow.Cells["IdCategoriaCiudadano"].Value);
                    this.txtCategoriaQuitar.Text = Convert.ToString(this.dgvCategoriasCiudadano.CurrentRow.Cells["Categoria"].Value);
                    this.txtFechaCargaCategoriaQuitar.Text = Convert.ToString(this.dgvCategoriasCiudadano.CurrentRow.Cells["FechaCarga"].Value);

                }
                else
                {
                    MessageBox.Show("Debe seleccionar una categoria del ciudadano.");
                }                
            }
        }

        private async void btnQuitarCategoria_Click(object sender, EventArgs e)
        {
            if (this.txtIdCategoriaQuitar.Text == string.Empty)
            {
                MessageBox.Show("Debe seleccionar la categoria del ciudadano");
            }

            else
            {
                NCiuddanosCategorias nCiuddanosCategorias = new NCiuddanosCategorias();

                //limpiar errores de provider
                errorProvider.Clear();

                //validacion de formulario
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
                //fin validacion...........................

                var data = new
                {
                    detalle_quitar_categoria = txtDetalleCategoriaQuitar.Text,
                };

                string dataCategoria = JsonConvert.SerializeObject(data);

                (bool respuestaEditar, string errorResponse) = await nCiuddanosCategorias.QuitarCategoria(Convert.ToInt32(txtIdCategoriaQuitar.Text), dataCategoria);

                if (respuestaEditar)
                {

                    MessageBox.Show("Se quitó correctamente la categoria", "Atencion ciudadanos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.CargarCategoriasDelCiudadano();

                    this.txtIdCategoriaQuitar.Text = string.Empty;
                    this.txtCategoriaQuitar.Text = string.Empty;
                    this.txtFechaCargaCategoriaQuitar.Text = string.Empty;
                    this.txtDetalleCategoriaQuitar.Text = string.Empty;

                }
                else
                {
                    MessageBox.Show(errorResponse, "Atencion ciudadanos", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void btnLimpiarQuitarCategoria_Click(object sender, EventArgs e)
        {
            this.txtIdCategoriaQuitar.Text = string.Empty;
            this.txtCategoriaQuitar.Text = string.Empty;
            this.txtFechaCargaCategoriaQuitar.Text = string.Empty;
            this.txtDetalleCategoriaQuitar.Text = string.Empty;
        }

        private void btnBuscarImagen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    this.imagePath = ofd.FileName;
                    pictureImagenCargar.Image = System.Drawing.Image.FromFile(imagePath);
                }
            }
        }

        private async void btnSubir_Click(object sender, EventArgs e)
        {
            NCiudadano nCiudadano = new NCiudadano();

            int idCiudadano = Convert.ToInt32(txtIdCiudadano.Text);
            string rutaImagen = this.imagePath; // o lo que hayas guardado al seleccionar la imagen

            var (exito, errorResponse) = await nCiudadano.subirImagen(idCiudadano, rutaImagen);

            if (exito)
            {
                MessageBox.Show("Imagen subida correctamente.", "Atencion ciudadanos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //buscar y actualizar el ciudadano this.dCiudadano
                this.ActualizarCiudadano();
                pictureImagenCargar.Image = null;
                this.imagePath = "";
            }
            else
            {
                MessageBox.Show( errorResponse, "Atencion ciudadanos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void btnQuitarImagen_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "¿Esta seguro  que desea quitar la imagen?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
            {
                MessageBox.Show("Ha cancelado la operacion.", "Atencion ciudadanos", MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            NCiudadano nCiudadano = new NCiudadano();

            int idCiudadano = Convert.ToInt32(txtIdCiudadano.Text);
            
            var (exito, errorResponse) = await nCiudadano.quitarImagen(idCiudadano);

            if (exito)
            {
                MessageBox.Show("Imagen quitada correctamente.", "Atencion ciudadanos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //buscar y actualizar el ciudadano this.dCiudadano
                this.ActualizarCiudadano();
                pictureImagenCargar.Image = null;
                
            }
            else
            {
                MessageBox.Show(errorResponse, "Atencion ciudadanos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancelarSubirImagen_Click(object sender, EventArgs e)
        {
            pictureImagenCargar.Image = null;
            this.imagePath = "";
        }

        private async void btnActualizarMenores_Click(object sender, EventArgs e)
        {
            if (this.txtIdCiudadano.Text == string.Empty)
            {
                MessageBox.Show("debe esperar que cargue los datos del ciudadano");
            }
            else
            {
                NMenorACargo nMenorACargo = new NMenorACargo();
                (List<DMenorACargo> listaMenoresACargo, string errorResponse) = await nMenorACargo.retornarListaVigentesXAdulto(Convert.ToInt32(this.txtIdCiudadano.Text));

                if (listaMenoresACargo == null)
                {
                    MessageBox.Show(errorResponse, "Atención al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                
                var datosFiltrados = listaMenoresACargo
                .Select(c => new
                {
                    Id = c.id_menor_a_cargo,
                    Adulto = c.ciudadanoTutor.apellido + " " + c.ciudadanoTutor.nombre,
                    Parentesco = c.parentesco_menor.parentesco_menor,
                    Menor = c.ciudadanoMenor.apellido + " " + c.ciudadanoMenor.nombre,
                    DniMenor = c.ciudadanoMenor.dni,
                    EdadMenor = c.edadMenor

                })
                .ToList();

                dgvMenores.DataSource = datosFiltrados;

                //Carga de combo parentesco
                NParentesco nParentesco = new NParentesco();

                cmbParentescosMenor.ValueMember = "id_parentesco_menor";
                cmbParentescosMenor.DisplayMember = "parentesco_menor";
                (List<DParentescoMenor> listaParentescoMenor, string errorResponseParentescos) = await nParentesco.retornarListaParentescosMenor();
                cmbParentescosMenor.DataSource = listaParentescoMenor;

            }

        }

        private async void btnBuscarMenor_Click(object sender, EventArgs e)
        {
            //limpiar errores de provider
            errorProvider.Clear();

            //validar
            //var data = new CiudadanoNuevoDatos
            //{
            //    txtBuscarApellido = txtBuscarApellido.Text
            //};

            //var validator = new BuscarApellidoValidator();
            //var result = validator.Validate(data);

            //if (!result.IsValid)
            //{
            //    MessageBox.Show("Complete correctamente los campos del formulario", "Atencion Ciudadanos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    foreach (var failure in result.Errors)
            //    {

            //        Control control = Controls.Find(failure.PropertyName, true)[0];
            //        errorProvider.SetError(control, failure.ErrorMessage);
            //    }
            //    return;
            //}
            //fin validar

            NCiudadano nCiudadanos = new NCiudadano();

            string apellido_ciudadanos = Convert.ToString(this.txtBuscarMenor.Text);
            (List<DCiudadano> listaCiudadanos, string errorResponse) = await nCiudadanos.RetornarListaCiudadanosConEdadXapellido(apellido_ciudadanos);
            if (listaCiudadanos == null)
            {
                MessageBox.Show(errorResponse, "Atención al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Console.WriteLine(listaCiudadanos);
            //MessageBox.Show(listaCiudadanos[0].edad.ToString());

            var datosFiltrados = listaCiudadanos
                .Select(c => new
                {
                    Id_ciudadano = c.id_ciudadano,
                    ApellidoNombre = c.apellido + " " + c.nombre,
                    Dni = c.dni,
                    Sexo = c.sexo.sexo,
                    Edad = c.edad
                })
                .ToList();


            dgvCiudadanosMenores.DataSource = datosFiltrados;

            if (listaCiudadanos.Count == 0)
            {
                MessageBox.Show("No se encontraron registros", "Atención al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {

                dgvCiudadanosMenores.Columns[1].Width = 200;
            }

        }

        private void dgvCiudadanosMenores_KeyDown(object sender, KeyEventArgs e)
        {
            //AL PRESIONAR ENTER MOSTRAR
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                
                if (dgvCiudadanosMenores.SelectedRows.Count > 0)
                {

                        this.txtIdCiudadanoMenor.Text = Convert.ToString(this.dgvCiudadanosMenores.CurrentRow.Cells["Id_ciudadano"].Value);
                        this.txtDniMenor.Text = Convert.ToString(this.dgvCiudadanosMenores.CurrentRow.Cells["Dni"].Value);
                        this.txtNombreMenor.Text = Convert.ToString(this.dgvCiudadanosMenores.CurrentRow.Cells["ApellidoNombre"].Value);
                 
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un menor.");
                }
                
            }
        }

        private async void btnVincularTutorConMenor_Click(object sender, EventArgs e)
        {
            if (this.txtIdCiudadanoMenor.Text == string.Empty)
            {
                MessageBox.Show("debe seleccionar el menor antes de vincular ");
            }
            else
            {
                NMenorACargo nMenorACargo = new NMenorACargo();



                //validacion de formulario
                //limpiar errores de provider
                errorProvider.Clear();

                var datosFormulario = new CiudadanoDatos
                {
                    txtIdCiudadano = txtIdCiudadano.Text,
                    txtIdCiudadanoMenor = txtIdCiudadanoMenor.Text,
                    cmbParentescosMenor = cmbParentescosMenor.SelectedValue?.ToString() ?? string.Empty,

                };

                var validator = new VincularVisitaMenorValidator();
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
                    ciudadano_tutor_id = Convert.ToInt32(txtIdCiudadano.Text),
                    ciudadano_menor_id = Convert.ToInt32(txtIdCiudadanoMenor.Text),
                    parentesco_menor_id = Convert.ToString(cmbParentescosMenor.SelectedValue.ToString()),

                };
                //MessageBox.Show(Convert.ToString(cmbParentesco.SelectedValue.ToString()));
                string dataMenorAcargo = JsonConvert.SerializeObject(data);

                (DMenorACargo menorACargo, string errorResponseListaMenores) = await nMenorACargo.crearMenorACargo(dataMenorAcargo);

                if (menorACargo != null)
                {
                    MessageBox.Show("La vinculación del menor se realizó correctamente", "Atención al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    
                    (List<DMenorACargo> listaMenorACargo, string errorResponseMenores) = await nMenorACargo.retornarListaVigentesXAdulto(Convert.ToInt32(this.txtIdCiudadano.Text));

                    var datosFiltrados = listaMenorACargo
                    .Select(c => new
                    {                        
                        Id = c.id_menor_a_cargo,
                        Adulto = c.ciudadanoTutor.apellido + " " + c.ciudadanoTutor.nombre,
                        Parentesco = c.parentesco_menor.parentesco_menor,
                        Menor = c.ciudadanoMenor.apellido + " " + c.ciudadanoMenor.nombre,
                        DniMenor = c.ciudadanoMenor.dni,
                        EdadMenor = c.edadMenor
                    })
                    .ToList();


                    dgvMenores.DataSource = datosFiltrados;

                }
                else
                {
                    MessageBox.Show(errorResponseListaMenores, "Atención al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hola Mundo");
        }

        private async void btnQuitarVisita_Click(object sender, EventArgs e)
        {//inicio quitar ciudadano como visita
            

            if (this.txtIdCiuadanoVincularvisita.Text == string.Empty)
            {
                MessageBox.Show("Debe seleccionar el ciudadano");
            }

            else
            {
                NCiudadano nCiudadano = new NCiudadano();

                //limpiar errores de provider
                errorProvider.Clear();

                //validacion de formulario
                var datosFormulario = new CiudadanoDatos
                {
                    txtAsignarVisitaDetalle = txtAsignarVisitaDetalle.Text,
                };

                var validator = new AsignarComoVisitaValidator();
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
                //fin validacion...........................

                var data = new
                {
                    novedad_detalle = txtAsignarVisitaDetalle.Text,
                };

                string dataCiudadano = JsonConvert.SerializeObject(data);

                (bool respuestaEditar, string errorResponse) = await nCiudadano.quitarVisita(Convert.ToInt32(txtIdCiuadanoVincularvisita.Text), dataCiudadano);

                if (respuestaEditar)
                {

                    MessageBox.Show("Se quitó correctamente al ciudadano como visita", "Atencion ciudadanos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //actualiza datos del ciudadano y controla si esta como vivista
                    this.ActualizarCiudadano();
                    this.txtAsignarVisitaDetalle.Text = "";
                }
                else
                {
                    MessageBox.Show(errorResponse, "Atencion ciudadanos", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }

        }//fin quitar ciudadano como visita

        private async void btnAbrirFormularioImprimir_Click(object sender, EventArgs e)
        {
            if (this.txtIdCiudadano.Text == string.Empty)
            {
                MessageBox.Show("debe esperar que cargue los datos del ciudadano");
            }
            else
            {

                this.tabCodigoRojo.SelectedIndex = 6;

            }
        }

        private async void btnImprimirFormularioEmpadronamiento_Click(object sender, EventArgs e)
        {

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


            DCiudadano dCiudadano = new DCiudadano();
            DOrganismo dOrganismo = new DOrganismo();
            //SaveFileDialog solicita al usuario que busqeu un lugar para guardar un archivo
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.FileName = DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf";//gaurda el archivo con el nombre de la fecha del dia concatenado con la hora .pdf
                                                                                //guardar.ShowDialog();//ejecuta un cuadro de dialogo

            string varSexo = Convert.ToString(cmbSexo.Text);

            /*La forma para trabajar u archivo .pdf, o al menos el diseño que va a tener el pdf, en el video lo trabajan 
            es en que se puedan cambiar y modificar por un largo tiempo. La forma es creando un archivo html, en donde se diseña una tabla
            con el ancho de las columnas y todo lo necesarrio para crear las tablas, trabajando totalmente el html, y en base a este archivo
            generar un pdf*/

            /*string paginahtml_texto = Properties.Resources.plantilla.ToString();
            //vamos a reemplazar los parametros por los valores de los formularios
            paginahtml_texto = paginahtml_texto.Replace("@DNI", Convert.ToString(dCiudadano2.dni));
            paginahtml_texto = paginahtml_texto.Replace("@NOMBRE", (dCiudadano2.apellido) + " " + (dCiudadano2.nombre));
            paginahtml_texto = paginahtml_texto.Replace("@DOMICILIO", (dCiudadano2.direccion) + " " + (dCiudadano2.numero_dom));
            paginahtml_texto = paginahtml_texto.Replace("@NACIONALIDAD", (dCiudadano2.nacionalidad.nacionalidad));
            paginahtml_texto = paginahtml_texto.Replace("@FECHA_ALTA", Convert.ToString(dCiudadano2.fecha_alta));
            paginahtml_texto = paginahtml_texto.Replace("@ESTADO_CIVIL", Convert.ToString(dCiudadano2.estado_civil.estado_civil));
            paginahtml_texto = paginahtml_texto.Replace("@NACIMIENTO", Convert.ToString(dCiudadano2.fecha_nac));
            paginahtml_texto = paginahtml_texto.Replace("@TELEFONO", (dCiudadano2.telefono));
            paginahtml_texto = paginahtml_texto.Replace("@SEXO", dCiudadano2.sexo.sexo);
            //paginahtml_texto = paginahtml_texto.Replace("@PARENTEZCO", Convert.ToString(data));
            */
            //imprimir reporte

            //MessageBox.Show("Imprimir ticket");

            //MessageBox.Show("Hola Mundo");
            CrearReporte reporte = new CrearReporte();
            string organismo = CurrentUser.Instance.organismo.ToUpper();
            reporte.espacio1_en_blanco = " ";
            
            reporte.encabezado_principal1 = Convert.ToString("                             SERVICIO PENITENCIARIO DE LA PROVINCIA DE SALTA");
            reporte.encabezado_principal2 = Convert.ToString("                     Declaración Jurada de Datos para incorporación a Sistema de Acceso ");
            reporte.encabezado_principal3 = Convert.ToString("                                               " + organismo);
            //reporte.espacio1_en_blanco = " ";
            //reporte.espacio1_en_blanco = " ";
            reporte.encabezado_secundario1 = Convert.ToString("                     ______: En la ciudad de Salta, capital de la provincia del mismo nombre, el/la que suscribe la");
            reporte.encabezado_secundario2 = "                     presente Sr./Sra.: " + Convert.ToString(dCiudadano2.apellido) + " " + (dCiudadano2.nombre)  + " " + ", Declara que: ";
            //reporte.encabezado_secundario3 = Convert.ToString("                     );
            //reporte.espacio1_en_blanco = " ";
            //reporte.espacio1_en_blanco = " ";
            reporte.nacionalidad = "                    Su nacionalidad es: " + " " + Convert.ToString(dCiudadano2.nacionalidad.nacionalidad);
            reporte.dni = "                    Documento de Identidad: " + " " + Convert.ToString(dCiudadano2.dni);
            reporte.fecha_nacimiento = "                    Su Fecha de Nacimiento es:" + " " + dCiudadano2.fecha_nac.ToShortDateString();
            reporte.sexo = "                    Sexo:" + " " + Convert.ToString(dCiudadano2.sexo.sexo);
            reporte.domicilio = "                    Su domicilio actual es :" + " Barrio " + Convert.ToString(dCiudadano2.barrio) + ", " + Convert.ToString(dCiudadano2.direccion) + " " + Convert.ToString(dCiudadano2.numero_dom);
            reporte.telefono = "                    Su Teléfono actual es :" + " " + Convert.ToString(dCiudadano2.telefono);
            reporte.fecha_alta = "                     Fecha de Alta: " +" "+ dCiudadano2.fecha_alta.ToShortDateString();
            reporte.estado_civil = "                     Su Estado Civil es: " + " " + Convert.ToString(dCiudadano2.estado_civil.estado_civil);
            reporte.espacio1_en_blanco = " ";
            reporte.pie_de_pagina1 = Convert.ToString("                   Detallando a continuación menores a cargo en caaso de declarar alguno:");
            reporte.pie_de_pagina2 = Convert.ToString("                   Finalmente, se deja constancia que lo declarado queda sujeto a las verificaciones correspon-");
            reporte.pie_de_pagina3 = Convert.ToString("                   dientes por parte de la Dirección de Unidad, donde se encuentra alojado/a el/la interno/a al que");
            reporte.pie_de_pagina4 = Convert.ToString("                   visita. Dicho Organismo que emitirá la pertinente autorización correspondiente para la continui-");
            reporte.pie_de_pagina5 = Convert.ToString("                   dad de los trámites de su habilitación de ingreso en carácter de visitante.");
            reporte.pie_de_pagina6 = Convert.ToString("                 -----------------------------------------                                               -----------------------------------------");
            reporte.pie_de_pagina7 = "                 " + " " + Convert.ToString(Convert.ToString(dCiudadano2.apellido) + " " + (dCiudadano2.nombre));
            reporte.pie_de_pagina8 = Convert.ToString("                                                                          ");
            //ticket.logotipo = pictureBox1.Image;
            reporte.imprimir(reporte);
            


            /*
            //vamos a hacer elguardado del archivo si cumple todos los requisitos
            if (guardar.ShowDialog() == DialogResult.OK)
            {
                //primero vamos a guardar el archivo pdf en un archivo de memoria
                using (FileStream stream = new FileStream(guardar.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25); //archivo .pdf tamaño A4 con margenes de 25 para los lados
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();//necesitamos abrir el archivo para agregar los textos
                                  //pdfDoc.Add(new Phrase("Hola a todos"));

                    using (StringReader sr = new StringReader(paginahtml_texto))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }
                    
                    pdfDoc.Close();
                    stream.Close();
                }

            }*/

        }

        private void dgvMenores_KeyDown(object sender, KeyEventArgs e)
        {
            //AL PRESIONAR ENTER MOSTRAR EL TRAMITE
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (dgvMenores.SelectedRows.Count > 0)
                {
                    this.txtIdMenor.Text = Convert.ToString(this.dgvMenores.CurrentRow.Cells["Id"].Value);
                    this.txtNombreMen.Text = Convert.ToString(this.dgvMenores.CurrentRow.Cells["Menor"].Value);
                    this.txtEdadMen.Text = Convert.ToString(this.dgvMenores.CurrentRow.Cells["EdadMenor"].Value);
                    //this.txtFechaCargaCategoriaQuitar.Text = Convert.ToString(this.dgvCategoriasCiudadano.CurrentRow.Cells["FechaCarga"].Value);

                }
                else
                {
                    MessageBox.Show("Debe seleccionar el menor.");
                }
            }
        }

        private async void btnQuitarMenores_Click(object sender, EventArgs e)
        {//inicio btn quitar menores a cargo 
            if (this.txtIdMenor.Text == string.Empty)
            {
                MessageBox.Show("Debe seleccionar el menor");
            }

            else
            {
                NMenorACargo nMenoresaCargo = new NMenorACargo();
                //limpiar errores de provider
                errorProvider.Clear();

                //validacion de formulario
                var datosFormulario = new CiudadanoDatos
                {
                    txtDetalleMenores = txtDetalleMenores.Text,
                };

                var validator = new QuitarMenoresaCargoValidator();
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
                //fin validacion...........................

                var data = new
                {
                    detalle_anular = txtDetalleMenores.Text,
                };

                string dataMenores = JsonConvert.SerializeObject(data);

                (bool respuestaEditar, string errorResponse) = await nMenoresaCargo.QuitarMenoresaCargo(Convert.ToInt32(txtIdMenor.Text), dataMenores);

                if (respuestaEditar)
                {

                    MessageBox.Show("Se quitó correctamente el menor", "Atencion ciudadanos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    (List<DMenorACargo> listaMenoresACargo, string errorResponseEditar) = await nMenoresaCargo.retornarListaVigentesXAdulto(Convert.ToInt32(this.txtIdCiudadano.Text));

                    if (listaMenoresACargo == null)
                    {
                        MessageBox.Show(errorResponseEditar, "Atención al Ciudadano", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                    var datosFiltrados = listaMenoresACargo
                    .Select(c => new
                    {
                        Id = c.id_menor_a_cargo,
                        Adulto = c.ciudadanoTutor.apellido + " " + c.ciudadanoTutor.nombre,
                        Parentesco = c.parentesco_menor.parentesco_menor,
                        Menor = c.ciudadanoMenor.apellido + " " + c.ciudadanoMenor.nombre,
                        DniMenor = c.ciudadanoMenor.dni,
                        EdadMenor = c.edadMenor

                    })
                    .ToList();

                    dgvMenores.DataSource = datosFiltrados;

                    this.txtIdMenor.Text = string.Empty;
                    this.txtNombreMen.Text = string.Empty;
                    this.txtEdadMen.Text = string.Empty;
                    this.txtDetalleMenores.Text = string.Empty;

                }
                else
                {
                    MessageBox.Show(errorResponse, "Atencion ciudadanos", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }//fin btn quitar mennores a cargo

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtIdMenor.Text = string.Empty;
            this.txtNombreMen.Text = string.Empty;
            this.txtEdadMen.Text = string.Empty;
            this.txtDetalleMenores.Text = string.Empty;
        }

        private void btnVerNovedades_Click(object sender, EventArgs e)
        {
            this.CargarDataGridNovedades();
        }

        private void dtgvNovedades_KeyDown(object sender, KeyEventArgs e)
        {
            //AL PRESIONAR ENTER MOSTRAR EL TRAMITE
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (dtgvNovedades.SelectedRows.Count > 0)
                {
                    int id_novedad;
                    id_novedad = Convert.ToInt32(dtgvNovedades.CurrentRow.Cells["ID"].Value.ToString());

                    if (id_novedad > 0)
                    {
                        txtIdNovedad.Text = id_novedad.ToString();
                        txtFechaNovedad.Text = Convert.ToDateTime(dtgvNovedades.CurrentRow.Cells["FechaNovedad"].Value).ToString("dd/MM/yyyy");
                        txtOrganismoNovedad.Text = dtgvNovedades.CurrentRow.Cells["Organismo"].Value.ToString();
                        txtUsuarioNovedad.Text = dtgvNovedades.CurrentRow.Cells["Usuario"].Value.ToString();
                        txtNovedad.Text = dtgvNovedades.CurrentRow.Cells["Novedad"].Value.ToString();
                        txtDetalleNovedad.Text = dtgvNovedades.CurrentRow.Cells["Detalle"].Value.ToString();

                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar una novedad.", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnNuevaNovedad_Click(object sender, EventArgs e)
        {
            txtNuevaNovedad.Enabled = true;
            btnNuevaNovedad.Enabled = false;
            btnGuardarNovedad.Enabled = true;
            btnCancelarNovedad.Enabled = true;
        }

        private async void btnGuardarNovedad_Click(object sender, EventArgs e)
        {
            //limpiar errores de provider
            errorProvider.Clear();

            //validacion de formulario
            var datosFormulario = new CiudadanoDatos
            {
                txtIdCiudadano = txtIdCiudadano.Text,
                txtNuevaNovedad = txtNuevaNovedad.Text,
            };

            var validator = new NovedadNuevaValidator();
            var result = validator.Validate(datosFormulario);

            if (!result.IsValid)
            {
                MessageBox.Show("Complete correctamente los campos del formulario", "Restriccion Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                foreach (var failure in result.Errors)
                {

                    Control control = Controls.Find(failure.PropertyName, true)[0];
                    errorProvider.SetError(control, failure.ErrorMessage);
                }
                return;
            }
            //fin validacion de formulario

            NNovedadCiudadano nNovedadCiudadano = new NNovedadCiudadano();

            bool respuestaOk = false;
            string mensajeRespuesta = "";


            var data = new
            {
                ciudadano_id = Convert.ToInt32(txtIdCiudadano.Text),
                novedad_detalle = txtNuevaNovedad.Text,
            };

            string dataNovedad = JsonConvert.SerializeObject(data);

            tabCodigoRojo.Enabled = false;
            (DNovedadCiudadano respuestaNovedad, string errorResponse) = await nNovedadCiudadano.CrearNovedad(dataNovedad);
            tabCodigoRojo.Enabled = true;

            if (respuestaNovedad != null)
            {
                MessageBox.Show("La novedad se guardo correctamente", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtNuevaNovedad.Enabled = false;
                txtNuevaNovedad.Text = "";
                btnNuevaNovedad.Enabled = true;
                btnGuardarNovedad.Enabled = false;
                btnCancelarNovedad.Enabled = false;

                //cargar lista de ciudadanos en datagrid
                this.CargarDataGridNovedades();
            }
            else
            {
                MessageBox.Show(errorResponse, "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnCancelarNovedad_Click(object sender, EventArgs e)
        {
            //limpiar errores de provider
            errorProvider.Clear();

            txtNuevaNovedad.Enabled = false;
            txtNuevaNovedad.Text = "";
            btnNuevaNovedad.Enabled = true;
            btnGuardarNovedad.Enabled = false;
            btnCancelarNovedad.Enabled = false;
        }

        private void btnVerExcepciones_Click(object sender, EventArgs e)
        {
            this.CargarDataGridExcepciones();
        }



        private void dtgvExcepcionesIngreso_KeyDown(object sender, KeyEventArgs e)
        {
            //AL PRESIONAR ENTER MOSTRAR EL TRAMITE
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (dtgvExcepcionesIngreso.SelectedRows.Count > 0)
                {
                    int id_excepcion_ingreso;
                    id_excepcion_ingreso = Convert.ToInt32(dtgvExcepcionesIngreso.CurrentRow.Cells["ID"].Value.ToString());

                    if (id_excepcion_ingreso > 0)
                    {
                        //deshabilitar controles
                        //this.HabilitarControlesExcepcion(false);
                        //this.HabilitarControlesCumplimentarAnularExcepcion(false);

                        //cargar datos de datagrid a controles
                        txtIdExcepcion.Text = id_excepcion_ingreso.ToString();
                        txtMotivoExcepcion.Text = dtgvExcepcionesIngreso.CurrentRow.Cells["MotivoExcepcion"].Value.ToString();
                        txtDetalleExcepcion.Text = dtgvExcepcionesIngreso.CurrentRow.Cells["Detalle"].Value.ToString();
                        txtInternoExcepcion.Text = dtgvExcepcionesIngreso.CurrentRow.Cells["Interno"].Value.ToString();
                        dtpFechaExcepcion.Value = Convert.ToDateTime(dtgvExcepcionesIngreso.CurrentRow.Cells["FechaExcepcion"].Value.ToString());
                        txtOrganismoExepcion.Text = dtgvExcepcionesIngreso.CurrentRow.Cells["Organismo"].Value.ToString();
                        txtUsuarioCargaExcepcion.Text = dtgvExcepcionesIngreso.CurrentRow.Cells["Usuario"].Value.ToString();
                        chkCumplimentadoExcepcion.Checked = Convert.ToBoolean(dtgvExcepcionesIngreso.CurrentRow.Cells["Cumplimentado"].Value.ToString());

                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar una excepcion.", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        //METODO PARA OBTENER LA LISTA DE NOVEDADES Y CARGARLO EN UN DATA GRID
        async private void CargarDataGridNovedades()
        {
            NNovedadCiudadano nNovedadCiudadano = new NNovedadCiudadano();

            (List<DNovedadCiudadano> listaNovedades, string errorResponse) = await nNovedadCiudadano.RetornarListaNovedadesCiudadano(this.dCiudadano.id_ciudadano);

            if (listaNovedades == null)
            {
                MessageBox.Show(errorResponse, "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var datosfiltrados = listaNovedades
                .Select(c => new
                {
                    Id = c.id_novedad_ciudadano,
                    Novedad = c.novedad,
                    Detalle = c.novedad_detalle,
                    FechaNovedad = c.fecha_novedad,
                    Organismo = c.organismo.organismo,
                    Usuario = c.usuario.apellido + " " + c.usuario.nombre

                })
                .ToList();

            dtgvNovedades.DataSource = datosfiltrados;

            if (listaNovedades.Count == 0)
            {
                MessageBox.Show("No se encontraron registros", "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {

                dtgvNovedades.Columns[1].Width = 200;
                dtgvNovedades.Columns[2].Width = 400;
            }
        }//FIN METODO PARA OBTENER LA LISTA DE NOVEDADES EN UN DATA GRID ...........


        //METODO PARA OBTENER LA LISTA DE EXCEPCIONES Y CARGARLO EN UN DATA GRID
        async private void CargarDataGridExcepciones()
        {
            NExcepcionIngresoVisita nExcepcionIngresoVisita = new NExcepcionIngresoVisita();

            (List<DExcepcionIngresoVisita> listaExcepcionesIngreso, string errorResponse) = await nExcepcionIngresoVisita.ListaExcepcionesIngreso(this.dCiudadano.id_ciudadano);

            if (listaExcepcionesIngreso == null)
            {
                MessageBox.Show(errorResponse, "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var datosfiltrados = listaExcepcionesIngreso
                .Select(c => new
                {
                    Id = c.id_excepcion_ingreso_visita,
                    FechaExcepcion = c.fecha_excepcion,
                    MotivoExcepcion = c.motivo,
                    Detalle = c.detalle_excepcion,
                    Interno = c.interno.apellido + " " + c.interno.nombre,
                    FechaCarga = c.fecha_carga,
                    Organismo = c.organismo.organismo,
                    Usuario = c.usuario_carga.apellido + " " + c.usuario_carga.nombre,
                    Cumplimentado = c.cumplimentado,
                    Controlado = c.controlado,
                    Anulado = c.anulado

                })
                .ToList();

            dtgvExcepcionesIngreso.DataSource = datosfiltrados;

            if (listaExcepcionesIngreso.Count == 0)
            {
                MessageBox.Show("No se encontraron registros", "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {

                dtgvExcepcionesIngreso.Columns[2].Width = 200;
                dtgvExcepcionesIngreso.Columns[3].Width = 400;
            }
        }//FIN METODO PARA OBTENER LA LISTA DE EXCEPCIONES Y CARGARLO EN UN DATA GRID.....................................

        private async void btnImprimirVinculos_Click(object sender, EventArgs e)
        {
            NVisitaInterno nVisitaInterno = new NVisitaInterno();

            (List<DVisitaInterno> listaParentescos, string errorResponse) = await nVisitaInterno.retornarListaVisitaInternoXCiudadano(this.dCiudadano.id_ciudadano);

            if (listaParentescos == null)
            {
                MessageBox.Show(errorResponse, "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Generar PDF en memoria
            MemoryStream msOriginal = ReportesAdminVisitaPDF.RepPdfInternosVinculados(this.dCiudadano, listaParentescos);

            // Clonar el stream para que PdfiumViewer pueda cerrarlo sin afectar el original
            MemoryStream ms = new MemoryStream(msOriginal.ToArray());

            PdfDocument pdfDocument = null;

            try
            {
                pdfDocument = PdfDocument.Load(ms);

                Form formVisor = new Form
                {
                    Text = "Vista previa PDF",
                    Width = 800,
                    Height = 600
                };

                PdfViewer pdfViewer = new PdfViewer
                {
                    Dock = DockStyle.Fill,
                    Document = pdfDocument
                };

                formVisor.Controls.Add(pdfViewer);

                formVisor.FormClosed += (s, args) =>
                {
                    // Liberar recursos al cerrar el visor
                    pdfViewer.Document.Dispose();
                    pdfViewer.Dispose();
                    formVisor.Dispose();
                    ms.Dispose();
                    pdfDocument = null;
                };

                formVisor.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar PDF: " + ex.Message);
                ms.Dispose();
                pdfDocument?.Dispose();
            }
        }

        private async  void button4_Click_1(object sender, EventArgs e)
        {
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


            DCiudadano dCiudadano = new DCiudadano();
            //SaveFileDialog solicita al usuario que busqeu un lugar para guardar un archivo
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.FileName = DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf";//gaurda el archivo con el nombre de la fecha del dia concatenado con la hora .pdf
                                                                                //guardar.ShowDialog();//ejecuta un cuadro de dialogo

            string varSexo = Convert.ToString(cmbSexo.Text);
            //MessageBox.Show(varSexo);
            /*La forma para trabajar u archivo .pdf, o al menos el diseño que va a tener el pdf, en el video lo trabajan 
            es en que se puedan cambiar y modificar por un largo tiempo. La forma es creando un archivo html, en donde se diseña una tabla
            con el ancho de las columnas y todo lo necesarrio para crear las tablas, trabajando totalmente el html, y en base a este archivo
            generar un pdf*/

            string paginahtml_texto = Properties.Resources.plantilla.ToString();
            //vamos a reemplazar los parametros por los valores de los formularios
            paginahtml_texto = paginahtml_texto.Replace("@DNI", Convert.ToString(dCiudadano2.dni));
            paginahtml_texto = paginahtml_texto.Replace("@NOMBRE", (dCiudadano2.apellido) + " " + (dCiudadano2.nombre));
            paginahtml_texto = paginahtml_texto.Replace("@DOMICILIO", (dCiudadano2.direccion) + " " + (dCiudadano2.numero_dom));
            paginahtml_texto = paginahtml_texto.Replace("@NACIONALIDAD", (dCiudadano2.nacionalidad.nacionalidad));
            paginahtml_texto = paginahtml_texto.Replace("@FECHA_ALTA", Convert.ToString(dCiudadano2.fecha_alta));
            paginahtml_texto = paginahtml_texto.Replace("@ESTADO_CIVIL", Convert.ToString(dCiudadano2.estado_civil.estado_civil));
            paginahtml_texto = paginahtml_texto.Replace("@NACIMIENTO", Convert.ToString(dCiudadano2.fecha_nac));
            paginahtml_texto = paginahtml_texto.Replace("@TELEFONO", (dCiudadano2.telefono));
            paginahtml_texto = paginahtml_texto.Replace("@SEXO", dCiudadano2.sexo.sexo);
            //paginahtml_texto = paginahtml_texto.Replace("@PARENTEZCO", Convert.ToString(data));


            //vamos a hacer elguardado del archivo si cumple todos los requisitos
            if (guardar.ShowDialog() == DialogResult.OK)
            {
                //primero vamos a guardar el archivo pdf en un archivo de memoria
                using (FileStream stream = new FileStream(guardar.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25); //archivo .pdf tamaño A4 con margenes de 25 para los lados
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();//necesitamos abrir el archivo para agregar los textos
                                  //pdfDoc.Add(new Phrase("Hola a todos"));

                    using (StringReader sr = new StringReader(paginahtml_texto))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }

                    pdfDoc.Close();
                    stream.Close();
                }

            }


        }

        private async void btnVerProhibiciones_Click(object sender, EventArgs e)
        {
            NProhibicionVisita nProhibicionVisita = new NProhibicionVisita();
            (List<DProhibicionVisita> listaProhibicionesVisita, string errorResponse) = await nProhibicionVisita.RetornarListaProhibicionesVisita(this.dCiudadano.id_ciudadano);

            if (listaProhibicionesVisita == null)
            {
                MessageBox.Show(errorResponse, "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var datosfiltrados = listaProhibicionesVisita
                .Select(c => new
                {
                    Id = c.id_prohibicion_visita,
                    Disposicion = c.disposicion,
                    Detalle = c.detalle,
                    FechaInicio = c.fecha_inicio,
                    FechaFin = c.fecha_fin,
                    FechaProhibicion = c.fecha_prohibicion,
                    Organismo = c.organismo.organismo,
                    Prohibida = c.vigente,
                    TipoLevantamiento = c.tipo_levantamiento,
                    Anulado = c.anulado

                })
                .ToList();

            dtgvProhibiciones.DataSource = datosfiltrados;

            if (listaProhibicionesVisita.Count == 0)
            {
                MessageBox.Show("No se encontraron registros", "Restrición Visitas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {

                dtgvProhibiciones.Columns[2].Width = 300;
            }

            foreach (DataGridViewRow row in dtgvProhibiciones.Rows)
            {
                if (row.Cells["Prohibida"].Value != null && Convert.ToBoolean(row.Cells["Prohibida"].Value) == true)
                {
                    row.DefaultCellStyle.BackColor = Color.Orange; // Cambiar color de fondo
                    row.DefaultCellStyle.ForeColor = Color.Black;    // Cambiar color del texto
                }

                if (row.Cells["Anulado"].Value != null && Convert.ToBoolean(row.Cells["Anulado"].Value) == true)
                {
                    row.DefaultCellStyle.BackColor = Color.Black; // Cambiar color de fondo
                    row.DefaultCellStyle.ForeColor = Color.White;    // Cambiar color del texto
                }
            }
        }

        private void dtgvProhibiciones_KeyDown(object sender, KeyEventArgs e)
        {
            //AL PRESIONAR ENTER MOSTRAR EL TRAMITE
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                                

                if (dtgvProhibiciones.SelectedRows.Count > 0)
                {
                    int idProhibicion;
                    idProhibicion = Convert.ToInt32(dtgvProhibiciones.CurrentRow.Cells["ID"].Value.ToString());

                    if (idProhibicion > 0)
                    {
                        txtIdProhibicion.Text = idProhibicion.ToString();
                        txtDisposicion.Text = dtgvProhibiciones.CurrentRow.Cells["Disposicion"].Value.ToString();
                        txtDetalle.Text = dtgvProhibiciones.CurrentRow.Cells["Detalle"].Value.ToString();
                        dtpFechaInicio.Value = Convert.ToDateTime(dtgvProhibiciones.CurrentRow.Cells["FechaInicio"].Value.ToString());
                        dtpFechaFin.Value = Convert.ToDateTime(dtgvProhibiciones.CurrentRow.Cells["FechaFin"].Value.ToString());
                        txtOrganismo.Text = dtgvProhibiciones.CurrentRow.Cells["Organismo"].Value.ToString();
                        dtpFechaProhibicion.Value = Convert.ToDateTime(dtgvProhibiciones.CurrentRow.Cells["FechaProhibicion"].Value.ToString());
                        chkVigente.Checked = Convert.ToBoolean(dtgvProhibiciones.CurrentRow.Cells["Prohibida"].Value.ToString());
                        chkAnulado.Checked = Convert.ToBoolean(dtgvProhibiciones.CurrentRow.Cells["Anulado"].Value.ToString());


                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar una prohibición.", "Restricción Visitas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnQuitarDiscapacidad_Click(object sender, EventArgs e)
        {

        }

        private void btnHistorialCategorias_Click(object sender, EventArgs e)
        {
            this.CargarCategoriasHistoricaDelCiudadano();
        }
    }

}
