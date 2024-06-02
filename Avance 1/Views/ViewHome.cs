using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Avance_1.Views
{
    public partial class ViewHome : UserControl
    {
        public ViewHome()
        {
            InitializeComponent();
        }

        private void btnMatricula_Click(object sender, EventArgs e)
        {
            NuevaMatricula nm = new NuevaMatricula();
            nm.Show();
        }

        private void btnVerMatricula_Click(object sender, EventArgs e)
        {
            VerMatriculas ver = new VerMatriculas();
            ver.Show();
        }

        private void btnVerNotas_Click(object sender, EventArgs e)
        {
            ViewNotas notas = new ViewNotas();
            notas.Show();
        }

        private void ViewHome_Load(object sender, EventArgs e)
        {
            

        }
    }
}
