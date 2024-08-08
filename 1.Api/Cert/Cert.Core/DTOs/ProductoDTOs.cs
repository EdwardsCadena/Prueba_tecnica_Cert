using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cert.Core.DTOs
{
    public class ProductoDTOs
    {
        public string Nombre { get; set; } = null!;

        public decimal Precio { get; set; }

        public int Cantidad { get; set; }
    }
}
