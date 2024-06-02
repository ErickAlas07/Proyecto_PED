using Avance_1.Data;
using Avance_1.Models;
using System;
using System.Windows.Forms;

namespace Avance_1.Views
{
    public partial class NuevaMatricula : Form
    {
        private EstudianteDataAccess estudianteDataAccess;
        private MatriculaDataAccess matriculaDataAccess;
        private MateriaDataAccess materiaDataAccess;

        public NuevaMatricula()
        {
            InitializeComponent();
            estudianteDataAccess = new EstudianteDataAccess();
            matriculaDataAccess = new MatriculaDataAccess();
            materiaDataAccess = new MateriaDataAccess();

            CargarMaterias();
        }

        private void CargarMaterias()
        {
            var materias = matriculaDataAccess.TodasMaterias();
            cmbMaterias.DataSource = materias;
            cmbMaterias.DisplayMember = "Nombre";
            cmbMaterias.ValueMember = "Id";
        }

        private void NuevaMatricula_Load(object sender, EventArgs e)
        {
            cmbEstado.Items.Add("Pre-inscrito");
            cmbEstado.Items.Add("Inscrito");
            cmbEstado.Items.Add("Cancelado");
            cmbEstado.SelectedIndex = 0;
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el id_estudiante usando el id_usuario de la sesión
                int idUsuario = UserSession.IdUsuario;
                string idEstudiante = estudianteDataAccess.ObtenerIdEstudiantePorUsuario(idUsuario);
                // Obtener el id de la materia seleccionada en el ComboBox

                int idMateria = Convert.ToInt32(cmbMaterias.SelectedValue);

                // Obtener el nombre de la materia seleccionada en el ComboBox
                string nombreMateria = cmbMaterias.Text;

                // Obtener el estado de la matrícula desde el ComboBox
                string estado = cmbEstado.SelectedItem.ToString();

                // Verificar si el estudiante ya está matriculado en la materia seleccionada
                if (matriculaDataAccess.EstaMatriculado(idEstudiante, idMateria))
                {
                    MessageBox.Show("El estudiante ya está matriculado en esta materia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Crear una nueva instancia de Matricula con los datos obtenidos
                Matricula matricula = new Matricula
                {
                    IdEstudiante = idEstudiante,
                    IdMateria = idMateria,
                    Estado = estado
                };

                // Insertar la nueva matrícula en la base de datos
                matriculaDataAccess.InsertarMatricula(matricula);

                // Mostrar información de matrícula.
                lblCarnet.Text = idEstudiante;
                lblStatus.Text = estado;
                lblAsignatura.Text = nombreMateria;

                // Limpiar los ComboBoxes
                cmbEstado.SelectedIndex = 0;
                cmbMaterias.SelectedIndex = -1;

                // Mostrar un mensaje de éxito
                MessageBox.Show("Matrícula creada exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear la matrícula: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
