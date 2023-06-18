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
    public class NCliente
    {
        public static DataTable Listar()
        {
            CRUD Tabla = new CRUD();
            return Tabla.Listar("vcliente");
        }
        public static DataTable Buscar(string textoBuscado, string dentroDelCampo)
        {
            CRUD Tabla = new CRUD();
            return Tabla.BuscarLike("vcliente", textoBuscado, dentroDelCampo);
        }
        public static string Insertar(int idPersona)
        {
            if (idPersona  > 0)
            {
                CRUD Tabla = new CRUD();
                Cliente Obj = new Cliente();

                Obj.idPersona = idPersona;

                return Tabla.Insertar(Obj, true);
            }
            else
            {
                return "No se pueden guardar registros vacios";
            }
        }
        public static string Actualizar(int id, int idPersona)
        {
            CRUD Tabla = new CRUD();
            Cliente Obj = new Cliente();
            Obj.idCliente = id;
            Obj.idPersona = idPersona;
            return Tabla.Actualizar(Obj);
        }
        public static string Eliminar(int id)
        {
            if (MessageBox.Show("Desea eliminar el registro?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CRUD Tabla = new CRUD();
                Cliente Obj = new Cliente();
                Obj.idCliente = id;
                return Tabla.Eliminar("cliente", "idCliente", id);
            }
            return "Accion cancelada";
        }
    }
}
