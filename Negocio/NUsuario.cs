using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Negocio
{
    public class NUsuario
    {
        public static DataTable Listar()
        {
            CRUD Tabla = new CRUD();
            return Tabla.Listar("vusuario");
        }
        public static DataTable Buscar(string textoBuscado, string dentroDelCampo)
        {
            CRUD Tabla = new CRUD();
            return Tabla.BuscarLike("vusuario", textoBuscado, dentroDelCampo);
        }
        public static string Insertar(string usuario, string contra, int idTipoUsuario, int idPersona)
        {
            if (!string.IsNullOrEmpty(usuario) || !string.IsNullOrEmpty(contra) || idTipoUsuario > 0 || idPersona > 0)
            {
                DUsuario Tabla = new DUsuario();
                Usuario Obj = new Usuario();

                Obj.usuario = usuario;
                Obj.contra = contra;
                Obj.idTipoUsuario = idTipoUsuario;
                Obj.idPersona = idPersona;

                return Tabla.Insertar(Obj);
            }
            else
            {
                return "No se pueden guardar registros vacios";
            }
        }
        public static string Actualizar(int id, string usuario, string contra, int idTipoUsuario, int idPersona)
        {
            DUsuario Tabla = new DUsuario();
            Usuario Obj = new Usuario();
            Obj.idUsuario = id;
            Obj.usuario = usuario;
            Obj.contra = contra;
            Obj.idTipoUsuario = idTipoUsuario;
            Obj.idPersona = idPersona;
            return Tabla.Actualizar(Obj);
        }
        public static string Eliminar(int id)
        {
            if (MessageBox.Show("Desea eliminar el registro?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CRUD Tabla = new CRUD();
                Usuario Obj = new Usuario();
                Obj.idUsuario = id;
                return Tabla.Eliminar("usuario", "idUsuario", id);
            }
            return "Accion cancelada";
        }

        public static string Login(string usuario, string contra)
        {
            CRUD Tabla = new CRUD();
            Usuario Obj = new Usuario();
            Obj.usuario = usuario;
            Obj.contra = contra;
            bool credenciales = Tabla.ValidarCredenciales(usuario, contra);
            return credenciales.ToString();
        }
        public static bool ValidarUsuario(string usuario, string contra)
        {
            // Llamar al método de la capa de datos para verificar si el usuario y contraseña existen en la base de datos
            bool existeUsuario = DUsuario.ExisteUsuario(usuario, contra);

            return existeUsuario;
        }
        public static int ObtenerTipoUsuario(string usuario)
        {
            // Llamar al método de la capa de datos para obtener el tipo de usuario
            DUsuario dUsuario = new DUsuario();
            return  dUsuario.ObtenerTipoUsuario(usuario);
        }
    }
}
