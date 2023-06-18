using Entidades;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static System.Net.Mime.MediaTypeNames;

namespace Datos
{
    public class CRUD
    {
        public DataTable Listar(string tableName)
        {
            MySqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            MySqlConnection SqlCon = new MySqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                MySqlCommand Comando = new MySqlCommand("Select * from " + tableName, SqlCon);
                Comando.CommandType = CommandType.Text;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }

        public DataTable Buscar(string tableName, string textoBuscado, string dentroDelCampo, string operadorComparacion)
        {
            MySqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            MySqlConnection SqlCon = new MySqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                MySqlCommand Comando = new MySqlCommand("select * from " + tableName + " where " + dentroDelCampo + operadorComparacion + textoBuscado, SqlCon);
                Comando.CommandType = CommandType.Text;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }
        public DataTable BuscarLike(string tableName, string textoBuscado, string dentroDelCampo)
        {
            MySqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            MySqlConnection SqlCon = new MySqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                MySqlCommand Comando = new MySqlCommand("select * from " + tableName + " where " + dentroDelCampo + " like '%" + textoBuscado + "%'", SqlCon);
                Comando.CommandType = CommandType.Text;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }
      
        public string Insertar(Object obj,bool autoIncrement)
        {

            TypeInfo typeInfo = obj.GetType().GetTypeInfo();
            List<string> campos = new List<string>();
            List<string> valores = new List<string>();
            string errorMessage=string.Empty;

            var attrs = typeInfo.GetProperties();
            for (int i = 0; i < attrs.Length; i++)
            {
                if (autoIncrement && i==0)
                    i++;
                campos.Add(attrs[i].Name);
                valores.Add(attrs[i].GetValue(obj).ToString());
            }
            /*
            foreach (var attr in attrs)
            {
                campos.Add(attr.Name);
                valores.Add(attr.GetValue(obj).ToString());
            }
              */

            Int32 NumFilasAfectadas = 0;
            MySqlConnection SqlCon = new MySqlConnection();
            try
            {
                string listaCampos = string.Join(",", campos.ToArray());
                List<string> listaValores = new List<string>();
                if (campos.Count() == valores.Count())
                {
                    for (int i = 0; i <= valores.Count() - 1; i++)
                        listaValores.Add("?Valor" + i.ToString());

                    string listaValores_ = string.Join(",", listaValores.ToArray());
                    string sqlSentence = "INSERT INTO " + typeInfo.Name + "(" + listaCampos + ")values(" + listaValores_.ToString() + ")";

                    SqlCon = Conexion.getInstancia().CrearConexion();
                    MySqlCommand Comando = new MySqlCommand(sqlSentence, SqlCon);
                    Comando.CommandType = CommandType.Text;
                    SqlCon.Open();
                    for (int i = 0; i <= valores.Count() - 1; i++)
                        Comando.Parameters.AddWithValue("?Valor" + i.ToString(), valores[i]);
                    NumFilasAfectadas = Comando.ExecuteNonQuery();

                }
                    
            }
            catch (MySqlException e)
            {
                NumFilasAfectadas = 0;
                errorMessage= e.Message + ":::: "+ Environment.NewLine+ e.StackTrace;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            if (NumFilasAfectadas > 0)
                return "Registro agregado con éxito";
            else
                return errorMessage;
            //return NumFilasAfectadas;
        }
        public string Insertar(Object mainObject, bool autoIncrement1, Object secondObject, bool autoIncrement2)
        {

            TypeInfo mainEntity = mainObject.GetType().GetTypeInfo();
            TypeInfo secondEntity = secondObject.GetType().GetTypeInfo();

            List<string> campos1 = new List<string>(), campos2 = new List<string>();
            List<string> valores1 = new List<string>(), valores2 = new List<string>();
            string errorMessage = string.Empty;

            var mainAttrs = mainEntity.GetProperties();
            var secondAttrs = secondEntity.GetProperties();

            for (int i = 0; i < mainAttrs.Length; i++)
            {
                if (autoIncrement1 && i == 0)
                    i++;
                campos1.Add(mainAttrs[i].Name);
                valores1.Add(mainAttrs[i].GetValue(mainObject).ToString());
            }

            for (int j = 0; j < secondAttrs.Length; j++)
            {
                if (autoIncrement2 && j == 0)
                    j++;
                campos2.Add(secondAttrs[j].Name);
                valores2.Add(secondAttrs[j].GetValue(secondObject).ToString());
            }

            Int32 NumFilasAfectadas = 0;
            MySqlConnection SqlCon2 = new MySqlConnection();
            SqlCon2 = Conexion.getInstancia().CrearConexion();

            //************************************
            //Último Id
            //************************************
            MySqlCommand Comando_tmp = new MySqlCommand("SELECT MAX(idPersona)+1 AS IdMax FROM Persona", SqlCon2);
            Comando_tmp.CommandType = CommandType.Text;
            SqlCon2.Open();
            string canti = Comando_tmp.ExecuteScalar().ToString();
            long lastId = 0;
            if (string.IsNullOrEmpty(canti))
                lastId = 1;
            else
                lastId = int.Parse(canti);

            SqlCon2.Close();
            //************************************
            //Fin Último Id
            //************************************
            MySqlConnection SqlCon = new MySqlConnection();
            SqlCon = Conexion.getInstancia().CrearConexion();
            SqlCon.Open();
            MySqlTransaction transaccion = SqlCon.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
            try
            {
                //Entidad u Objeto 1
                string listaCampos1 = string.Join(",", campos1.ToArray());
                List<string> listaValores1 = new List<string>();
                // Entidad u Objeto 2
                string listaCampos2 = string.Join(",", campos2.ToArray());
                List<string> listaValores2 = new List<string>();


                if (campos1.Count() == valores1.Count() && campos2.Count() == valores2.Count())
                {

                    for (int i = 0; i <= valores1.Count() - 1; i++)
                        listaValores1.Add("?Valor1_" + i.ToString());

                    for (int j = 0; j <= valores2.Count() - 1; j++)
                        listaValores2.Add("?Valor2_" + j.ToString());


                    string listaValores1_ = string.Join(",", listaValores1.ToArray());
                    string listaValores2_ = string.Join(",", listaValores2.ToArray());

                    string sqlSentence1 = "INSERT INTO " + mainEntity.Name + "(" + listaCampos1 + ")values(" + listaValores1_.ToString() + ")";
                    string sqlSentence2 = "INSERT INTO " + secondEntity.Name + "(" + listaCampos2 + ")values(" + listaValores2_.ToString() + ")";

                    //Inicio del insert

                    MySqlCommand Comando = new MySqlCommand();
                    Comando.CommandType = CommandType.Text;
                    Comando = new MySqlCommand(sqlSentence1, SqlCon);
                    Comando.CommandText = sqlSentence1;
                    for (int i = 0; i <= valores1.Count() - 1; i++)
                        if (i == 0)
                            Comando.Parameters.AddWithValue("?Valor1_" + i.ToString(), lastId);
                        else
                            Comando.Parameters.AddWithValue("?Valor1_" + i.ToString(), valores1[i]);

                    Comando.ExecuteNonQuery();

                    Comando = new MySqlCommand(sqlSentence2, SqlCon);
                    for (int j = 0; j <= valores2.Count() - 1; j++)
                        if (j == 0)    // Valorar usar if (autoIncrement2 && j == 0)                     
                            Comando.Parameters.AddWithValue("?Valor2_" + j.ToString(), lastId);//mandar el mainObject.id                                                   
                        else
                            Comando.Parameters.AddWithValue("?Valor2_" + j.ToString(), valores2[j]);
                    NumFilasAfectadas = Comando.ExecuteNonQuery();
                    transaccion.Commit();
                    //Fin del insert
                }

            }
            catch (MySqlException e)
            {
                NumFilasAfectadas = 0;
                errorMessage = e.Message + ":::: " + Environment.NewLine + e.StackTrace;
                //transaccion.Rollback();
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            if (NumFilasAfectadas > 0)
                return "Registro agregado con éxito";
            else
                return errorMessage;
            //return NumFilasAfectadas;
        }
        public string Actualizar(Object obj)
        {

            TypeInfo typeInfo = obj.GetType().GetTypeInfo();
            List<string> campos = new List<string>();
            List<string> valores = new List<string>();
            string errorMessage= string.Empty;

            var attrs = typeInfo.GetProperties();
            for (int i = 0; i < attrs.Length; i++)
            {
                campos.Add(attrs[i].Name);
                valores.Add(attrs[i].GetValue(obj).ToString());
            }
          
            Int32 NumFilasAfectadas = 0;
            MySqlConnection SqlCon = new MySqlConnection();
            try
            {
                string listaCampos = string.Join(",", campos.ToArray());
                List<string> listaCamposValores = new List<string>();
                if (campos.Count() == valores.Count())
                {
                    for (int i = 1; i <= valores.Count() - 1; i++)//antes i =0
                        listaCamposValores.Add(campos[i].ToString() + " = " + "?Valor" + i.ToString());

                    string campoValor = string.Join(",", listaCamposValores.ToArray());
                    string sqlSentence = "UPDATE " + typeInfo.Name + " SET " + campoValor.ToString() + " WHERE " + campos[0].ToString()  +" = ?Condition";

                    SqlCon = Conexion.getInstancia().CrearConexion();
                    MySqlCommand Comando = new MySqlCommand(sqlSentence, SqlCon);
                    Comando.CommandType = CommandType.Text;
                    SqlCon.Open();
                    for (int i = 1; i <= valores.Count() - 1; i++)
                        Comando.Parameters.AddWithValue("?Valor" + i.ToString(), valores[i]);

                    Comando.Parameters.AddWithValue("?Condition", valores[0]);
                    NumFilasAfectadas = Comando.ExecuteNonQuery();

                }

            }
            catch (MySqlException e)
            {
                NumFilasAfectadas = 0;
                errorMessage= e.Message + "::  "+ Environment.NewLine  + e.StackTrace;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            if (NumFilasAfectadas > 0)
                return "Registro actualizado con éxito";
            else
                return errorMessage;
        }

        public string Eliminar(string tableName, string campoID, int campoValue)
        {
            string errorMessage=string.Empty, sqlSentence = string.Empty;
            Int32 NumFilasAfectadas = 0;
            MySqlConnection SqlCon = new MySqlConnection();
            try
            {
                sqlSentence = "Delete from " + tableName + " where " + campoID + "=?delValue" ;
                SqlCon = Conexion.getInstancia().CrearConexion();
                MySqlCommand Comando = new MySqlCommand(sqlSentence, SqlCon);
                Comando.CommandType = CommandType.Text;
                SqlCon.Open();
                Comando.Parameters.AddWithValue("?delValue", campoValue);
                NumFilasAfectadas = Comando.ExecuteNonQuery() ;
            }
            catch (MySqlException e)
            {
                NumFilasAfectadas = 0;
                errorMessage = e.Message + ":::: " + Environment.NewLine + e.StackTrace;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            if (NumFilasAfectadas > 0)
                return "Registro eliminado con éxito";
            else
                return errorMessage;
        }
        public DataTable Consultar(string sqlSentence)
        {
            MySqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            MySqlConnection SqlCon = new MySqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                MySqlCommand Comando = new MySqlCommand(sqlSentence, SqlCon);
                Comando.CommandType = CommandType.Text;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }
        
        /// <summary>
        /// Elimina un registro de dos tablas relacionadas aplicando transacciones
        /// </summary>
        /// <param name="mainObject"> Clase que representa una tabla primaria</param>
        /// <param name="id1">Id único por el cuál se eliminará el registro de la tabla principal</param>
        /// <param name="secondObject">Clase que representa a una tabla secundaria</param>
        /// <param name="id2">Id único por el cuál se eliminará el registro de la tabla secundaria</param>
        /// <returns></returns>
        public string Eliminar(Object mainObject, int id1, Object secondObject, int id2)
        {
            TypeInfo mainEntity = mainObject.GetType().GetTypeInfo();
            TypeInfo secondEntity = secondObject.GetType().GetTypeInfo();
            var mainAttrs = mainEntity.GetProperties();
            var secondAttrs = secondEntity.GetProperties();
            
            Int32 NumFilasAfectadas = 0;
            string errorMessage = string.Empty;
            MySqlConnection SqlCon = new MySqlConnection();
            SqlCon = Conexion.getInstancia().CrearConexion();
            SqlCon.Open();
            MySqlTransaction transaccion = SqlCon.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
            try
            {
                string sqlSentence1 = "DELETE FROM " + mainEntity.Name + " WHERE " + mainAttrs[0].Name + "=?Id1";
                string sqlSentence2 = "DELETE FROM " + secondEntity.Name + " WHERE " + secondAttrs[0].Name + "=?Id2";

                MySqlCommand Comando = new MySqlCommand();
                Comando.CommandType = CommandType.Text;
                Comando = new MySqlCommand(sqlSentence1, SqlCon);
                Comando.Parameters.AddWithValue("?Id1",id1);
                Comando.ExecuteNonQuery();

                Comando = new MySqlCommand(sqlSentence2, SqlCon);
                Comando.Parameters.AddWithValue("?Id2", id2);
                NumFilasAfectadas = Comando.ExecuteNonQuery();
                transaccion.Commit();
            }
            catch (MySqlException e)
            {
                NumFilasAfectadas = 0;
                errorMessage = e.Message + ":::: " + Environment.NewLine + e.StackTrace;
                transaccion.Rollback();
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            if (NumFilasAfectadas > 0)
                return "Registro agregado con éxito";
            else
                return errorMessage;
        }
        public DataTable GetColumns(Object obj)
        {
            TypeInfo mainEntity = obj.GetType().GetTypeInfo();
            var mainAttrs = mainEntity.GetProperties();

            MySqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            MySqlConnection SqlCon = new MySqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                MySqlCommand Comando = new MySqlCommand("SHOW COLUMNS FROM " + mainEntity.Name + ";", SqlCon);
                Comando.CommandType = CommandType.Text;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }
        public DataTable GetColumns(string tableName)
        {
            MySqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            MySqlConnection SqlCon = new MySqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                MySqlCommand Comando = new MySqlCommand("SHOW COLUMNS FROM " + tableName + ";", SqlCon);
                Comando.CommandType = CommandType.Text;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }
        public string GetCodeSHA1(string cadena)
        {
            string resultado=string.Empty;
            MySqlConnection SqlCon = new MySqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();

                string query = @"SELECT SHA1(?Cadena) as NewString";
                MySqlCommand Comando = new MySqlCommand(query, SqlCon);
                Comando.CommandType = CommandType.Text;
                Comando.Parameters.AddWithValue("?Cadena", cadena);
                SqlCon.Open();
                resultado= Comando.ExecuteScalar().ToString();                
            }
            catch (Exception ex)
            {
                resultado = "No pudo obtenerse el SHA1 de la cadena";
                throw ex;                
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return resultado;
        }

        public bool ValidarCredenciales(string usuario, string contra)
        {
            MySqlConnection SqlCon = new MySqlConnection();
            {
                string query = "SELECT COUNT(*) FROM usuario WHERE nombreUsuario = @usuario AND contra = SHA1(@contra)";
                using (MySqlCommand command = new MySqlCommand(query, SqlCon))
                {
                    command.Parameters.AddWithValue("@usuario", usuario);
                    command.Parameters.AddWithValue("@contra", contra);

                    try
                    {
                        SqlCon.Open();
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        return count > 0;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
                    }
                }
            }
        }
    }
}
