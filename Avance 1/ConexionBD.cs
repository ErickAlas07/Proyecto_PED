using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avance_1
{
   internal class ConexionBD
    {
        private MySqlConnection conexion;
        private string server = "localhost";
        private string database = "sistema";
        private string user = "root";
        private string password = "";
        private string cadenaConexion;

        public ConexionBD()
        {
            cadenaConexion = "Database=" + database + "; DataSource=" + server+"; User Id= "+user+ "; Password="+password;
        }

        public MySqlConnection GetConexion()
        {
            if(conexion==null)
            {
                conexion = new MySqlConnection(cadenaConexion);
                //conexion.Open();
             }

            return conexion;
        }
    }
}
