namespace CapaPresentacion
{
    partial class frmIngresoAbogados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIngresoAbogados));
            this.dgvListadoInternos = new System.Windows.Forms.DataGridView();
            this.txtIdAbogadoIngreso = new System.Windows.Forms.TextBox();
            this.txtDniAbogado = new System.Windows.Forms.TextBox();
            this.txtNombreAbogado = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTipoAbogado = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBuscarInternos = new System.Windows.Forms.TextBox();
            this.btnBuscarInternos = new System.Windows.Forms.Button();
            this.dgvInternos = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIdInterno = new System.Windows.Forms.TextBox();
            this.btnIngresarAbogado = new System.Windows.Forms.Button();
            this.btnHistorialIngresos = new System.Windows.Forms.Button();
            this.btnEstablecerAbogado = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoInternos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListadoInternos
            // 
            this.dgvListadoInternos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListadoInternos.Location = new System.Drawing.Point(65, 229);
            this.dgvListadoInternos.Name = "dgvListadoInternos";
            this.dgvListadoInternos.Size = new System.Drawing.Size(1031, 391);
            this.dgvListadoInternos.TabIndex = 0;
            // 
            // txtIdAbogadoIngreso
            // 
            this.txtIdAbogadoIngreso.Location = new System.Drawing.Point(99, 18);
            this.txtIdAbogadoIngreso.Name = "txtIdAbogadoIngreso";
            this.txtIdAbogadoIngreso.Size = new System.Drawing.Size(205, 20);
            this.txtIdAbogadoIngreso.TabIndex = 1;
            // 
            // txtDniAbogado
            // 
            this.txtDniAbogado.Location = new System.Drawing.Point(99, 44);
            this.txtDniAbogado.Name = "txtDniAbogado";
            this.txtDniAbogado.Size = new System.Drawing.Size(205, 20);
            this.txtDniAbogado.TabIndex = 2;
            // 
            // txtNombreAbogado
            // 
            this.txtNombreAbogado.Location = new System.Drawing.Point(99, 70);
            this.txtNombreAbogado.Name = "txtNombreAbogado";
            this.txtNombreAbogado.Size = new System.Drawing.Size(205, 20);
            this.txtNombreAbogado.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(310, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(84, 86);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Id Abogado:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Dni Abogado:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Nombre Abogado:";
            // 
            // cmbTipoAbogado
            // 
            this.cmbTipoAbogado.FormattingEnabled = true;
            this.cmbTipoAbogado.Location = new System.Drawing.Point(505, 18);
            this.cmbTipoAbogado.Name = "cmbTipoAbogado";
            this.cmbTipoAbogado.Size = new System.Drawing.Size(183, 21);
            this.cmbTipoAbogado.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(407, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Tipo de Defensor:";
            // 
            // txtBuscarInternos
            // 
            this.txtBuscarInternos.Location = new System.Drawing.Point(879, 20);
            this.txtBuscarInternos.Name = "txtBuscarInternos";
            this.txtBuscarInternos.Size = new System.Drawing.Size(163, 20);
            this.txtBuscarInternos.TabIndex = 11;
            // 
            // btnBuscarInternos
            // 
            this.btnBuscarInternos.BackColor = System.Drawing.Color.White;
            this.btnBuscarInternos.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarInternos.Image")));
            this.btnBuscarInternos.Location = new System.Drawing.Point(1048, 15);
            this.btnBuscarInternos.Name = "btnBuscarInternos";
            this.btnBuscarInternos.Size = new System.Drawing.Size(31, 29);
            this.btnBuscarInternos.TabIndex = 12;
            this.btnBuscarInternos.UseVisualStyleBackColor = false;
            this.btnBuscarInternos.Click += new System.EventHandler(this.btnBuscarInternos_Click);
            // 
            // dgvInternos
            // 
            this.dgvInternos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternos.Location = new System.Drawing.Point(770, 52);
            this.dgvInternos.Name = "dgvInternos";
            this.dgvInternos.Size = new System.Drawing.Size(373, 86);
            this.dgvInternos.TabIndex = 13;
            this.dgvInternos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvInternos_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(786, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Buscar Internos:";
            // 
            // txtIdInterno
            // 
            this.txtIdInterno.Location = new System.Drawing.Point(744, 18);
            this.txtIdInterno.Name = "txtIdInterno";
            this.txtIdInterno.Size = new System.Drawing.Size(36, 20);
            this.txtIdInterno.TabIndex = 15;
            // 
            // btnIngresarAbogado
            // 
            this.btnIngresarAbogado.BackColor = System.Drawing.Color.White;
            this.btnIngresarAbogado.Image = ((System.Drawing.Image)(resources.GetObject("btnIngresarAbogado.Image")));
            this.btnIngresarAbogado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIngresarAbogado.Location = new System.Drawing.Point(432, 169);
            this.btnIngresarAbogado.Name = "btnIngresarAbogado";
            this.btnIngresarAbogado.Size = new System.Drawing.Size(219, 34);
            this.btnIngresarAbogado.TabIndex = 16;
            this.btnIngresarAbogado.Text = "Ingresar Abogado";
            this.btnIngresarAbogado.UseVisualStyleBackColor = false;
            this.btnIngresarAbogado.Click += new System.EventHandler(this.btnIngresarAbogado_Click);
            // 
            // btnHistorialIngresos
            // 
            this.btnHistorialIngresos.BackColor = System.Drawing.Color.White;
            this.btnHistorialIngresos.Image = ((System.Drawing.Image)(resources.GetObject("btnHistorialIngresos.Image")));
            this.btnHistorialIngresos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHistorialIngresos.Location = new System.Drawing.Point(207, 169);
            this.btnHistorialIngresos.Name = "btnHistorialIngresos";
            this.btnHistorialIngresos.Size = new System.Drawing.Size(219, 34);
            this.btnHistorialIngresos.TabIndex = 17;
            this.btnHistorialIngresos.Text = "Ver internos vinculados";
            this.btnHistorialIngresos.UseVisualStyleBackColor = false;
            this.btnHistorialIngresos.Click += new System.EventHandler(this.btnHistorialIngresos_Click);
            // 
            // btnEstablecerAbogado
            // 
            this.btnEstablecerAbogado.BackColor = System.Drawing.Color.White;
            this.btnEstablecerAbogado.Image = ((System.Drawing.Image)(resources.GetObject("btnEstablecerAbogado.Image")));
            this.btnEstablecerAbogado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEstablecerAbogado.Location = new System.Drawing.Point(657, 169);
            this.btnEstablecerAbogado.Name = "btnEstablecerAbogado";
            this.btnEstablecerAbogado.Size = new System.Drawing.Size(251, 34);
            this.btnEstablecerAbogado.TabIndex = 18;
            this.btnEstablecerAbogado.Text = "Asignar como abogado del interno";
            this.btnEstablecerAbogado.UseVisualStyleBackColor = false;
            this.btnEstablecerAbogado.Click += new System.EventHandler(this.btnEstablecerAbogado_Click);
            // 
            // frmIngresoAbogados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 662);
            this.Controls.Add(this.btnEstablecerAbogado);
            this.Controls.Add(this.btnHistorialIngresos);
            this.Controls.Add(this.btnIngresarAbogado);
            this.Controls.Add(this.txtIdInterno);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvInternos);
            this.Controls.Add(this.btnBuscarInternos);
            this.Controls.Add(this.txtBuscarInternos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbTipoAbogado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtNombreAbogado);
            this.Controls.Add(this.txtDniAbogado);
            this.Controls.Add(this.txtIdAbogadoIngreso);
            this.Controls.Add(this.dgvListadoInternos);
            this.Name = "frmIngresoAbogados";
            this.Text = "Formulario de Ingreso de Abogados";
            this.Load += new System.EventHandler(this.frmIngresoAbogados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoInternos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListadoInternos;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.TextBox txtIdAbogadoIngreso;
        public System.Windows.Forms.TextBox txtDniAbogado;
        public System.Windows.Forms.TextBox txtNombreAbogado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbTipoAbogado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBuscarInternos;
        private System.Windows.Forms.Button btnBuscarInternos;
        private System.Windows.Forms.DataGridView dgvInternos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIdInterno;
        private System.Windows.Forms.Button btnIngresarAbogado;
        private System.Windows.Forms.Button btnHistorialIngresos;
        private System.Windows.Forms.Button btnEstablecerAbogado;
    }
}