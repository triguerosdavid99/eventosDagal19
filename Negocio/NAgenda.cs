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
    public class NAgenda
    {
        public static DataTable Listar()
        {
            CRUD Tabla = new CRUD();
            return Tabla.Listar("vagenda");
        }
        public static DataTable Buscar(string textoBuscado, string dentroDelCampo)
        {
            CRUD Tabla = new CRUD();
            return Tabla.BuscarLike("vagenda", textoBuscado, dentroDelCampo);
        }
        public static string Insertar(int nActividad, string actividad, int idEvento)
        {
            if (nActividad > 0 || !string.IsNullOrEmpty(actividad) || idEvento > 0)
            {
                CRUD Tabla = new CRUD();
                Agenda Obj = new Agenda();

                Obj.nActividad = nActividad;
                Obj.actividad = actividad;
                Obj.idEvento = idEvento;

                return Tabla.Insertar(Obj, true);
            }
            else
            {
                return "No se pueden guardar registros vacios";
            }
        }
        public static string Actualizar(int id, int nActividad, string actividad, int idEvento)
        {
            CRUD Tabla = new CRUD();
            Agenda Obj = new Agenda();
            Obj.idAgenda = id;
            Obj.nActividad = nActividad;
            Obj.actividad = actividad;
            Obj.idEvento = idEvento;
            return Tabla.Actualizar(Obj);
        }
        public static string Eliminar(int id)
        {
            if (MessageBox.Show("Desea eliminar el registro?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CRUD Tabla = new CRUD();
                Agenda Obj = new Agenda();
                Obj.idAgenda = id;
                return Tabla.Eliminar("agenda", "idAgenda", id);
            }
            return "Accion cancelada";
        }
    }
}
