using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Avance_1.Data
{
    public class HorarioDataAccess
    {
        private ConexionBD conexionBD;

        public HorarioDataAccess()
        {
            conexionBD = new ConexionBD();
        }

        public DataTable ObtenerHorariosPorMateria(List<int> idMaterias)
        {
            try
            {
                ConexionBD objCon = new ConexionBD();
                MySqlConnection con = objCon.conexion;
                con.Open();
                string query = "SELECT id_horario, id_materia, día_de_la_semana, hora__inicial, hora_final FROM horario WHERE id_materia IN (" + string.Join(",", idMaterias) + ")";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
                
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al obtener los horarios por materia: {ex.Message}", ex);
            }
        }
    }
}
