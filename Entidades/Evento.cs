using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Evento
    {
        public int idEvento { get; set; }
        public string evento { get; set; }
        public string fecha { get; set; }
        public double duracion { get; set; }
        public string lugar { get; set; }
        public int idTipoEvento { get; set; }
        public int idCliente { get; set; }
        public double costo { get; set; }
        public int idUsuario { get; set; }
    }
}
