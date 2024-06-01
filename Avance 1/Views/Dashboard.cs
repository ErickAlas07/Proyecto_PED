using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Avance_1
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            this.FormClosed += Form2_FormClosed;
        }
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Se cierra la aplicación al cerrar el formulario//
            Application.Exit();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            viewAsignaturas1.Visible = false;
            viewProfesores1.Visible = false;
            viewEstudiantes1.Visible = false;
        }

        private void btnMaterias_Click(object sender, EventArgs e)
        {
            viewAsignaturas1.Visible = true;
            viewProfesores1.Visible = false;
            viewEstudiantes1.Visible = false;
        }

        private void btnProfesor_Click(object sender, EventArgs e)
        {
            viewAsignaturas1.Visible = false;
            viewProfesores1.Visible = true;
            viewEstudiantes1.Visible = false;
        }

        private void btnEstudiantes_Click(object sender, EventArgs e)
        {
            viewAsignaturas1.Visible = false;
            viewProfesores1.Visible = false;
            viewEstudiantes1.Visible = true;
        }
    }
}
