using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace botones
{
    internal class Conexion
    {

        public static MySqlConnection conexion()
        {
            String servidor = "localhost";
            String bd = "almacen";
            String usuario = "root";
            String pass = "1234";
            String cadenaconexion = "Database=" + bd +"; Server="+servidor+";user ID="+usuario+";Password="+pass+"";


            try
            {
                MySqlConnection BDconexion = new MySqlConnection(cadenaconexion);
                return BDconexion;
            }catch(MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
