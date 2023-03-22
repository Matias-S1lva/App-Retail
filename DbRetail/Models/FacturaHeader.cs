using System;
using System.Collections.Generic;

namespace DbRetail.Models
{
    public partial class FacturaHeader
    {
        public int IdFactura { get; set; }
        public DateTime? FechaEmision { get; set; }
        public double? TotalFactura { get; set; }
        public int? IdVenta { get; set; }
        public int? IdSucursal { get; set; }
    }
}
