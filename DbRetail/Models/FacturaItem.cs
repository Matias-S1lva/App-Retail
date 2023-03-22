using System;
using System.Collections.Generic;

namespace DbRetail.Models
{
    public partial class FacturaItem
    {
        public int IdFacturaItem { get; set; }
        public int? IdProducto { get; set; }
        public int? IdVenta { get; set; }
        public int? CantidadVendida { get; set; }
        public double? PrecioUnitario { get; set; }
    }
}
