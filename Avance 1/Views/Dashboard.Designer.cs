
namespace Avance_1
{
    partial class Dashboard
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAdministradores = new FontAwesome.Sharp.IconButton();
            this.btnAtras = new FontAwesome.Sharp.IconButton();
            this.btnEstudiantes = new FontAwesome.Sharp.IconButton();
            this.btnProfesor = new FontAwesome.Sharp.IconButton();
            this.btnMaterias = new FontAwesome.Sharp.IconButton();
            this.btnAdmin = new FontAwesome.Sharp.IconButton();
            this.viewHomeProfesor1 = new Avance_1.Views.ViewHomeProfesor();
            this.viewHome1 = new Avance_1.Views.ViewHome();
            this.viewEstudiantes1 = new Avance_1.Views.ViewEstudiantes();
            this.viewProfesores1 = new Avance_1.Views.ViewProfesores();
            this.viewAsignaturas1 = new Avance_1.Views.ViewAsignaturas();
            this.viewEstudiantes = new Avance_1.Views.ViewEstudiantes();
            this.viewAdmin1 = new Avance_1.Views.ViewAdmin();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkBlue;
            this.panel1.Controls.Add(this.btnAdministradores);
            this.panel1.Controls.Add(this.btnAtras);
            this.panel1.Controls.Add(this.btnEstudiantes);
            this.panel1.Controls.Add(this.btnProfesor);
            this.panel1.Controls.Add(this.btnMaterias);
            this.panel1.Controls.Add(this.btnAdmin);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(238, 641);
            this.panel1.TabIndex = 4;
            // 
            // btnAdministradores
            // 
            this.btnAdministradores.BackColor = System.Drawing.Color.DarkBlue;
            this.btnAdministradores.FlatAppearance.BorderSize = 3;
            this.btnAdministradores.ForeColor = System.Drawing.Color.White;
            this.btnAdministradores.IconChar = FontAwesome.Sharp.IconChar.UserGear;
            this.btnAdministradores.IconColor = System.Drawing.Color.White;
            this.btnAdministradores.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAdministradores.IconSize = 45;
            this.btnAdministradores.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdministradores.Location = new System.Drawing.Point(21, 444);
            this.btnAdministradores.Name = "btnAdministradores";
            this.btnAdministradores.Padding = new System.Windows.Forms.Padding(5);
            this.btnAdministradores.Size = new System.Drawing.Size(174, 61);
            this.btnAdministradores.TabIndex = 10;
            this.btnAdministradores.Text = "Administradores";
            this.btnAdministradores.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdministradores.UseVisualStyleBackColor = false;
            this.btnAdministradores.Click += new System.EventHandler(this.btnAdministradores_Click);
            // 
            // btnAtras
            // 
            this.btnAtras.BackColor = System.Drawing.Color.DarkBlue;
            this.btnAtras.FlatAppearance.BorderSize = 3;
            this.btnAtras.ForeColor = System.Drawing.Color.White;
            this.btnAtras.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleLeft;
            this.btnAtras.IconColor = System.Drawing.Color.White;
            this.btnAtras.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAtras.IconSize = 30;
            this.btnAtras.Location = new System.Drawing.Point(12, 586);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Padding = new System.Windows.Forms.Padding(5);
            this.btnAtras.Size = new System.Drawing.Size(64, 41);
            this.btnAtras.TabIndex = 9;
            this.btnAtras.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnAtras.UseVisualStyleBackColor = false;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // btnEstudiantes
            // 
            this.btnEstudiantes.BackColor = System.Drawing.Color.DarkBlue;
            this.btnEstudiantes.FlatAppearance.BorderSize = 3;
            this.btnEstudiantes.ForeColor = System.Drawing.Color.White;
            this.btnEstudiantes.IconChar = FontAwesome.Sharp.IconChar.UserGraduate;
            this.btnEstudiantes.IconColor = System.Drawing.Color.White;
            this.btnEstudiantes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEstudiantes.IconSize = 45;
            this.btnEstudiantes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEstudiantes.Location = new System.Drawing.Point(21, 355);
            this.btnEstudiantes.Name = "btnEstudiantes";
            this.btnEstudiantes.Padding = new System.Windows.Forms.Padding(5);
            this.btnEstudiantes.Size = new System.Drawing.Size(174, 61);
            this.btnEstudiantes.TabIndex = 8;
            this.btnEstudiantes.Text = "Estudiantes";
            this.btnEstudiantes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEstudiantes.UseVisualStyleBackColor = false;
            this.btnEstudiantes.Click += new System.EventHandler(this.btnEstudiantes_Click);
            // 
            // btnProfesor
            // 
            this.btnProfesor.BackColor = System.Drawing.Color.DarkBlue;
            this.btnProfesor.FlatAppearance.BorderSize = 3;
            this.btnProfesor.ForeColor = System.Drawing.Color.White;
            this.btnProfesor.IconChar = FontAwesome.Sharp.IconChar.Users;
            this.btnProfesor.IconColor = System.Drawing.Color.White;
            this.btnProfesor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnProfesor.IconSize = 45;
            this.btnProfesor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProfesor.Location = new System.Drawing.Point(21, 274);
            this.btnProfesor.Name = "btnProfesor";
            this.btnProfesor.Padding = new System.Windows.Forms.Padding(5);
            this.btnProfesor.Size = new System.Drawing.Size(174, 61);
            this.btnProfesor.TabIndex = 7;
            this.btnProfesor.Text = "Profesores";
            this.btnProfesor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProfesor.UseVisualStyleBackColor = false;
            this.btnProfesor.Click += new System.EventHandler(this.btnProfesor_Click);
            // 
            // btnMaterias
            // 
            this.btnMaterias.BackColor = System.Drawing.Color.DarkBlue;
            this.btnMaterias.FlatAppearance.BorderSize = 3;
            this.btnMaterias.ForeColor = System.Drawing.Color.White;
            this.btnMaterias.IconChar = FontAwesome.Sharp.IconChar.Book;
            this.btnMaterias.IconColor = System.Drawing.Color.White;
            this.btnMaterias.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMaterias.IconSize = 45;
            this.btnMaterias.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMaterias.Location = new System.Drawing.Point(21, 192);
            this.btnMaterias.Name = "btnMaterias";
            this.btnMaterias.Padding = new System.Windows.Forms.Padding(5);
            this.btnMaterias.Size = new System.Drawing.Size(174, 61);
            this.btnMaterias.TabIndex = 6;
            this.btnMaterias.Text = "Asignaturas";
            this.btnMaterias.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMaterias.UseVisualStyleBackColor = false;
            this.btnMaterias.Click += new System.EventHandler(this.btnMaterias_Click);
            // 
            // btnAdmin
            // 
            this.btnAdmin.BackColor = System.Drawing.Color.DarkBlue;
            this.btnAdmin.FlatAppearance.BorderSize = 3;
            this.btnAdmin.ForeColor = System.Drawing.Color.White;
            this.btnAdmin.IconChar = FontAwesome.Sharp.IconChar.School;
            this.btnAdmin.IconColor = System.Drawing.Color.White;
            this.btnAdmin.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAdmin.IconSize = 45;
            this.btnAdmin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdmin.Location = new System.Drawing.Point(21, 110);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Padding = new System.Windows.Forms.Padding(20);
            this.btnAdmin.Size = new System.Drawing.Size(174, 64);
            this.btnAdmin.TabIndex = 5;
            this.btnAdmin.Text = "Home";
            this.btnAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdmin.UseVisualStyleBackColor = false;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // viewHomeProfesor1
            // 
            this.viewHomeProfesor1.Location = new System.Drawing.Point(238, 0);
            this.viewHomeProfesor1.Name = "viewHomeProfesor1";
            this.viewHomeProfesor1.Size = new System.Drawing.Size(871, 640);
            this.viewHomeProfesor1.TabIndex = 10;
            // 
            // viewHome1
            // 
            this.viewHome1.Location = new System.Drawing.Point(238, -1);
            this.viewHome1.Name = "viewHome1";
            this.viewHome1.Size = new System.Drawing.Size(871, 640);
            this.viewHome1.TabIndex = 9;
            // 
            // viewEstudiantes1
            // 
            this.viewEstudiantes1.BackColor = System.Drawing.Color.White;
            this.viewEstudiantes1.Location = new System.Drawing.Point(238, 3);
            this.viewEstudiantes1.Name = "viewEstudiantes1";
            this.viewEstudiantes1.Size = new System.Drawing.Size(871, 640);
            this.viewEstudiantes1.TabIndex = 8;
            // 
            // viewProfesores1
            // 
            this.viewProfesores1.Location = new System.Drawing.Point(238, 3);
            this.viewProfesores1.Name = "viewProfesores1";
            this.viewProfesores1.Size = new System.Drawing.Size(871, 640);
            this.viewProfesores1.TabIndex = 7;
            // 
            // viewAsignaturas1
            // 
            this.viewAsignaturas1.BackColor = System.Drawing.Color.White;
            this.viewAsignaturas1.Location = new System.Drawing.Point(238, -1);
            this.viewAsignaturas1.Name = "viewAsignaturas1";
            this.viewAsignaturas1.Size = new System.Drawing.Size(871, 640);
            this.viewAsignaturas1.TabIndex = 6;
            // 
            // viewEstudiantes
            // 
            this.viewEstudiantes.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.viewEstudiantes.Location = new System.Drawing.Point(238, 0);
            this.viewEstudiantes.Name = "viewEstudiantes";
            this.viewEstudiantes.Size = new System.Drawing.Size(729, 640);
            this.viewEstudiantes.TabIndex = 5;
            // 
            // viewAdmin1
            // 
            this.viewAdmin1.Location = new System.Drawing.Point(238, 0);
            this.viewAdmin1.Name = "viewAdmin1";
            this.viewAdmin1.Size = new System.Drawing.Size(871, 640);
            this.viewAdmin1.TabIndex = 11;
            this.viewAdmin1.Load += new System.EventHandler(this.viewAdmin1_Load);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1109, 638);
            this.Controls.Add(this.viewAdmin1);
            this.Controls.Add(this.viewHomeProfesor1);
            this.Controls.Add(this.viewHome1);
            this.Controls.Add(this.viewEstudiantes1);
            this.Controls.Add(this.viewProfesores1);
            this.Controls.Add(this.viewAsignaturas1);
            this.Controls.Add(this.viewEstudiantes);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Regitro de Estudiantes";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btnAdmin;
        private FontAwesome.Sharp.IconButton btnAtras;
        private FontAwesome.Sharp.IconButton btnEstudiantes;
        private FontAwesome.Sharp.IconButton btnProfesor;
        private FontAwesome.Sharp.IconButton btnMaterias;
        private Views.ViewEstudiantes viewEstudiantes;
        private Views.ViewAsignaturas viewAsignaturas1;
        private Views.ViewProfesores viewProfesores1;
        private Views.ViewEstudiantes viewEstudiantes1;
        private Views.ViewHome viewHome1;
        private Views.ViewHomeProfesor viewHomeProfesor1;
        private FontAwesome.Sharp.IconButton btnAdministradores;
        private Views.ViewAdmin viewAdmin1;
    }
}