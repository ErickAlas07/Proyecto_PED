
namespace Avance_1.Views
{
    partial class ViewHome
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
            this.pnlMatricula = new System.Windows.Forms.Panel();
            this.btnVerMatricula = new FontAwesome.Sharp.IconButton();
            this.btnMatricula = new FontAwesome.Sharp.IconButton();
            this.lblMatricula = new System.Windows.Forms.Label();
            this.pnlNotas = new System.Windows.Forms.Panel();
            this.btnVerNotas = new FontAwesome.Sharp.IconButton();
            this.lblNotasRecord = new System.Windows.Forms.Label();
            this.pnlMatricula.SuspendLayout();
            this.pnlNotas.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMatricula
            // 
            this.pnlMatricula.Controls.Add(this.btnVerMatricula);
            this.pnlMatricula.Controls.Add(this.btnMatricula);
            this.pnlMatricula.Controls.Add(this.lblMatricula);
            this.pnlMatricula.Location = new System.Drawing.Point(75, 36);
            this.pnlMatricula.Name = "pnlMatricula";
            this.pnlMatricula.Size = new System.Drawing.Size(705, 165);
            this.pnlMatricula.TabIndex = 4;
            // 
            // btnVerMatricula
            // 
            this.btnVerMatricula.BackColor = System.Drawing.Color.DarkBlue;
            this.btnVerMatricula.ForeColor = System.Drawing.Color.White;
            this.btnVerMatricula.IconChar = FontAwesome.Sharp.IconChar.Pager;
            this.btnVerMatricula.IconColor = System.Drawing.Color.White;
            this.btnVerMatricula.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnVerMatricula.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerMatricula.Location = new System.Drawing.Point(277, 76);
            this.btnVerMatricula.Name = "btnVerMatricula";
            this.btnVerMatricula.Padding = new System.Windows.Forms.Padding(15);
            this.btnVerMatricula.Size = new System.Drawing.Size(206, 71);
            this.btnVerMatricula.TabIndex = 6;
            this.btnVerMatricula.Text = "Ver Inscripciones";
            this.btnVerMatricula.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVerMatricula.UseVisualStyleBackColor = false;
            this.btnVerMatricula.Click += new System.EventHandler(this.btnVerMatricula_Click);
            // 
            // btnMatricula
            // 
            this.btnMatricula.BackColor = System.Drawing.Color.DarkBlue;
            this.btnMatricula.ForeColor = System.Drawing.Color.White;
            this.btnMatricula.IconChar = FontAwesome.Sharp.IconChar.Certificate;
            this.btnMatricula.IconColor = System.Drawing.Color.White;
            this.btnMatricula.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMatricula.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMatricula.Location = new System.Drawing.Point(17, 76);
            this.btnMatricula.Name = "btnMatricula";
            this.btnMatricula.Padding = new System.Windows.Forms.Padding(15);
            this.btnMatricula.Size = new System.Drawing.Size(238, 71);
            this.btnMatricula.TabIndex = 5;
            this.btnMatricula.Text = "Inscripción de Materias";
            this.btnMatricula.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMatricula.UseVisualStyleBackColor = false;
            this.btnMatricula.Click += new System.EventHandler(this.btnMatricula_Click);
            // 
            // lblMatricula
            // 
            this.lblMatricula.AutoSize = true;
            this.lblMatricula.Font = new System.Drawing.Font("Dubai Medium", 12F);
            this.lblMatricula.Location = new System.Drawing.Point(14, 20);
            this.lblMatricula.Name = "lblMatricula";
            this.lblMatricula.Size = new System.Drawing.Size(196, 34);
            this.lblMatricula.TabIndex = 4;
            this.lblMatricula.Text = "Proceso de Matricula.";
            // 
            // pnlNotas
            // 
            this.pnlNotas.Controls.Add(this.btnVerNotas);
            this.pnlNotas.Controls.Add(this.lblNotasRecord);
            this.pnlNotas.Location = new System.Drawing.Point(75, 221);
            this.pnlNotas.Name = "pnlNotas";
            this.pnlNotas.Size = new System.Drawing.Size(705, 165);
            this.pnlNotas.TabIndex = 7;
            // 
            // btnVerNotas
            // 
            this.btnVerNotas.BackColor = System.Drawing.Color.DarkBlue;
            this.btnVerNotas.ForeColor = System.Drawing.Color.White;
            this.btnVerNotas.IconChar = FontAwesome.Sharp.IconChar.List;
            this.btnVerNotas.IconColor = System.Drawing.Color.White;
            this.btnVerNotas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnVerNotas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerNotas.Location = new System.Drawing.Point(20, 70);
            this.btnVerNotas.Name = "btnVerNotas";
            this.btnVerNotas.Padding = new System.Windows.Forms.Padding(15);
            this.btnVerNotas.Size = new System.Drawing.Size(169, 71);
            this.btnVerNotas.TabIndex = 6;
            this.btnVerNotas.Text = "Ver Notas";
            this.btnVerNotas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVerNotas.UseVisualStyleBackColor = false;
            this.btnVerNotas.Click += new System.EventHandler(this.btnVerNotas_Click);
            // 
            // lblNotasRecord
            // 
            this.lblNotasRecord.AutoSize = true;
            this.lblNotasRecord.Font = new System.Drawing.Font("Dubai Medium", 12F);
            this.lblNotasRecord.Location = new System.Drawing.Point(14, 20);
            this.lblNotasRecord.Name = "lblNotasRecord";
            this.lblNotasRecord.Size = new System.Drawing.Size(159, 34);
            this.lblNotasRecord.TabIndex = 4;
            this.lblNotasRecord.Text = "Record de Notas.";
            // 
            // ViewHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.pnlNotas);
            this.Controls.Add(this.pnlMatricula);
            this.Name = "ViewHome";
            this.Size = new System.Drawing.Size(871, 640);
            this.Load += new System.EventHandler(this.ViewHome_Load);
            this.pnlMatricula.ResumeLayout(false);
            this.pnlMatricula.PerformLayout();
            this.pnlNotas.ResumeLayout(false);
            this.pnlNotas.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlMatricula;
        private FontAwesome.Sharp.IconButton btnMatricula;
        private System.Windows.Forms.Label lblMatricula;
        private FontAwesome.Sharp.IconButton btnVerMatricula;
        private System.Windows.Forms.Panel pnlNotas;
        private FontAwesome.Sharp.IconButton btnVerNotas;
        private System.Windows.Forms.Label lblNotasRecord;
    }
}
