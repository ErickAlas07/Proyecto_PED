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
    public partial class Form2 : Form
    {
        public Form2()
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

        private void btn_materias_Click(object sender, EventArgs e)
        {
            Form3 MateriasForm3 = new Form3();
            MateriasForm3.FormClosed += (s, arg) => this.Close();
            MateriasForm3.Show();
            this.Hide();
        }

        private void btn_docente_Click(object sender, EventArgs e)
        {

        }

        private void btn_Alumno_Click(object sender, EventArgs e)
        {

        }
    }
}
