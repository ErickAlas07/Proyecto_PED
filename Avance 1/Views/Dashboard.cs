using System;
using System.Windows.Forms;
using Avance_1.Data;

namespace Avance_1
{
    public partial class Dashboard : Form
    {
        // Obtener el rol del estudiante desde la sesión
        int idRol = UserSession.RolId;

        public Dashboard()
        {
            InitializeComponent();
            this.FormClosed += Form2_FormClosed;
            ConfigurarPermisos();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Se cierra la aplicación al cerrar el formulario
            Application.Exit();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (idRol == 3)
            {
                viewAsignaturas1.Visible = false;
                viewProfesores1.Visible = false;
                viewEstudiantes1.Visible = false;
                viewHomeProfesor1.Visible = false;
                viewAdmin1.Visible = false;
                viewHome1.Visible = true;
            }
            else if (idRol == 2)
            {
                viewAsignaturas1.Visible = false;
                viewProfesores1.Visible = false;
                viewEstudiantes1.Visible = false;
                viewHomeProfesor1.Visible = true;
                viewHome1.Visible = false;
                viewAdmin1.Visible = false;
            } 
            else
            {
                viewAsignaturas1.Visible = false;
                viewProfesores1.Visible = false;
                viewEstudiantes1.Visible = false;
                viewHomeProfesor1.Visible = false;
                viewHome1.Visible = true;
                viewAdmin1.Visible = false;
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            if(idRol == 3)
            {
                viewAsignaturas1.Visible = false;
                viewProfesores1.Visible = false;
                viewEstudiantes1.Visible = false;
                viewHomeProfesor1.Visible = false;
                viewAdmin1.Visible = false;
                viewHome1.Visible = true;
            }
            else if (idRol == 2)
            {
                viewAsignaturas1.Visible = false;
                viewProfesores1.Visible = false;
                viewEstudiantes1.Visible = false;
                viewHomeProfesor1.Visible = true;
                viewHome1.Visible = false;
                viewAdmin1.Visible = false;
            }
            else
            {
                viewAsignaturas1.Visible = false;
                viewProfesores1.Visible = false;
                viewEstudiantes1.Visible = false;
                viewHomeProfesor1.Visible = false;
                viewAdmin1.Visible = false;
                viewHome1.Visible = true;
            }
        }

        private void btnMaterias_Click(object sender, EventArgs e)
        {
            viewAsignaturas1.Visible = true;
            viewProfesores1.Visible = false;
            viewEstudiantes1.Visible = false;
            viewHome1.Visible = false;
            viewAdmin1.Visible = false;
        }

        private void btnProfesor_Click(object sender, EventArgs e)
        {
            viewAsignaturas1.Visible = false;
            viewProfesores1.Visible = true;
            viewEstudiantes1.Visible = false;
            viewHome1.Visible = false;
            viewAdmin1.Visible = false;
        }

        private void btnEstudiantes_Click(object sender, EventArgs e)
        {
            viewAsignaturas1.Visible = false;
            viewProfesores1.Visible = false;
            viewEstudiantes1.Visible = true;
            viewHome1.Visible = false;
            viewAdmin1.Visible = false;
        }

        private void ConfigurarPermisos()
        {
            // Obtener el rol del usuario actual desde la sesión
            int rolId = UserSession.RolId;

            switch (rolId)
            {
                case 1: // Administrador
                    MostrarBotones(true, true, true, true, true);
                    break;
                case 2: // Profesor
                    MostrarBotones(true, false, false, false, false);
                    break;
                case 3: // Estudiante
                    MostrarBotones(true, false, false, false, false);
                    break;
                default:
                    MostrarBotones(false, false, false, false, false);
                    break;
            }
        }


        private void MostrarBotones(bool admin, bool materias, bool profesores, bool estudiantes, bool administradores)
        {
            btnAdmin.Visible = admin;
            btnMaterias.Visible = materias;
            btnProfesor.Visible = profesores;
            btnEstudiantes.Visible = estudiantes;
            btnAdministradores.Visible = administradores;
        }

        private void btnAdministradores_Click(object sender, EventArgs e)
        {
            viewAsignaturas1.Visible = false;
            viewProfesores1.Visible = false;
            viewEstudiantes1.Visible = false;
            viewHome1.Visible = false;
            viewAdmin1.Visible = true;
        }

        private void viewAdmin1_Load(object sender, EventArgs e)
        {

        }
    }
}
