namespace CapaPresentacion
{
    partial class frmSalidaCiudadano
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalidaCiudadano));
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdCiudadano = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBuscarApellido = new System.Windows.Forms.TextBox();
            this.txtBuscarDocumento = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBuscarApellido = new System.Windows.Forms.Button();
            this.btnBuscarDocumento = new System.Windows.Forms.Button();
            this.dgvListaCiudadanos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaCiudadanos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(37, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(483, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Formuario para dar salida a ciudadanos:";
            // 
            // txtIdCiudadano
            // 
            this.txtIdCiudadano.Location = new System.Drawing.Point(120, 313);
            this.txtIdCiudadano.Name = "txtIdCiudadano";
            this.txtIdCiudadano.Size = new System.Drawing.Size(100, 20);
            this.txtIdCiudadano.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 316);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Id Ciudadano:";
            // 
            // txtBuscarApellido
            // 
            this.txtBuscarApellido.Location = new System.Drawing.Point(146, 92);
            this.txtBuscarApellido.Name = "txtBuscarApellido";
            this.txtBuscarApellido.Size = new System.Drawing.Size(163, 20);
            this.txtBuscarApellido.TabIndex = 3;
            // 
            // txtBuscarDocumento
            // 
            this.txtBuscarDocumento.Location = new System.Drawing.Point(524, 95);
            this.txtBuscarDocumento.Name = "txtBuscarDocumento";
            this.txtBuscarDocumento.Size = new System.Drawing.Size(185, 20);
            this.txtBuscarDocumento.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Buscar por Apellido:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(399, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Buscar por Documento:";
            // 
            // btnBuscarApellido
            // 
            this.btnBuscarApellido.BackColor = System.Drawing.Color.White;
            this.btnBuscarApellido.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarApellido.Image")));
            this.btnBuscarApellido.Location = new System.Drawing.Point(315, 88);
            this.btnBuscarApellido.Name = "btnBuscarApellido";
            this.btnBuscarApellido.Size = new System.Drawing.Size(35, 33);
            this.btnBuscarApellido.TabIndex = 7;
            this.btnBuscarApellido.UseVisualStyleBackColor = false;
            this.btnBuscarApellido.Click += new System.EventHandler(this.btnBuscarApellido_Click);
            // 
            // btnBuscarDocumento
            // 
            this.btnBuscarDocumento.BackColor = System.Drawing.Color.White;
            this.btnBuscarDocumento.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarDocumento.Image")));
            this.btnBuscarDocumento.Location = new System.Drawing.Point(728, 89);
            this.btnBuscarDocumento.Name = "btnBuscarDocumento";
            this.btnBuscarDocumento.Size = new System.Drawing.Size(35, 33);
            this.btnBuscarDocumento.TabIndex = 8;
            this.btnBuscarDocumento.UseVisualStyleBackColor = false;
            // 
            // dgvListaCiudadanos
            // 
            this.dgvListaCiudadanos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaCiudadanos.Location = new System.Drawing.Point(44, 130);
            this.dgvListaCiudadanos.Name = "dgvListaCiudadanos";
            this.dgvListaCiudadanos.Size = new System.Drawing.Size(719, 162);
            this.dgvListaCiudadanos.TabIndex = 9;
            this.dgvListaCiudadanos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvListaCiudadanos_KeyDown);
            // 
            // frmSalidaCiudadano
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvListaCiudadanos);
            this.Controls.Add(this.btnBuscarDocumento);
            this.Controls.Add(this.btnBuscarApellido);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBuscarDocumento);
            this.Controls.Add(this.txtBuscarApellido);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIdCiudadano);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSalidaCiudadano";
            this.Text = "Formulario de Salidas de Ciudadano";
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaCiudadanos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdCiudadano;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBuscarApellido;
        private System.Windows.Forms.TextBox txtBuscarDocumento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBuscarApellido;
        private System.Windows.Forms.Button btnBuscarDocumento;
        private System.Windows.Forms.DataGridView dgvListaCiudadanos;
    }
}