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
    public class NEvento
    {
        public static DataTable Listar()
        {
            CRUD Tabla = new CRUD();
            return Tabla.Listar("vevento");
        }
        public static DataTable Buscar(string textoBuscado, string dentroDelCampo)
        {
            CRUD Tabla = new CRUD();
            return Tabla.BuscarLike("vevento", textoBuscado, dentroDelCampo);
        }
        public static string Insertar(string evento, string fecha, double duracion, string lugar, int idTipoEvento, int idCliente, double costo, int idUsuario)
        {
            if (!string.IsNullOrEmpty(evento) || !string.IsNullOrEmpty(lugar) || duracion > 0 || !string.IsNullOrEmpty(lugar) || idTipoEvento > 0 || idCliente > 0 || costo > 0)
            {
                CRUD Tabla = new CRUD();
                Evento Obj = new Evento();

                Obj.evento = evento;
                Obj.fecha = fecha;
                Obj.duracion = duracion;
                Obj.lugar = lugar;
                Obj.idTipoEvento = idTipoEvento;
                Obj.idCliente = idCliente;
                Obj.costo = costo;
                Obj.idUsuario = idUsuario;

                return Tabla.Insertar(Obj, true);
            }
            else
            {
                return "No se pueden guardar registros vacios";
            }
        }
        public static string Actualizar(int id, string evento, string fecha, double duracion, string lugar, int idTipoEvento, int idCliente, double costo, int idUsuario)
        {
            CRUD Tabla = new CRUD();
            Evento Obj = new Evento();
            Obj.idEvento = id;
            Obj.evento = evento;
            Obj.fecha = fecha;
            Obj.duracion = duracion;
            Obj.lugar = lugar;
            Obj.idTipoEvento = idTipoEvento;
            Obj.idCliente = idCliente;
            Obj.costo = costo;
            Obj.idUsuario = idUsuario;
            return Tabla.Actualizar(Obj);
        }
        public static string Eliminar(int id)
        {
            if (MessageBox.Show("Desea eliminar el registro?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CRUD Tabla = new CRUD();
                Evento Obj = new Evento();
                Obj.idCliente = id;
                return Tabla.Eliminar("evento", "idEvento", id);
            }
            return "Accion cancelada";
        }
    }
}
