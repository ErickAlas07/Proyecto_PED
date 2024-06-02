using MySql.Data.MySqlClient;
using System;

namespace Avance_1.Data
{
    public class AutenticarLogin
    {
        public AutenticarLogin() { }

        public (bool, int, int) Authenticate(string username, string password)
        {
            ConexionBD objCon = new ConexionBD();
            MySqlConnection con = objCon.conexion;
            con.Open();
            string query = "SELECT id_usuario, id_rol FROM usuario WHERE nombre_usuario = @nombre_usuario AND pass = @pass";

            try
            {
                using (MySqlCommand comando = new MySqlCommand(query, con))
                {
                    comando.Parameters.AddWithValue("@nombre_usuario", username);
                    comando.Parameters.AddWithValue("@pass", password);

                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int idUsuario = reader.GetInt32("id_usuario");
                            int rolId = reader.GetInt32("id_rol");
                            return (true, idUsuario, rolId);
                        }
                        else
                        {
                            return (false, 0, 0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al autenticar el usuario: {ex.Message}");
            }
        }
    }
}
