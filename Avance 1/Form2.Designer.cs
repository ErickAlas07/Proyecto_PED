
namespace Avance_1
{
    partial class Form2
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
            this.btn_materias = new System.Windows.Forms.Button();
            this.btn_docente = new System.Windows.Forms.Button();
            this.btn_Alumno = new System.Windows.Forms.Button();
            this.btn_Usuarios = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_materias
            // 
            this.btn_materias.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_materias.Location = new System.Drawing.Point(149, 92);
            this.btn_materias.Name = "btn_materias";
            this.btn_materias.Size = new System.Drawing.Size(273, 87);
            this.btn_materias.TabIndex = 0;
            this.btn_materias.Text = "Gestión Materias";
            this.btn_materias.UseVisualStyleBackColor = true;
            this.btn_materias.Click += new System.EventHandler(this.btn_materias_Click);
            // 
            // btn_docente
            // 
            this.btn_docente.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_docente.Location = new System.Drawing.Point(149, 211);
            this.btn_docente.Name = "btn_docente";
            this.btn_docente.Size = new System.Drawing.Size(273, 87);
            this.btn_docente.TabIndex = 1;
            this.btn_docente.Text = "Gestión Docente";
            this.btn_docente.UseVisualStyleBackColor = true;
            this.btn_docente.Click += new System.EventHandler(this.btn_docente_Click);
            // 
            // btn_Alumno
            // 
            this.btn_Alumno.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Alumno.Location = new System.Drawing.Point(149, 332);
            this.btn_Alumno.Name = "btn_Alumno";
            this.btn_Alumno.Size = new System.Drawing.Size(273, 87);
            this.btn_Alumno.TabIndex = 2;
            this.btn_Alumno.Text = "Gestión Estudiante";
            this.btn_Alumno.UseVisualStyleBackColor = true;
            this.btn_Alumno.Click += new System.EventHandler(this.btn_Alumno_Click);
            // 
            // btn_Usuarios
            // 
            this.btn_Usuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Usuarios.Location = new System.Drawing.Point(149, 444);
            this.btn_Usuarios.Name = "btn_Usuarios";
            this.btn_Usuarios.Size = new System.Drawing.Size(273, 87);
            this.btn_Usuarios.TabIndex = 3;
            this.btn_Usuarios.Text = "Gestión Usuarios";
            this.btn_Usuarios.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 569);
            this.Controls.Add(this.btn_Usuarios);
            this.Controls.Add(this.btn_Alumno);
            this.Controls.Add(this.btn_docente);
            this.Controls.Add(this.btn_materias);
            this.Name = "Form2";
            this.Text = "Sistema de Regitro de Estudiantes";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_materias;
        private System.Windows.Forms.Button btn_docente;
        private System.Windows.Forms.Button btn_Alumno;
        private System.Windows.Forms.Button btn_Usuarios;
    }
}