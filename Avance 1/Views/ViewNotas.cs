using Avance_1.Data;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Data;
using System.Windows.Forms;

namespace Avance_1.Views
{
    public partial class ViewNotas : Form
    {
        private NotaDataAccess notaDataAccess;
        private EstudianteDataAccess eDataAccess;

        public ViewNotas()
        {
            InitializeComponent();
            notaDataAccess = new NotaDataAccess();
            eDataAccess = new EstudianteDataAccess();
        }

        private void CargarNotas()
        {
            try
            {
                // Obtener el idUsuario del usuario actual
                int idUsuario = UserSession.IdUsuario;

                // Obtener el idEstudiante del usuario actual
                string idEstudiante = eDataAccess.ObtenerIdEstudiantePorUsuario(idUsuario);

                // Obtener las notas del estudiante actual
                DataTable notas = notaDataAccess.ObtenerNotasEstudiante(idEstudiante);

                // Asignar el DataTable al DataGridView
                dataGridView1.DataSource = notas;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las notas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ViewNotas_Load_1(object sender, EventArgs e)
        {
            CargarNotas();
        }

        private void btnPdf_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el ID del estudiante desde la sesión
                int idUsuario = UserSession.IdUsuario;
                string idEstudiante = eDataAccess.ObtenerIdEstudiantePorUsuario(idUsuario);

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
                gfx.DrawString("Reporte de Notas", fontTitle, XBrushes.Black,
                    new XRect(0, yPoint, page.Width.Point, page.Height.Point), XStringFormats.TopCenter);

                yPoint += 40;

                // Carnet de estudiante
                gfx.DrawString($"Carnet de estudiante: {idEstudiante}", fontContent, XBrushes.Black,
                    new XRect(20, yPoint, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                yPoint += 30;

                // Dibujar encabezados
                gfx.DrawString("Materia", fontHeader, XBrushes.Black, new XRect(20, yPoint, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                gfx.DrawString("Nota", fontHeader, XBrushes.Black, new XRect(350, yPoint, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                yPoint += 20;

                // Obtener las notas del estudiante actual
                DataTable notas = notaDataAccess.ObtenerNotasEstudiante(idEstudiante);

                // Dibujar contenido de DataTable
                foreach (DataRow row in notas.Rows)
                {
                    if (row["Materia"] != null && row["Nota"] != null)
                    {
                        string materia = row["Materia"].ToString();
                        string nota = row["Nota"].ToString();

                        gfx.DrawString(materia, fontContent, XBrushes.Black, new XRect(20, yPoint, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);
                        gfx.DrawString(nota, fontContent, XBrushes.Black, new XRect(350, yPoint, page.Width.Point, page.Height.Point), XStringFormats.TopLeft);

                        yPoint += 30;
                    }
                }

                // Usar SaveFileDialog para permitir al usuario seleccionar la ruta de almacenamiento
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                    saveFileDialog.DefaultExt = "pdf";
                    saveFileDialog.AddExtension = true;
                    saveFileDialog.Title = "Guardar Reporte de Notas";
                    saveFileDialog.FileName = "Reporte de Notas";

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

    }
}
