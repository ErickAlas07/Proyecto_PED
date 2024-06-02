using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Avance_1.Data
{
    public class NotaDataAccess
    {
        private ConexionBD conexionBD;

        public NotaDataAccess()
        {
            conexionBD = new ConexionBD();
        }

        public DataTable ObtenerNotasEstudiante(string idEstudiante)
        {
            DataTable notas = new DataTable();

            try
            {
                ConexionBD objCon = new ConexionBD();
                MySqlConnection con = objCon.conexion;
                con.Open();
                string query = "SELECT m.nombre AS Materia, n.nota AS Nota FROM nota n JOIN materia m ON n.id_materia = m.id_materia WHERE id_estudiante = @IdEstudiante";
                
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@IdEstudiante", idEstudiante);

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(notas);
                }
                objCon.CerrarConexion();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al obtener las notas del estudiante: {ex.Message}", ex);
            }

            return notas;
        }
    }
}
