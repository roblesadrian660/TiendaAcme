using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.Dto
{
    public class OrderAcme
    {
        public int numPedido { get; set; }
        public string cantidadPedido { get; set; }
        public string codigoEAN { get; set; }
        public string nombreProducto { get; set; }
        public string numDocumento { get; set; }
        public string direccion { get; set; }
    }
}
