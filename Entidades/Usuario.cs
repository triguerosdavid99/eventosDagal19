using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public string usuario { get; set; }
        public string contra { get; set; }
        public int idTipoUsuario { get; set; }
        public int idPersona { get; set; }
    }
}
