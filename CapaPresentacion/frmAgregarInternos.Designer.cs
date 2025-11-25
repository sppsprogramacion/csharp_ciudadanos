namespace CapaPresentacion
{
    partial class frmAgregarInternos
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBuscarInterno = new System.Windows.Forms.TextBox();
            this.btnBuscarInterno = new System.Windows.Forms.Button();
            this.dgvDatosInternos = new System.Windows.Forms.DataGridView();
            this.txtProntuarioInterno = new System.Windows.Forms.TextBox();
            this.txtApellidoInterno = new System.Windows.Forms.TextBox();
            this.txtNombreInterno = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnEnviarDatosInternos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosInternos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Buscar por Apellido:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 1;
            // 
            // txtBuscarInterno
            // 
            this.txtBuscarInterno.Location = new System.Drawing.Point(183, 32);
            this.txtBuscarInterno.Name = "txtBuscarInterno";
            this.txtBuscarInterno.Size = new System.Drawing.Size(218, 20);
            this.txtBuscarInterno.TabIndex = 2;
            // 
            // btnBuscarInterno
            // 
            this.btnBuscarInterno.Location = new System.Drawing.Point(426, 24);
            this.btnBuscarInterno.Name = "btnBuscarInterno";
            this.btnBuscarInterno.Size = new System.Drawing.Size(50, 38);
            this.btnBuscarInterno.TabIndex = 3;
            this.btnBuscarInterno.Text = "Buscar";
            this.btnBuscarInterno.UseVisualStyleBackColor = true;
            this.btnBuscarInterno.Click += new System.EventHandler(this.btnBuscarInterno_Click);
            // 
            // dgvDatosInternos
            // 
            this.dgvDatosInternos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatosInternos.Location = new System.Drawing.Point(35, 68);
            this.dgvDatosInternos.Name = "dgvDatosInternos";
            this.dgvDatosInternos.Size = new System.Drawing.Size(520, 117);
            this.dgvDatosInternos.TabIndex = 4;
            this.dgvDatosInternos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDatosInternos_KeyDown);
            // 
            // txtProntuarioInterno
            // 
            this.txtProntuarioInterno.Location = new System.Drawing.Point(183, 203);
            this.txtProntuarioInterno.Name = "txtProntuarioInterno";
            this.txtProntuarioInterno.Size = new System.Drawing.Size(218, 20);
            this.txtProntuarioInterno.TabIndex = 5;
            // 
            // txtApellidoInterno
            // 
            this.txtApellidoInterno.Location = new System.Drawing.Point(183, 229);
            this.txtApellidoInterno.Name = "txtApellidoInterno";
            this.txtApellidoInterno.Size = new System.Drawing.Size(218, 20);
            this.txtApellidoInterno.TabIndex = 6;
            // 
            // txtNombreInterno
            // 
            this.txtNombreInterno.Location = new System.Drawing.Point(183, 255);
            this.txtNombreInterno.Name = "txtNombreInterno";
            this.txtNombreInterno.Size = new System.Drawing.Size(218, 20);
            this.txtNombreInterno.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(41, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Prontuario:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(41, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Apellido:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(41, 258);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Nombre:";
            // 
            // btnEnviarDatosInternos
            // 
            this.btnEnviarDatosInternos.Location = new System.Drawing.Point(193, 309);
            this.btnEnviarDatosInternos.Name = "btnEnviarDatosInternos";
            this.btnEnviarDatosInternos.Size = new System.Drawing.Size(170, 29);
            this.btnEnviarDatosInternos.TabIndex = 11;
            this.btnEnviarDatosInternos.Text = "Aceptar";
            this.btnEnviarDatosInternos.UseVisualStyleBackColor = true;
            this.btnEnviarDatosInternos.Click += new System.EventHandler(this.btnEnviarDatosInternos_Click);
            // 
            // frmAgregarInternos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 376);
            this.Controls.Add(this.btnEnviarDatosInternos);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNombreInterno);
            this.Controls.Add(this.txtApellidoInterno);
            this.Controls.Add(this.txtProntuarioInterno);
            this.Controls.Add(this.dgvDatosInternos);
            this.Controls.Add(this.btnBuscarInterno);
            this.Controls.Add(this.txtBuscarInterno);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmAgregarInternos";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formulario Buscar Internos";
            this.Load += new System.EventHandler(this.frmAgregarInternos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosInternos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBuscarInterno;
        private System.Windows.Forms.Button btnBuscarInterno;
        private System.Windows.Forms.DataGridView dgvDatosInternos;
        private System.Windows.Forms.TextBox txtProntuarioInterno;
        private System.Windows.Forms.TextBox txtApellidoInterno;
        private System.Windows.Forms.TextBox txtNombreInterno;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnEnviarDatosInternos;
    }
}