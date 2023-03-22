using System;
using System.Collections.Generic;

namespace DbRetail.Models
{
    public partial class Ventum
    {
        public int NumeroVenta { get; set; }
        public DateTime? FechaVenta { get; set; }
        public double? TotalVenta { get; set; }
        public int? Dni { get; set; }
        public int? IdVendedor { get; set; }
        public int? IdSucursal { get; set; }
    }
}
