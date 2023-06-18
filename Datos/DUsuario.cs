using Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DUsuario
    {
        public string Insertar(Usuario Obj)
        {
            string Resultado;
            MySqlConnection SqlCon = new MySqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                MySqlCommand Comando = new MySqlCommand("insert into usuario (usuario, contra, idTipoUsuario, idPersona) values (?ValorUsuario, sha1(?ValorContra), ?ValorIdTipoUsuario, ?ValorIdPersona)", SqlCon);
                Comando.CommandType = CommandType.Text;
                Comando.Parameters.Add("?ValorUsuario", MySqlDbType.VarChar).Value = Obj.usuario;
                Comando.Parameters.Add("?ValorContra", MySqlDbType.VarChar).Value = Obj.contra;
                Comando.Parameters.Add("?ValorIdTipoUsuario", MySqlDbType.VarChar).Value = Obj.idTipoUsuario;
                Comando.Parameters.Add("?ValorIdPersona", MySqlDbType.VarChar).Value = Obj.idPersona;
                SqlCon.Open();
                Resultado = Comando.ExecuteNonQuery() == 1 ? "Registro insertado con exito" : "No se pudo insertar el registro";
            }
            catch (Exception ex)
            {
                //throw ex;
                Resultado = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Resultado;
        }
        public string Actualizar(Usuario Obj)
        {
            string Resultado;
            MySqlConnection SqlCon = new MySqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                MySqlCommand Comando = new MySqlCommand("update usuario set usuario = ?ValorUsuario, contra = sha1(?ValorContra), idTipoUsuario = ?ValorIdTipoUsuario, idPersona = ?ValorIdPersona where idUsuario = ?ValorId", SqlCon);
                Comando.CommandType = CommandType.Text;
                Comando.Parameters.Add("?ValorId", MySqlDbType.VarChar).Value = Obj.idUsuario;
                Comando.Parameters.Add("?ValorUsuario", MySqlDbType.VarChar).Value = Obj.usuario;
                Comando.Parameters.Add("?ValorContra", MySqlDbType.VarChar).Value = Obj.contra;
                Comando.Parameters.Add("?ValorIdTipoUsuario", MySqlDbType.VarChar).Value = Obj.idTipoUsuario;
                Comando.Parameters.Add("?ValorIdPersona", MySqlDbType.VarChar).Value = Obj.idPersona;
                SqlCon.Open();
                Resultado = Comando.ExecuteNonQuery() == 1 ? "Registro actualizado con exito" : "No se pudo actualizar el registro";
            }
            catch (Exception ex)
            {
                //throw ex;
                Resultado = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Resultado;
        }
        public static bool ExisteUsuario(string usuario, string contra)
        {
            // Aquí debes implementar la lógica para verificar si el usuario y contraseña existen en la base de datos
            // Puedes utilizar consultas SQL, Entity Framework u otro mecanismo de acceso a datos según tu elección

            // Ejemplo de implementación utilizando consultas SQL con ADO.NET:
            bool resultado = false;
            MySqlConnection SqlCon = new MySqlConnection();
            SqlCon = Conexion.getInstancia().CrearConexion();

            string query = "SELECT COUNT(*) FROM Usuario WHERE Usuario = @Usuario AND Contra = sha1(@Contra)";
            MySqlCommand command = new MySqlCommand(query, SqlCon);
            command.Parameters.AddWithValue("@Usuario", usuario);
            command.Parameters.AddWithValue("@Contra", contra);
            //command.Parameters.Add("?Usuario", MySqlDbType.VarChar).Value = Obj.usuario;
            //command.Parameters.Add("?Contra", MySqlDbType.VarChar).Value = Obj.contra;
            try
            {
                SqlCon.Open();
                //int count = (int)command.ExecuteScalar();

                //if (count > 0)
                //{
                //    resultado = true;
                //}
                object result = command.ExecuteScalar();
                if (int.TryParse(result.ToString(), out int count))
                {
                    if (count > 0)
                    {
                        resultado = true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                // Manejar la excepción de conexión a la base de datos
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return resultado;
        }

        //tipo
        public int ObtenerTipoUsuario(string usuario)
        {
            int tipoUsuario = 0;

            MySqlConnection SqlCon = new MySqlConnection();
            try
            {


                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCon.Open();

                    string consulta = "SELECT idTipoUsuario FROM usuario WHERE usuario = @Usuario";
                    MySqlCommand comando = new MySqlCommand(consulta, SqlCon);
                    comando.Parameters.AddWithValue("@Usuario", usuario);

                    object resultado = comando.ExecuteScalar();
                    if (resultado != null && resultado != DBNull.Value)
                    {
                        tipoUsuario = Convert.ToInt32(resultado);
                    }
                
            }
            catch (Exception ex)
            {
                // Manejar la excepción de acuerdo a tus necesidades
                Console.WriteLine("Error al obtener el tipo de usuario: " + ex.Message);
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return tipoUsuario;
        }
        //tipo

    }
}
