
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AberturasSalta.Objetos
{
    public class Pago
    {
        public string id { get; set; }
        public string key { get; set; }
        public string foranea { get; set; }
        public string nombre { get; set; }
        public string fecha { get; set; }
        public string monto { get; set; }
        public string sucursal { get; set; }
        public string comentario { get; set; }
    }
}
