using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Avance_1.Data;

namespace Avance_1.Views
{
    public partial class ViewHomeProfesor : UserControl
    {
        private ProfesorDataAccess pdataAccess;
        private MateriaDataAccess mdataAccess;

        public ViewHomeProfesor()
        {
            InitializeComponent();
            pdataAccess = new ProfesorDataAccess();
            mdataAccess = new MateriaDataAccess();
        }

        private void btnVerAsignaturas_Click(object sender, EventArgs e)
        {
            VerAsignaciones ver = new VerAsignaciones();
            ver.Show();
        }

        private void btnHorarios_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el idUsuario del usuario actual
                int idUsuario = UserSession.IdUsuario;

                // Obtener el idProfesor del usuario actual
                int idProfesor = pdataAccess.ObtenerIdProfesorPorUsuario(idUsuario);

                // Obtener las materias del profesor actual
                DataTable materias = mdataAccess.ObtenerMateriasPorProfesor(idProfesor);

                // Obtener los IDs de las materias
                List<int> idMaterias = materias.AsEnumerable()
                    .Select(row => row.Field<int>("id_materia"))
                    .ToList();

                // Crear una instancia del formulario VerHorarios
                VerHorarios verHorariosForm = new VerHorarios();

                // Llamar al método CargarHorarios en VerHorarios con los IDs de las materias
                verHorariosForm.CargarHorarios(idMaterias);

                // Mostrar el formulario VerHorarios
                verHorariosForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el formulario de horarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
