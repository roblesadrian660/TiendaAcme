using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.Dto
{
    public class OrderXml
    {
        public int pedido { get; set; }
        public string Cantidad { get; set; }
        public string EAN { get; set; }
        public string Producto { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
    }
}
