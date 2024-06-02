using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Avance_1.Data;

namespace Avance_1.Views
{
    public partial class VerHorarios : Form
    {
        private HorarioDataAccess hdataAccess;

        public VerHorarios()
        {
            InitializeComponent();
            hdataAccess = new HorarioDataAccess();
        }

        // Método para cargar horarios por ID de materias
        public void CargarHorarios(List<int> idMaterias)
        {
            try
            {
                DataTable horarios = hdataAccess.ObtenerHorariosPorMateria(idMaterias);
                dataGridViewHorarios.DataSource = horarios;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los horarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void VerHorarios_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
