
namespace Avance_1.Views
{
    partial class DetallesProfesor
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
            this.lblMateriasAsiganadas = new System.Windows.Forms.Label();
            this.lblDetallesProfesor = new System.Windows.Forms.Label();
            this.btnSalir = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // lblMateriasAsiganadas
            // 
            this.lblMateriasAsiganadas.AutoSize = true;
            this.lblMateriasAsiganadas.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblMateriasAsiganadas.Location = new System.Drawing.Point(80, 303);
            this.lblMateriasAsiganadas.Name = "lblMateriasAsiganadas";
            this.lblMateriasAsiganadas.Size = new System.Drawing.Size(156, 17);
            this.lblMateriasAsiganadas.TabIndex = 3;
            this.lblMateriasAsiganadas.Text = "Asignaturas asignadas:";
            // 
            // lblDetallesProfesor
            // 
            this.lblDetallesProfesor.AutoSize = true;
            this.lblDetallesProfesor.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblDetallesProfesor.Location = new System.Drawing.Point(80, 68);
            this.lblDetallesProfesor.Name = "lblDetallesProfesor";
            this.lblDetallesProfesor.Size = new System.Drawing.Size(145, 17);
            this.lblDetallesProfesor.TabIndex = 2;
            this.lblDetallesProfesor.Text = "Detalles de Profesor: ";
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Red;
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnSalir.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSalir.IconChar = FontAwesome.Sharp.IconChar.X;
            this.btnSalir.IconColor = System.Drawing.SystemColors.Control;
            this.btnSalir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSalir.IconSize = 20;
            this.btnSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSalir.Location = new System.Drawing.Point(749, 12);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(39, 31);
            this.btnSalir.TabIndex = 8;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // DetallesProfesor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.lblMateriasAsiganadas);
            this.Controls.Add(this.lblDetallesProfesor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DetallesProfesor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Detalles";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMateriasAsiganadas;
        private System.Windows.Forms.Label lblDetallesProfesor;
        private FontAwesome.Sharp.IconButton btnSalir;
    }
}