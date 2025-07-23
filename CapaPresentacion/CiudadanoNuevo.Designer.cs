namespace CapaPresentacion
{
    partial class CiudadanoNuevo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CiudadanoNuevo));
            this.dataListadoCiudadanos = new System.Windows.Forms.DataGridView();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnAdministrarCiudadano = new System.Windows.Forms.Button();
            this.txtBuscarApellido = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBuscarDni = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataListadoCiudadanos)).BeginInit();
            this.SuspendLayout();
            // 
            // dataListadoCiudadanos
            // 
            this.dataListadoCiudadanos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListadoCiudadanos.Location = new System.Drawing.Point(12, 160);
            this.dataListadoCiudadanos.Name = "dataListadoCiudadanos";
            this.dataListadoCiudadanos.Size = new System.Drawing.Size(920, 361);
            this.dataListadoCiudadanos.TabIndex = 16;
            this.dataListadoCiudadanos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataListadoCiudadanos.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            this.dataListadoCiudadanos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataListadoCiudadanos_KeyDown);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.White;
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.Location = new System.Drawing.Point(86, 117);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(146, 37);
            this.btnNuevo.TabIndex = 35;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnAdministrarCiudadano
            // 
            this.btnAdministrarCiudadano.BackColor = System.Drawing.Color.White;
            this.btnAdministrarCiudadano.Image = ((System.Drawing.Image)(resources.GetObject("btnAdministrarCiudadano.Image")));
            this.btnAdministrarCiudadano.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdministrarCiudadano.Location = new System.Drawing.Point(238, 117);
            this.btnAdministrarCiudadano.Name = "btnAdministrarCiudadano";
            this.btnAdministrarCiudadano.Size = new System.Drawing.Size(205, 37);
            this.btnAdministrarCiudadano.TabIndex = 36;
            this.btnAdministrarCiudadano.Text = "Administrar Ciudadano";
            this.btnAdministrarCiudadano.UseVisualStyleBackColor = false;
            this.btnAdministrarCiudadano.Click += new System.EventHandler(this.btnAdministrarCiudadano_Click);
            // 
            // txtBuscarApellido
            // 
            this.txtBuscarApellido.Location = new System.Drawing.Point(134, 51);
            this.txtBuscarApellido.Name = "txtBuscarApellido";
            this.txtBuscarApellido.Size = new System.Drawing.Size(246, 20);
            this.txtBuscarApellido.TabIndex = 37;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.White;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(876, 41);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(46, 39);
            this.btnBuscar.TabIndex = 39;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(488, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "Ingrese documento:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "Ingrese Apellido:";
            // 
            // txtBuscarDni
            // 
            this.txtBuscarDni.Location = new System.Drawing.Point(624, 51);
            this.txtBuscarDni.Name = "txtBuscarDni";
            this.txtBuscarDni.Size = new System.Drawing.Size(246, 20);
            this.txtBuscarDni.TabIndex = 42;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(397, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(46, 39);
            this.button1.TabIndex = 43;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CiudadanoNuevo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 559);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtBuscarDni);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtBuscarApellido);
            this.Controls.Add(this.btnAdministrarCiudadano);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.dataListadoCiudadanos);
            this.Name = "CiudadanoNuevo";
            this.Text = "Nuevo Ciudadano";
            this.Load += new System.EventHandler(this.CiudadanoNuevo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataListadoCiudadanos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnAdministrarCiudadano;
        private System.Windows.Forms.TextBox txtBuscarApellido;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBuscarDni;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.DataGridView dataListadoCiudadanos;
    }
}