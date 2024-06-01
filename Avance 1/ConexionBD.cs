using MySql.Data.MySqlClient;
using System;

namespace Avance_1
{
    class ConexionBD
    {
        static string servidor = "localhost";
        static string bd = "sistema";
        static string user = "root";
        static string password = "";
        static string puerto = "3306";

        static string cadena = "server=" + servidor + ";" + "port=" + puerto + ";" + "user id=" + user + ";" + "password=" + password + ";" + "database=" + bd + ";";
        public MySqlConnection conexion = new MySqlConnection(cadena);

        public MySqlConnection GetConexion()
        {
            return conexion;
        }

        public bool AbrirConexion()
        {
            try
            {
                conexion.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error de conexión" + ex);
                return false;
            }
        }

        public void CerrarConexion()
        {
            conexion.Close();
        }
    }
}
