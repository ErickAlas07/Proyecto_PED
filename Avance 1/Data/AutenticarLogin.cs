using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avance_1.Data
{
    public class AutenticarLogin
    {
        private ConexionBD mConexion;

        public AutenticarLogin()
        {
            mConexion = new ConexionBD();
        }

        public bool Authenticate(string username, string password)
        {
            string query = "SELECT * FROM usuario WHERE nombre_usuario = @nombre_usuario AND pass = @pass";

            using (var conexion = mConexion.GetConexion())
            {
                mConexion.AbrirConexion();
                try
                {
                    using (MySqlCommand comando = new MySqlCommand(query, conexion))
                    {
                        comando.Parameters.AddWithValue("@nombre_usuario", username);
                        comando.Parameters.AddWithValue("@pass", password);

                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            return reader.HasRows;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error al autenticar el usuario: {ex.Message}");
                }
                finally
                {
                    //mConexion.CerrarConexion();
                }
            }
        }
    }
}
