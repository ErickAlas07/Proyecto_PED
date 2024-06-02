
namespace Avance_1.Views
{
    partial class ViewHomeProfesor
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlProfesor = new System.Windows.Forms.Panel();
            this.btnHorarios = new FontAwesome.Sharp.IconButton();
            this.btnVerAsignaturas = new FontAwesome.Sharp.IconButton();
            this.lblAsignacion = new System.Windows.Forms.Label();
            this.pnlProfesor.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlProfesor
            // 
            this.pnlProfesor.Controls.Add(this.btnHorarios);
            this.pnlProfesor.Controls.Add(this.btnVerAsignaturas);
            this.pnlProfesor.Controls.Add(this.lblAsignacion);
            this.pnlProfesor.Location = new System.Drawing.Point(79, 52);
            this.pnlProfesor.Name = "pnlProfesor";
            this.pnlProfesor.Size = new System.Drawing.Size(705, 165);
            this.pnlProfesor.TabIndex = 9;
            // 
            // btnHorarios
            // 
            this.btnHorarios.BackColor = System.Drawing.Color.DarkBlue;
            this.btnHorarios.ForeColor = System.Drawing.Color.White;
            this.btnHorarios.IconChar = FontAwesome.Sharp.IconChar.Calendar;
            this.btnHorarios.IconColor = System.Drawing.Color.White;
            this.btnHorarios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnHorarios.IconSize = 40;
            this.btnHorarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHorarios.Location = new System.Drawing.Point(227, 76);
            this.btnHorarios.Name = "btnHorarios";
            this.btnHorarios.Padding = new System.Windows.Forms.Padding(20);
            this.btnHorarios.Size = new System.Drawing.Size(172, 71);
            this.btnHorarios.TabIndex = 6;
            this.btnHorarios.Text = "Horarios";
            this.btnHorarios.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHorarios.UseVisualStyleBackColor = false;
            this.btnHorarios.Click += new System.EventHandler(this.btnHorarios_Click);
            // 
            // btnVerAsignaturas
            // 
            this.btnVerAsignaturas.BackColor = System.Drawing.Color.DarkBlue;
            this.btnVerAsignaturas.ForeColor = System.Drawing.Color.White;
            this.btnVerAsignaturas.IconChar = FontAwesome.Sharp.IconChar.Book;
            this.btnVerAsignaturas.IconColor = System.Drawing.Color.White;
            this.btnVerAsignaturas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnVerAsignaturas.IconSize = 40;
            this.btnVerAsignaturas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerAsignaturas.Location = new System.Drawing.Point(17, 76);
            this.btnVerAsignaturas.Name = "btnVerAsignaturas";
            this.btnVerAsignaturas.Padding = new System.Windows.Forms.Padding(20);
            this.btnVerAsignaturas.Size = new System.Drawing.Size(184, 71);
            this.btnVerAsignaturas.TabIndex = 5;
            this.btnVerAsignaturas.Text = "Asignaturas";
            this.btnVerAsignaturas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVerAsignaturas.UseVisualStyleBackColor = false;
            this.btnVerAsignaturas.Click += new System.EventHandler(this.btnVerAsignaturas_Click);
            // 
            // lblAsignacion
            // 
            this.lblAsignacion.AutoSize = true;
            this.lblAsignacion.Font = new System.Drawing.Font("Dubai Medium", 12F);
            this.lblAsignacion.Location = new System.Drawing.Point(14, 20);
            this.lblAsignacion.Name = "lblAsignacion";
            this.lblAsignacion.Size = new System.Drawing.Size(131, 34);
            this.lblAsignacion.TabIndex = 4;
            this.lblAsignacion.Text = "Asignaciones.";
            // 
            // ViewHomeProfesor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.pnlProfesor);
            this.Name = "ViewHomeProfesor";
            this.Size = new System.Drawing.Size(871, 640);
            this.pnlProfesor.ResumeLayout(false);
            this.pnlProfesor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlProfesor;
        private FontAwesome.Sharp.IconButton btnHorarios;
        private FontAwesome.Sharp.IconButton btnVerAsignaturas;
        private System.Windows.Forms.Label lblAsignacion;
    }
}
