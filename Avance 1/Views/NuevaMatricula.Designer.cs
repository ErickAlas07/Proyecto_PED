
namespace Avance_1.Views
{
    partial class NuevaMatricula
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
            this.cmbMaterias = new System.Windows.Forms.ComboBox();
            this.lblMateria = new System.Windows.Forms.Label();
            this.grbDatos = new System.Windows.Forms.GroupBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.btnEnviar = new FontAwesome.Sharp.IconButton();
            this.grpDataMatricula = new System.Windows.Forms.GroupBox();
            this.lblAsignatura = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblCarnet = new System.Windows.Forms.Label();
            this.grbDatos.SuspendLayout();
            this.grpDataMatricula.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbMaterias
            // 
            this.cmbMaterias.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMaterias.FormattingEnabled = true;
            this.cmbMaterias.Location = new System.Drawing.Point(19, 81);
            this.cmbMaterias.Name = "cmbMaterias";
            this.cmbMaterias.Size = new System.Drawing.Size(121, 28);
            this.cmbMaterias.TabIndex = 0;
            // 
            // lblMateria
            // 
            this.lblMateria.AutoSize = true;
            this.lblMateria.Location = new System.Drawing.Point(18, 56);
            this.lblMateria.Name = "lblMateria";
            this.lblMateria.Size = new System.Drawing.Size(80, 17);
            this.lblMateria.TabIndex = 1;
            this.lblMateria.Text = "Asignatura:";
            // 
            // grbDatos
            // 
            this.grbDatos.Controls.Add(this.lblEstado);
            this.grbDatos.Controls.Add(this.cmbEstado);
            this.grbDatos.Controls.Add(this.lblMateria);
            this.grbDatos.Controls.Add(this.cmbMaterias);
            this.grbDatos.Location = new System.Drawing.Point(52, 48);
            this.grbDatos.Name = "grbDatos";
            this.grbDatos.Size = new System.Drawing.Size(327, 282);
            this.grbDatos.TabIndex = 2;
            this.grbDatos.TabStop = false;
            this.grbDatos.Text = "Datos inscripción";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(20, 145);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(56, 17);
            this.lblEstado.TabIndex = 3;
            this.lblEstado.Text = "Estado:";
            // 
            // cmbEstado
            // 
            this.cmbEstado.Enabled = false;
            this.cmbEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(21, 170);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(121, 28);
            this.cmbEstado.TabIndex = 2;
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackColor = System.Drawing.Color.DarkGreen;
            this.btnEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEnviar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnEnviar.IconColor = System.Drawing.Color.Black;
            this.btnEnviar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEnviar.Location = new System.Drawing.Point(278, 351);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(101, 52);
            this.btnEnviar.TabIndex = 3;
            this.btnEnviar.Text = "Inscribir";
            this.btnEnviar.UseVisualStyleBackColor = false;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // grpDataMatricula
            // 
            this.grpDataMatricula.Controls.Add(this.lblAsignatura);
            this.grpDataMatricula.Controls.Add(this.lblStatus);
            this.grpDataMatricula.Controls.Add(this.lblCarnet);
            this.grpDataMatricula.Location = new System.Drawing.Point(407, 48);
            this.grpDataMatricula.Name = "grpDataMatricula";
            this.grpDataMatricula.Size = new System.Drawing.Size(327, 282);
            this.grpDataMatricula.TabIndex = 4;
            this.grpDataMatricula.TabStop = false;
            this.grpDataMatricula.Text = "Información de Matrícula";
            // 
            // lblAsignatura
            // 
            this.lblAsignatura.AutoSize = true;
            this.lblAsignatura.Location = new System.Drawing.Point(18, 108);
            this.lblAsignatura.Name = "lblAsignatura";
            this.lblAsignatura.Size = new System.Drawing.Size(13, 17);
            this.lblAsignatura.TabIndex = 3;
            this.lblAsignatura.Text = "-";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(18, 161);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(13, 17);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "-";
            // 
            // lblCarnet
            // 
            this.lblCarnet.AutoSize = true;
            this.lblCarnet.Location = new System.Drawing.Point(18, 56);
            this.lblCarnet.Name = "lblCarnet";
            this.lblCarnet.Size = new System.Drawing.Size(17, 17);
            this.lblCarnet.TabIndex = 1;
            this.lblCarnet.Text = "- ";
            // 
            // NuevaMatricula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grpDataMatricula);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.grbDatos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NuevaMatricula";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NuevaMatricula";
            this.Load += new System.EventHandler(this.NuevaMatricula_Load);
            this.grbDatos.ResumeLayout(false);
            this.grbDatos.PerformLayout();
            this.grpDataMatricula.ResumeLayout(false);
            this.grpDataMatricula.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbMaterias;
        private System.Windows.Forms.Label lblMateria;
        private System.Windows.Forms.GroupBox grbDatos;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cmbEstado;
        private FontAwesome.Sharp.IconButton btnEnviar;
        private System.Windows.Forms.GroupBox grpDataMatricula;
        private System.Windows.Forms.Label lblAsignatura;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblCarnet;
    }
}