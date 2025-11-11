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
            this.txtIdRegistroDiario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBuscarApellido = new System.Windows.Forms.Button();
            this.dgvListaRegistroDiario = new System.Windows.Forms.DataGridView();
            this.dtpHoraSalida = new System.Windows.Forms.DateTimePicker();
            this.btnRegistrarSalida = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.dtpHoraInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpHoraFin = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaRegistroDiario)).BeginInit();
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
            // txtIdRegistroDiario
            // 
            this.txtIdRegistroDiario.Location = new System.Drawing.Point(44, 308);
            this.txtIdRegistroDiario.Name = "txtIdRegistroDiario";
            this.txtIdRegistroDiario.Size = new System.Drawing.Size(50, 20);
            this.txtIdRegistroDiario.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Buscar por Fecha:";
            // 
            // btnBuscarApellido
            // 
            this.btnBuscarApellido.BackColor = System.Drawing.Color.White;
            this.btnBuscarApellido.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarApellido.Image")));
            this.btnBuscarApellido.Location = new System.Drawing.Point(309, 94);
            this.btnBuscarApellido.Name = "btnBuscarApellido";
            this.btnBuscarApellido.Size = new System.Drawing.Size(35, 33);
            this.btnBuscarApellido.TabIndex = 7;
            this.btnBuscarApellido.UseVisualStyleBackColor = false;
            this.btnBuscarApellido.Click += new System.EventHandler(this.btnBuscarApellido_Click);
            // 
            // dgvListaRegistroDiario
            // 
            this.dgvListaRegistroDiario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaRegistroDiario.Location = new System.Drawing.Point(44, 156);
            this.dgvListaRegistroDiario.Name = "dgvListaRegistroDiario";
            this.dgvListaRegistroDiario.Size = new System.Drawing.Size(719, 136);
            this.dgvListaRegistroDiario.TabIndex = 9;
            this.dgvListaRegistroDiario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvListaCiudadanos_KeyDown);
            // 
            // dtpHoraSalida
            // 
            this.dtpHoraSalida.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHoraSalida.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraSalida.Location = new System.Drawing.Point(684, 39);
            this.dtpHoraSalida.Name = "dtpHoraSalida";
            this.dtpHoraSalida.Size = new System.Drawing.Size(79, 20);
            this.dtpHoraSalida.TabIndex = 10;
            // 
            // btnRegistrarSalida
            // 
            this.btnRegistrarSalida.BackColor = System.Drawing.Color.White;
            this.btnRegistrarSalida.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRegistrarSalida.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarSalida.Image = ((System.Drawing.Image)(resources.GetObject("btnRegistrarSalida.Image")));
            this.btnRegistrarSalida.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegistrarSalida.Location = new System.Drawing.Point(253, 337);
            this.btnRegistrarSalida.Name = "btnRegistrarSalida";
            this.btnRegistrarSalida.Size = new System.Drawing.Size(265, 47);
            this.btnRegistrarSalida.TabIndex = 11;
            this.btnRegistrarSalida.Text = "Registrar Horario Salida ";
            this.btnRegistrarSalida.UseVisualStyleBackColor = false;
            this.btnRegistrarSalida.Click += new System.EventHandler(this.btnRegistrarSalida_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Hora Inicio:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Hora Fin:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(141, 72);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(106, 20);
            this.dtpFecha.TabIndex = 15;
            // 
            // dtpHoraInicio
            // 
            this.dtpHoraInicio.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraInicio.Location = new System.Drawing.Point(141, 102);
            this.dtpHoraInicio.Name = "dtpHoraInicio";
            this.dtpHoraInicio.Size = new System.Drawing.Size(106, 20);
            this.dtpHoraInicio.TabIndex = 16;
            // 
            // dtpHoraFin
            // 
            this.dtpHoraFin.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraFin.Location = new System.Drawing.Point(141, 130);
            this.dtpHoraFin.Name = "dtpHoraFin";
            this.dtpHoraFin.Size = new System.Drawing.Size(106, 20);
            this.dtpHoraFin.TabIndex = 17;
            // 
            // frmSalidaCiudadano
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dtpHoraFin);
            this.Controls.Add(this.dtpHoraInicio);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnRegistrarSalida);
            this.Controls.Add(this.dtpHoraSalida);
            this.Controls.Add(this.dgvListaRegistroDiario);
            this.Controls.Add(this.btnBuscarApellido);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtIdRegistroDiario);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSalidaCiudadano";
            this.Text = "Formulario de Salidas de Ciudadano";
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaRegistroDiario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdRegistroDiario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBuscarApellido;
        private System.Windows.Forms.DataGridView dgvListaRegistroDiario;
        private System.Windows.Forms.DateTimePicker dtpHoraSalida;
        private System.Windows.Forms.Button btnRegistrarSalida;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.DateTimePicker dtpHoraInicio;
        private System.Windows.Forms.DateTimePicker dtpHoraFin;
    }
}