using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class QUERY
    {
        public static DataTable Listar(string tableName)
        {
            CRUD Tabla = new CRUD();
            return Tabla.Listar(tableName);
        }
    }
}
