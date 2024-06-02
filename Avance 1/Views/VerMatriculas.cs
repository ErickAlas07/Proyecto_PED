using Avance_1.Data;
using System;
using System.Data;
using System.Windows.Forms;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.IO;
using System.Diagnostics;

namespace Avance_1.Views
{
    public partial class VerMatriculas : Form
    {
        private MatriculaDataAccess matriculaDataAccess;
        private EstudianteDataAccess estudianteDataAccess;

        public VerMatriculas()
        {
            InitializeComponent();
            matriculaDataAccess = new MatriculaDataAccess();
            estudianteDataAccess = new EstudianteDataAccess();
        }

        private void VerMatriculas_Load(object sender, EventArgs e)
        {
            CargarMatriculas();
        }

        private void CargarMatriculas()
        {
            try
            {
                // Obtener el idUsuario del usuario actual
                int idUsuario = UserSession.IdUsuario;

                // Obtener el idEstudiante del usuario actual
                string idEstudiante = estudianteDataAccess.ObtenerIdEstudiantePorUsuario(idUsuario);

                // Obtener las matrículas del estudiante actual
                DataTable matriculas = matriculaDataAccess.ObtenerMatriculasEstudiante(idEstudiante);

                // Asignar el DataTable al DataGridView
                dataGridView1.DataSource = matriculas;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las matrículas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            ActualizarEstadoSeleccionado("Inscrito");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ActualizarEstadoSeleccionado("Cancelada");
        }

        private void ActualizarEstadoSeleccionado(string nuevoEstado)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una matrícula para actualizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Obtener el idUsuario del usuario actual
                int idUsuario = UserSession.IdUsuario;

                // Obtener el idEstudiante del usuario actual
                string idEstudiante = estudianteDataAccess.ObtenerIdEstudiantePorUsuario(idUsuario);

                // Obtener la fila seleccionada
                DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];
                int idMateria = Convert.ToInt32(filaSeleccionada.Cells["id_materia"].Value);
                string estadoActual = filaSeleccionada.Cells["estado"].Value.ToString();

                if (nuevoEstado == "Cancelada" && estadoActual != "Pre-inscrito")
                {
                    MessageBox.Show("Solo se pueden eliminar matrículas con estado 'Pre-inscrito'.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (nuevoEstado == "Cancelada")
                {
                    // Eliminar la matrícula si el estado es "Cancelada"
                    matriculaDataAccess.EliminarMatricula(idEstudiante, idMateria);
                }
                else
                {
                    // Actualizar el estado de la matrícula
                    matriculaDataAccess.ActualizarEstadoMatricula(idEstudiante, idMateria, nuevoEstado);
                }

                // Recargar las matrículas para reflejar los cambios
                CargarMatriculas();

                // Mostrar mensaje de éxito
                MessageBox.Show($"Estado de la matrícula actualizado a {nuevoEstado}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el estado de la matrícula: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPdf_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el ID del estudiante desde la sesión
                int idUsuario = UserSession.IdUsuario;
                string idEstudiante = estudianteDataAccess.ObtenerIdEstudiantePorUsuario(idUsuario);

                // Crear un documento PDF
                PdfDocument document = new PdfDocument();
                PdfPage page = document.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);

                // Definir fuentes
                XFont fontTitle = new XFont("Verdana", 20, XFontStyleEx.Bold);
                XFont fontHeader = new XFont("Verdana", 12, XFontStyleEx.Bold);
                XFont fontContent = new XFont("Verdana", 12, XFontStyleEx.Regular);

                // Coordenadas iniciales
                double yPoint = 40;

                // Dibujar título
                gfx.DrawString("Reporte de Matrículas", fontTitle, XBrushes.Black,
                    new XRect(0, yPoint, page.Width.Point, page.Height.Point), XStringFormats.TopCenter);

                yPoint += 40;

                // Carnet de estudiante
                gfx.DrawString($"Carnet de estudiante: {idEstudiante}", fontContent, XBrushes.Black,
                    new XRect(20, yPoint, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                yPoint += 30;

                // Dibujar encabezados
                gfx.DrawString("Materia", fontHeader, XBrushes.Black, new XRect(20, yPoint, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                gfx.DrawString("Estado", fontHeader, XBrushes.Black, new XRect(350, yPoint, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                yPoint += 20;

                // Dibujar contenido de DataGridView
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["Materia"].Value != null && row.Cells["Estado"].Value != null)
                    {
                        string materia = row.Cells["Materia"].Value.ToString();
                        string estado = row.Cells["Estado"].Value.ToString();

                        gfx.DrawString(materia, fontContent, XBrushes.Black, new XRect(20, yPoint, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                        gfx.DrawString(estado, fontContent, XBrushes.Black, new XRect(350, yPoint, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                        yPoint += 30;
                    }
                }

                // Usar SaveFileDialog para permitir al usuario seleccionar la ruta de almacenamiento
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                    saveFileDialog.DefaultExt = "pdf";
                    saveFileDialog.AddExtension = true;
                    saveFileDialog.Title = "Guardar Reporte de Matrículas";
                    saveFileDialog.FileName = "Reporte de Inscripción";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filename = saveFileDialog.FileName;
                        document.Save(filename);

                        // Mostrar un mensaje de éxito
                        MessageBox.Show("PDF generado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
