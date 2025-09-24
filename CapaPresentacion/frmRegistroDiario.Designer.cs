namespace CapaPresentacion
{
    partial class frmRegistroDiario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistroDiario));
            this.txtBuscarApellido = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.cmbTipoAcceso = new System.Windows.Forms.ComboBox();
            this.label30 = new System.Windows.Forms.Label();
            this.cmbSector = new System.Windows.Forms.ComboBox();
            this.cmbOrganismoDestino = new System.Windows.Forms.ComboBox();
            this.lblCartel = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.txtNacionalidad = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.cmbTipoAtencion = new System.Windows.Forms.ComboBox();
            this.txtNombreCiudadanoIngreso = new System.Windows.Forms.Label();
            this.txtDniCiudadanoIngreso = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.txtNombreCiudadano = new System.Windows.Forms.TextBox();
            this.txtDocumentoIdentidad = new System.Windows.Forms.TextBox();
            this.txtIdCiudadanoIngreso = new System.Windows.Forms.TextBox();
            this.dgvCiudadanosRegistroDiario = new System.Windows.Forms.DataGridView();
            this.cmbMotivoAtencion = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBuscarInternos = new System.Windows.Forms.Button();
            this.btnCrearRegistroDiario = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ptbFotoCiudadano = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBuscarInternos = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.dtpFechaRegistroDiario = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtProfesion = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCiudadanosRegistroDiario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbFotoCiudadano)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBuscarApellido
            // 
            this.txtBuscarApellido.Location = new System.Drawing.Point(120, 46);
            this.txtBuscarApellido.Name = "txtBuscarApellido";
            this.txtBuscarApellido.Size = new System.Drawing.Size(281, 20);
            this.txtBuscarApellido.TabIndex = 0;
            this.txtBuscarApellido.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscarApellido_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(26, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ingresar Apellido:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(487, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ingresar DNI:";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(563, 43);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(159, 20);
            this.textBox2.TabIndex = 2;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(18, 590);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(70, 13);
            this.label33.TabIndex = 43;
            this.label33.Text = "Tipo Acceso:";
            // 
            // cmbTipoAcceso
            // 
            this.cmbTipoAcceso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoAcceso.FormattingEnabled = true;
            this.cmbTipoAcceso.Location = new System.Drawing.Point(101, 588);
            this.cmbTipoAcceso.Name = "cmbTipoAcceso";
            this.cmbTipoAcceso.Size = new System.Drawing.Size(251, 21);
            this.cmbTipoAcceso.TabIndex = 40;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(12, 561);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(70, 13);
            this.label30.TabIndex = 38;
            this.label30.Text = "Acceso Tipo:";
            // 
            // cmbSector
            // 
            this.cmbSector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSector.FormattingEnabled = true;
            this.cmbSector.Location = new System.Drawing.Point(437, 590);
            this.cmbSector.Name = "cmbSector";
            this.cmbSector.Size = new System.Drawing.Size(280, 21);
            this.cmbSector.TabIndex = 37;
            // 
            // cmbOrganismoDestino
            // 
            this.cmbOrganismoDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrganismoDestino.FormattingEnabled = true;
            this.cmbOrganismoDestino.Location = new System.Drawing.Point(436, 558);
            this.cmbOrganismoDestino.Name = "cmbOrganismoDestino";
            this.cmbOrganismoDestino.Size = new System.Drawing.Size(281, 21);
            this.cmbOrganismoDestino.TabIndex = 36;
            this.cmbOrganismoDestino.SelectedIndexChanged += new System.EventHandler(this.cmbOrganismoDestino_SelectedIndexChanged);
            // 
            // lblCartel
            // 
            this.lblCartel.AutoSize = true;
            this.lblCartel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblCartel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCartel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCartel.ForeColor = System.Drawing.Color.Red;
            this.lblCartel.Location = new System.Drawing.Point(17, 343);
            this.lblCartel.Name = "lblCartel";
            this.lblCartel.Size = new System.Drawing.Size(524, 33);
            this.lblCartel.TabIndex = 33;
            this.lblCartel.Text = "No Presenta ningun tipo de Restricción";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label29.Location = new System.Drawing.Point(218, 301);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(72, 13);
            this.label29.TabIndex = 31;
            this.label29.Text = "Nacionalidad:";
            // 
            // txtNacionalidad
            // 
            this.txtNacionalidad.Location = new System.Drawing.Point(346, 294);
            this.txtNacionalidad.Name = "txtNacionalidad";
            this.txtNacionalidad.Size = new System.Drawing.Size(226, 20);
            this.txtNacionalidad.TabIndex = 30;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(360, 561);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(63, 13);
            this.label28.TabIndex = 29;
            this.label28.Text = " Organismo:";
            // 
            // cmbTipoAtencion
            // 
            this.cmbTipoAtencion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoAtencion.FormattingEnabled = true;
            this.cmbTipoAtencion.Location = new System.Drawing.Point(101, 558);
            this.cmbTipoAtencion.Name = "cmbTipoAtencion";
            this.cmbTipoAtencion.Size = new System.Drawing.Size(251, 21);
            this.cmbTipoAtencion.TabIndex = 28;
            // 
            // txtNombreCiudadanoIngreso
            // 
            this.txtNombreCiudadanoIngreso.AutoSize = true;
            this.txtNombreCiudadanoIngreso.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtNombreCiudadanoIngreso.Location = new System.Drawing.Point(218, 271);
            this.txtNombreCiudadanoIngreso.Name = "txtNombreCiudadanoIngreso";
            this.txtNombreCiudadanoIngreso.Size = new System.Drawing.Size(101, 13);
            this.txtNombreCiudadanoIngreso.TabIndex = 27;
            this.txtNombreCiudadanoIngreso.Text = "Nombre Ciudadano:";
            // 
            // txtDniCiudadanoIngreso
            // 
            this.txtDniCiudadanoIngreso.AutoSize = true;
            this.txtDniCiudadanoIngreso.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtDniCiudadanoIngreso.Location = new System.Drawing.Point(218, 242);
            this.txtDniCiudadanoIngreso.Name = "txtDniCiudadanoIngreso";
            this.txtDniCiudadanoIngreso.Size = new System.Drawing.Size(127, 13);
            this.txtDniCiudadanoIngreso.TabIndex = 26;
            this.txtDniCiudadanoIngreso.Text = "Documento de Identidad:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label27.Location = new System.Drawing.Point(218, 216);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(73, 13);
            this.label27.TabIndex = 25;
            this.label27.Text = "Id Ciudadano:";
            // 
            // txtNombreCiudadano
            // 
            this.txtNombreCiudadano.Enabled = false;
            this.txtNombreCiudadano.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreCiudadano.Location = new System.Drawing.Point(346, 268);
            this.txtNombreCiudadano.Name = "txtNombreCiudadano";
            this.txtNombreCiudadano.Size = new System.Drawing.Size(226, 20);
            this.txtNombreCiudadano.TabIndex = 24;
            // 
            // txtDocumentoIdentidad
            // 
            this.txtDocumentoIdentidad.Enabled = false;
            this.txtDocumentoIdentidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocumentoIdentidad.Location = new System.Drawing.Point(346, 242);
            this.txtDocumentoIdentidad.Name = "txtDocumentoIdentidad";
            this.txtDocumentoIdentidad.Size = new System.Drawing.Size(226, 20);
            this.txtDocumentoIdentidad.TabIndex = 23;
            // 
            // txtIdCiudadanoIngreso
            // 
            this.txtIdCiudadanoIngreso.Enabled = false;
            this.txtIdCiudadanoIngreso.Location = new System.Drawing.Point(346, 216);
            this.txtIdCiudadanoIngreso.Name = "txtIdCiudadanoIngreso";
            this.txtIdCiudadanoIngreso.Size = new System.Drawing.Size(226, 20);
            this.txtIdCiudadanoIngreso.TabIndex = 22;
            // 
            // dgvCiudadanosRegistroDiario
            // 
            this.dgvCiudadanosRegistroDiario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCiudadanosRegistroDiario.Location = new System.Drawing.Point(17, 76);
            this.dgvCiudadanosRegistroDiario.Name = "dgvCiudadanosRegistroDiario";
            this.dgvCiudadanosRegistroDiario.Size = new System.Drawing.Size(769, 114);
            this.dgvCiudadanosRegistroDiario.TabIndex = 45;
            this.dgvCiudadanosRegistroDiario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvCiudadanosRegistroDiario_KeyDown);
            // 
            // cmbMotivoAtencion
            // 
            this.cmbMotivoAtencion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMotivoAtencion.FormattingEnabled = true;
            this.cmbMotivoAtencion.Location = new System.Drawing.Point(827, 558);
            this.cmbMotivoAtencion.Name = "cmbMotivoAtencion";
            this.cmbMotivoAtencion.Size = new System.Drawing.Size(307, 21);
            this.cmbMotivoAtencion.TabIndex = 52;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(727, 559);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 53;
            this.label3.Text = "Motivo Atención:";
            // 
            // btnBuscarInternos
            // 
            this.btnBuscarInternos.BackColor = System.Drawing.Color.White;
            this.btnBuscarInternos.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarInternos.Image")));
            this.btnBuscarInternos.Location = new System.Drawing.Point(634, 52);
            this.btnBuscarInternos.Name = "btnBuscarInternos";
            this.btnBuscarInternos.Size = new System.Drawing.Size(39, 33);
            this.btnBuscarInternos.TabIndex = 50;
            this.btnBuscarInternos.UseVisualStyleBackColor = false;
            this.btnBuscarInternos.Click += new System.EventHandler(this.btnBuscarInternos_Click);
            // 
            // btnCrearRegistroDiario
            // 
            this.btnCrearRegistroDiario.BackColor = System.Drawing.Color.White;
            this.btnCrearRegistroDiario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearRegistroDiario.Image = ((System.Drawing.Image)(resources.GetObject("btnCrearRegistroDiario.Image")));
            this.btnCrearRegistroDiario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCrearRegistroDiario.Location = new System.Drawing.Point(451, 617);
            this.btnCrearRegistroDiario.Name = "btnCrearRegistroDiario";
            this.btnCrearRegistroDiario.Size = new System.Drawing.Size(234, 43);
            this.btnCrearRegistroDiario.TabIndex = 51;
            this.btnCrearRegistroDiario.Text = "Registrar Ingreso";
            this.btnCrearRegistroDiario.UseCompatibleTextRendering = true;
            this.btnCrearRegistroDiario.UseVisualStyleBackColor = false;
            this.btnCrearRegistroDiario.Click += new System.EventHandler(this.btnCrearRegistroDiario_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(407, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(39, 34);
            this.button1.TabIndex = 44;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ptbFotoCiudadano
            // 
            this.ptbFotoCiudadano.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ptbFotoCiudadano.Image = ((System.Drawing.Image)(resources.GetObject("ptbFotoCiudadano.Image")));
            this.ptbFotoCiudadano.Location = new System.Drawing.Point(577, 210);
            this.ptbFotoCiudadano.Name = "ptbFotoCiudadano";
            this.ptbFotoCiudadano.Size = new System.Drawing.Size(162, 160);
            this.ptbFotoCiudadano.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbFotoCiudadano.TabIndex = 32;
            this.ptbFotoCiudadano.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnBuscarInternos);
            this.panel1.Controls.Add(this.txtBuscarInternos);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(127, 404);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(825, 124);
            this.panel1.TabIndex = 55;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(312, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(198, 24);
            this.label4.TabIndex = 51;
            this.label4.Text = "Seleccionar Interno:";
            // 
            // txtBuscarInternos
            // 
            this.txtBuscarInternos.Location = new System.Drawing.Point(83, 59);
            this.txtBuscarInternos.Name = "txtBuscarInternos";
            this.txtBuscarInternos.Size = new System.Drawing.Size(543, 20);
            this.txtBuscarInternos.TabIndex = 42;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(733, 592);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 57;
            this.label6.Text = "Observaciones:";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(827, 590);
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(313, 20);
            this.txtObservaciones.TabIndex = 58;
            // 
            // dtpFechaRegistroDiario
            // 
            this.dtpFechaRegistroDiario.Location = new System.Drawing.Point(962, 12);
            this.dtpFechaRegistroDiario.Name = "dtpFechaRegistroDiario";
            this.dtpFechaRegistroDiario.Size = new System.Drawing.Size(239, 20);
            this.dtpFechaRegistroDiario.TabIndex = 59;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtProfesion);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.dgvCiudadanosRegistroDiario);
            this.panel2.Controls.Add(this.lblCartel);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtBuscarApellido);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Controls.Add(this.ptbFotoCiudadano);
            this.panel2.Location = new System.Drawing.Point(127, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(823, 386);
            this.panel2.TabIndex = 60;
            // 
            // txtProfesion
            // 
            this.txtProfesion.Location = new System.Drawing.Point(218, 312);
            this.txtProfesion.Name = "txtProfesion";
            this.txtProfesion.Size = new System.Drawing.Size(225, 20);
            this.txtProfesion.TabIndex = 54;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(90, 318);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 53;
            this.label8.Text = "Profesión:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(298, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(234, 24);
            this.label5.TabIndex = 52;
            this.label5.Text = "Seleccionar Ciudadano:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(363, 591);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 61;
            this.label7.Text = "Sector:";
            // 
            // frmRegistroDiario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMargin = new System.Drawing.Size(5, 0);
            this.ClientSize = new System.Drawing.Size(1221, 681);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtpFechaRegistroDiario);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbMotivoAtencion);
            this.Controls.Add(this.btnCrearRegistroDiario);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.cmbTipoAcceso);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.cmbSector);
            this.Controls.Add(this.cmbOrganismoDestino);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.txtNacionalidad);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.cmbTipoAtencion);
            this.Controls.Add(this.txtNombreCiudadanoIngreso);
            this.Controls.Add(this.txtDniCiudadanoIngreso);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.txtNombreCiudadano);
            this.Controls.Add(this.txtDocumentoIdentidad);
            this.Controls.Add(this.txtIdCiudadanoIngreso);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRegistroDiario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulario Registro Diario";
            this.Load += new System.EventHandler(this.frmRegistroDiario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCiudadanosRegistroDiario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbFotoCiudadano)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBuscarApellido;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.ComboBox cmbTipoAcceso;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.ComboBox cmbSector;
        private System.Windows.Forms.ComboBox cmbOrganismoDestino;
        private System.Windows.Forms.Label lblCartel;
        private System.Windows.Forms.PictureBox ptbFotoCiudadano;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txtNacionalidad;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ComboBox cmbTipoAtencion;
        private System.Windows.Forms.Label txtNombreCiudadanoIngreso;
        private System.Windows.Forms.Label txtDniCiudadanoIngreso;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtNombreCiudadano;
        private System.Windows.Forms.TextBox txtDocumentoIdentidad;
        private System.Windows.Forms.TextBox txtIdCiudadanoIngreso;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvCiudadanosRegistroDiario;
        private System.Windows.Forms.Button btnBuscarInternos;
        private System.Windows.Forms.Button btnCrearRegistroDiario;
        private System.Windows.Forms.ComboBox cmbMotivoAtencion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.DateTimePicker dtpFechaRegistroDiario;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtProfesion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtBuscarInternos;
    }
}