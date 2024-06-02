using Avance_1.Data;
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
    public partial class VerAsignaciones : Form
    {
        private ProfesorDataAccess pdataAccess;
        private MateriaDataAccess mdataAccess;

        public VerAsignaciones()
        {
            InitializeComponent();
            pdataAccess = new ProfesorDataAccess();
            mdataAccess = new MateriaDataAccess();
        }

        // Método para cargar materias asociadas a profesor
        private void CargarMaterias()
        {
            try
            {
                // Obtener el idUsuario del usuario actual
                int idUsuario = UserSession.IdUsuario;

                // Obtener el idProfesor del usuario actual
                int idProfesor = pdataAccess.ObtenerIdProfesorPorUsuario(idUsuario);

                // Obtener las materias del profesor actual
                DataTable materias = mdataAccess.ObtenerMateriasPorProfesor(idProfesor);

                // Asignar el DataTable al DataGridView
                dataGridView1.DataSource = materias;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las materias: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void VerAsignaciones_Load(object sender, EventArgs e)
        {
            CargarMaterias();
        }

        private void lblTituloMaterias_Click(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
