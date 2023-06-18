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
    public class NPersona
    {
        public static DataTable Listar()
        {
            CRUD Tabla = new CRUD();
            return Tabla.Listar("persona");
        }
        public static DataTable Buscar(string textoBuscado, string dentroDelCampo)
        {
            CRUD Tabla = new CRUD();
            return Tabla.BuscarLike("persona", textoBuscado, dentroDelCampo);
        }
        public static string Insertar(string dui, string nombre, string apellido, string correo, string telefono)
        {
            if (!string.IsNullOrEmpty(dui) || !string.IsNullOrEmpty(nombre) || !string.IsNullOrEmpty(apellido) || !string.IsNullOrEmpty(correo) || !string.IsNullOrEmpty(telefono))
            {
                CRUD Tabla = new CRUD();
                Persona Obj = new Persona();

                Obj.dui = dui;
                Obj.nombre = nombre;
                Obj.apellido = apellido;
                Obj.correo = correo;
                Obj.telefono = telefono;

                return Tabla.Insertar(Obj, true);
            }
            else
            {
                return "No se pueden guardar registros vacios";
            }
        }
        public static string Actualizar(int id, string dui, string nombre, string apellido, string correo, string telefono)
        {
            CRUD Tabla = new CRUD();
            Persona Obj = new Persona();
            Obj.idPersona = id;
            Obj.dui = dui;
            Obj.nombre = nombre;
            Obj.apellido = apellido;
            Obj.correo = correo;
            Obj.telefono = telefono;
            return Tabla.Actualizar(Obj);
        }
        public static string Eliminar(int id)
        {
            if (MessageBox.Show("Desea eliminar el registro?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CRUD Tabla = new CRUD();
                Persona Obj = new Persona();
                Obj.idPersona = id;
                return Tabla.Eliminar("persona", "idPersona", id);
            }
            return "Accion cancelada";
        }
    }
}
