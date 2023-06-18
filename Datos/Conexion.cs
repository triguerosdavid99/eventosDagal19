using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Datos
{
    public class Conexion
    {
        private static Conexion Conn = null;
        private Conexion()
        {

        }
        public MySqlConnection CrearConexion()
        {
            MySqlConnection Cadena = new MySqlConnection();
            try
            {
                Cadena.ConnectionString = Datos.Properties.Settings.Default.CnxString;
            }
            catch (Exception ex)
            {
                Cadena = null;
                throw ex;
            }
            return Cadena;
        }
        public static Conexion getInstancia()
        {
            if (Conn == null)
            {
                Conn = new Conexion();
            }
            return Conn;
        }
    }
}
