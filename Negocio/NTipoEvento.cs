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
    public class NTipoEvento
    {
        public static DataTable Listar()
        {
            CRUD Tabla = new CRUD();
            return Tabla.Listar("tipoEvento");
        }
        public static DataTable Buscar(string textoBuscado, string dentroDelCampo)
        {
            CRUD Tabla = new CRUD();
            return Tabla.BuscarLike("tipoEvento", textoBuscado, dentroDelCampo);
        }
        public static string Insertar(string tipoEvento)
        {
            if (!string.IsNullOrEmpty(tipoEvento))
            {
                CRUD Tabla = new CRUD();
                TipoEvento Obj = new TipoEvento();

                Obj.tipoEvento = tipoEvento;

                return Tabla.Insertar(Obj, true);
            }
            else
            {
                return "No se pueden guardar registros vacios";
            }
        }
        public static string Actualizar(int id, string tipoEvento)
        {
            CRUD Tabla = new CRUD();
            TipoEvento Obj = new TipoEvento();
            Obj.idTipoEvento = id;
            Obj.tipoEvento = tipoEvento;
            return Tabla.Actualizar(Obj);
        }
        public static string Eliminar(int id)
        {
            if (MessageBox.Show("Desea eliminar el registro?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CRUD Tabla = new CRUD();
                TipoEvento Obj = new TipoEvento();
                Obj.idTipoEvento = id;
                return Tabla.Eliminar("tipoEvento", "idTipoEvento", id);
            }
            return "Accion cancelada";
        }
    }
}
